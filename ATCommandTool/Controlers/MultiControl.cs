using ATCommandTool.Mode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ATCommandTool.Controlers
{
    //对多条命令发送的操作
    class MultiControl
    {
        MultiCommands MultiCommands;
        List<ATCommand> atCommands;
        List<ATCommand> atCommandsTemp;//命令组缓存,用于对比数据是否更改
        string panelFlag = "MCPanel";
        string cbox = "cbox";
        string tbox = "tbox";
        string btn = "btn";
        Panel panel1;//操作区域
        Button btnSave;//保存按钮
        Button btnRead;//读取按钮
        CheckBox cboxMCCircle;//循环Checkbox
        PortControl _portControl;//串口控制
        RadioButton rbAll;
        RadioButton rbSel;

        public MultiControl(MultiCommands multicommands)
        {
            MultiCommands = multicommands;
        }
        public MultiControl(int multiCount, Panel container, PortControl portControl)
        {
            _portControl = portControl;
            MultiCommands = new MultiCommands();
            atCommands = MultiCommands.Commands;
            MultiCommands.Circle = false;
            MultiCommands.CircleTime = 1000;
            MultiCommands.Count = multiCount;
            atCommands = new List<ATCommand>();
            for (int i = 0; i < MultiCommands.Count; i++)
            {
                ATCommand atCommand = new ATCommand();
                atCommand.Index = i;
                atCommands.Add(atCommand);
            }
            //atCommandsTemp = atCommands;
            copyCommand();
            panel1 = container;
            panel1.Scroll += Panel1_Scroll;
            panel1.MouseMove += Panel1_MouseMove;
            PanelAddItems(panel1);

            btnSave = panel1.FindForm().Controls.Find("btnMCPDSave", true)[0] as Button;
            btnRead = panel1.FindForm().Controls.Find("btnMCPDRead", true)[0] as Button;
            cboxMCCircle = panel1.FindForm().Controls.Find("cboxMCCircle", true)[0] as CheckBox;
            cboxMCCircle.Click += CboxMCCircle_Click;
            btnSave.Click += BtnSave_Click;
            btnRead.Click += BtnRead_Click;
            Button btnMCClear = panel1.FindForm().Controls.Find("btnMCClear", true)[0] as Button;
            btnMCClear.Click += BtnMCClear_Click;

            Button btnAddItem = panel1.FindForm().Controls.Find("btnMCAddOne", true)[0] as Button;
            Button btnSubItem = panel1.FindForm().Controls.Find("btnMCSubOne", true)[0] as Button;
            btnAddItem.Click += BtnAddItem_Click;
            btnSubItem.Click += BtnSubItem_Click;

            rbAll = panel1.FindForm().Controls.Find("rbAll", true)[0] as RadioButton;
            rbSel = panel1.FindForm().Controls.Find("rbSelected", true)[0] as RadioButton;
        }



        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            bool PanelFocused = false;
            if (panel1.Controls.Count > 0)
            {
                foreach (Control c in panel1.Controls)
                {
                    if (c.Focused)
                    {
                        PanelFocused = true;
                        break;
                    }
                }
            }
            if (!PanelFocused)
            {
                panel1.Focus();
            }
        }

        private void Panel1_Scroll(object sender, ScrollEventArgs e)
        {
            //panel1.AutoScrollPosition = new Point(0, e.NewValue);
            //Console.WriteLine("SCROLL_LOCATION"+ panel1.AutoScrollPosition);
        }
        Point newPoint = new Point(0, 0);
        //减少命令行
        private void BtnSubItem_Click(object sender, EventArgs e)
        {
            newPoint = panel1.AutoScrollPosition;
            SubOneItem();
        }
        //添加命令行
        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            newPoint = panel1.AutoScrollPosition;
            AddOneItem();
        }

        /// <summary>
        /// 清空列表按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMCClear_Click(object sender, EventArgs e)
        {
            atCommands = new List<ATCommand>(20);
            for (int i = 0; i < atCommands.Capacity; i++)
            {
                ATCommand temp = new ATCommand();
                temp.Command = "";
                temp.HEX = false;
                temp.Note = "双击添加注释!!!";
                temp.Function = "";
                temp.Module = "";
                atCommands.Add(temp);
            }
            copyCommand();
            GroupBox groupbox = panel1.FindForm().Controls.Find("gboxMCL", true)[0] as GroupBox;
            groupbox.Text = "多条指令";
            PanelAddItems(panel1);
        }
        /// <summary>
        /// 循环发送所有存在的命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void CboxMCCircle_Click(object sender, EventArgs e)
        {
            TextBox tboxTimes = panel1.FindForm().Controls.Find("tboxTimes", true)[0] as TextBox;
            int CircleTime = int.Parse((panel1.FindForm().Controls.Find("tBoxMCCTime", true)[0] as TextBox).Text);
            double times = int.Parse(tboxTimes.Text);
            if (cboxMCCircle.Checked && CircleTime > 0 && times >= 0)
            {
                putTimesVisable(false);
                long step = 0;
                while (true)
                {
                    Application.DoEvents();
                    step++;
                    int i = 0;
                    int j = 0;
                    foreach (ATCommand atcommand in atCommands)
                    {
                        if (rbSel.Checked )
                        {
                            if( atcommand.HEX)
                                j += 1;
                            if (atcommand.Index == atCommands.Count - 1&&j==0)
                            {
                                cboxMCCircle.Checked = false;
                                putTimesVisable(true);
                                return;
                            }
                        }
                        if (atcommand.Command == null || atcommand.Command.Equals(""))
                        {
                            i+=1;
                            if (i == atCommands.Count) {
                                cboxMCCircle.Checked = false;
                                putTimesVisable(true);
                                return;
                            }
                            continue;
                        }
                        
                        //执行到指定次数,退出!!!
                        if (step > times && times != 0)
                        {
                            cboxMCCircle.Checked = false;
                            tboxTimes.Text = times + "";
                            putTimesVisable(true);
                            return;
                        }
                        if (rbAll.Checked)
                        {
                            _portControl.portSend(atcommand.Command);
                        }
                        else if (rbSel.Checked && atcommand.HEX)
                        {
                            _portControl.portSend(atcommand.Command);
                        }
                        else
                        {
                            continue;
                        }
                        long startTime = (long)(DateTime.UtcNow.Ticks / 10000);
                        while (true)
                        {
                            Application.DoEvents();
                            long endTime = (long)(DateTime.UtcNow.Ticks / 10000);
                            if (endTime - startTime > CircleTime)
                                break;
                            if (!cboxMCCircle.Checked) {
                                //手动去掉循环执行,退出!!!
                                tboxTimes.Text = times+"";
                                putTimesVisable(true);
                                return;
                            }
                        }
                    }
                    if (times == 0)
                    {
                        tboxTimes.Text = times + step + "";
                    }
                    else {
                        tboxTimes.Text = times - step + "";
                    }
                  
                }
            }
        }

        private void putTimesVisable(bool flag) {
            (panel1.FindForm().Controls.Find("tBoxMCCTime", true)[0] as TextBox).Enabled = flag;
            (panel1.FindForm().Controls.Find("tboxTimes", true)[0] as TextBox).Enabled = flag;
            (panel1.FindForm().Controls.Find("btnMCAddOne", true)[0] as Button).Enabled = flag;
            (panel1.FindForm().Controls.Find("btnMCSubOne", true)[0] as Button).Enabled = flag;
        }

        bool ATRead = false;
        //命令读取按钮
        private void BtnRead_Click(object sender, EventArgs e)
        {
            if (atCommandsChanged())
            {
                DialogResult dresult = MessageBox.Show("内容已更改,是否进行保存", "警告", MessageBoxButtons.YesNo);
                if (dresult == DialogResult.Yes)
                {
                    BtnSave_Click(sender, e);
                    //return;
                }
                else
                    copyCommand();
            }
            Button btnRead = sender as Button;
            Form3 form = new Form3(ATRead);
            form.StartPosition = FormStartPosition.CenterParent;
            btnRead.FindForm().AddOwnedForm(form);
            Button btnCRead = form.Controls.Find("button1", true)[0] as Button;
            btnCRead.DialogResult = DialogResult.Yes;
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.Yes)
            {
                (btnRead.FindForm().Controls.Find("cboxMCCircle", true)[0] as CheckBox).Checked = false;
                (btnRead.FindForm().Controls.Find("cboxSendTime", true)[0] as CheckBox).Checked = false;
            }
            if (form.atCommands.Count > 0)
            {
                atCommands = form.atCommands;
                copyCommand();
                PanelAddItems(panel1);
                setGroupText(atCommands[0]);
            }
            else
            {
                GroupBox groupbox = panel1.FindForm().Controls.Find("gboxMCL", true)[0] as GroupBox;
                groupbox.Text = "多条指令";
            }

        }
        //命令保存按钮
        private void BtnSave_Click(object sender, EventArgs e)
        {
            Button BtnSave = sender as Button;
            Form3 form = new Form3(atCommands);
            if (BtnSave.Name == "btnMCPDRead")
            {
                if (atCommands[0].Module != "")
                {
                    form.ButtonWrite_Click();
                    return;
                }
                else
                {
                    copyCommand();
                }
            }
            else
            {
                form = new Form3(atCommands);
                BtnSave.FindForm().AddOwnedForm(form);
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog();
            }
            if (form._moduleList.Count > 0 && form.savedNum > -1)
            {
                setGroupText(form._moduleList[form.savedNum]);
                copyCommand();
            }
            else
            {
                //GroupBox groupbox = panel1.FindForm().Controls.Find("gboxMCL", true)[0] as GroupBox;
                //groupbox.Text = "多条指令";
            }
        }
        private void setGroupText(ModuleCommand module)
        {
            GroupBox groupbox = panel1.FindForm().Controls.Find("gboxMCL", true)[0] as GroupBox;
            if (module.Function != null)
            {
                groupbox.Text = module.Module + "----" + module.Function;
            }
            else
            {
                groupbox.Text = "多条指令";
            }
        }
        internal void AddOneItem()
        {

            ATCommand atcommand = new ATCommand();
            //atcommand.Index = atCommands.Count - 1;
            if (atCommands.Count < 100)
            {
                int index = atCommands.Count;
                if (tBoxFocused != null)
                {
                    index = Int32.Parse(tBoxFocused.Name.Replace(tbox + panelFlag, ""));
                    //tBoxFocused = null;
                    atcommand.Index = index;
                    ATCommand tempCommand = new ATCommand();
                    for (int i = index; i < atCommands.Count; i++)
                    {
                        tempCommand = atCommands[i];
                        atCommands[i] = atcommand;
                        atcommand = tempCommand;
                        atcommand.Index = i + 1;
                    }
                    atCommands.Add(atcommand);
                }
                else
                {
                    atcommand.Index = atCommands.Count - 1;
                    atCommands.Add(atcommand);
                }

                PanelAddItems();
            }
            else
            {
                return;
            }

        }
        private void SubOneItem()
        {
            if (atCommands.Count > 1)
            {
                int index = atCommands.Count;
                if (tBoxFocused != null)
                {
                    index = Int32.Parse(tBoxFocused.Name.Replace(tbox + panelFlag, ""));
                    //tBoxFocused = null;
                    atCommands.RemoveAt(index);
                    for (int i = 0; i < atCommands.Count; i++)
                    {
                        atCommands[i].Index = i;
                    }
                }
                else
                    atCommands.RemoveAt(atCommands.Count - 1);
                PanelAddItems();
            }
        }
        private void PanelAddItems()
        {
            PanelAddItems(panel1);
            if (tBoxFocused == null)
            {
                panel1.AutoScrollPosition = new Point(0, panel1.VerticalScroll.Maximum);
            }
            else {
                panel1.AutoScrollPosition = new Point(0, -newPoint.Y);
                tBoxFocused = null;
            }
        }
        private Panel PanelAddItems(Panel container)
        {
            List<ATCommand> atcommands = atCommands;
            container.Controls.Clear();
            int length = atcommands.Count;
            for (int i = 0; i < length; i++)
            {
                TextBox textbox = new TextBox();
                CheckBox checkBox = new CheckBox();
                Button button = new Button();
                //复选框定义
                checkBox.Name = cbox + panelFlag + i;
                checkBox.Width = 20;
                //checkBox.Height = 40;
                checkBox.Location = new Point(3, 30 * i + 3);
                checkBox.Checked = atcommands[i].HEX;
                checkBox.TabIndex = 0;
                checkBox.TabStop = false;
                //文本框定义
                textbox.Name = tbox + panelFlag + i;
                textbox.Width = 200;
                textbox.Enabled = true;
                //textbox.Height = 40;
                textbox.Location = new Point(40, 30 * i + 3);
                textbox.Text = atcommands[i].Command;
                textbox.TabIndex = i;
                //按钮定义
                button.Name = btn + panelFlag + i;
                button.Width = 30;
                //button.Height = 40;
                button.Location = new Point(260, 30 * i + 3);
                button.Text = (i + 1) + "";
                button.TabStop = false;
                button.TabIndex = 0;
                //为控件添加事件
                textbox.TextChanged += new EventHandler(textboxTextChange);
                textbox.MouseHover += Textbox_MouseHover;
                textbox.DoubleClick += Textbox_DoubleClick;
                textbox.KeyDown += Textbox_KeyDown;
                textbox.Enter += Textbox_Enter;
                textbox.Leave += Textbox_Leave;

                button.Click += new EventHandler(btnClick);
                checkBox.Click += CheckBox_Click;

                //添加控件到容器
                container.Controls.Add(checkBox);
                container.Controls.Add(textbox);
                container.Controls.Add(button);
            }
            panel1 = container;
            panel1.FindForm().Controls.Find("tboxMCLCount", true)[0].Text = length + "";

            return container;
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        private static extern IntPtr GetFocus();
        private void Textbox_Leave(object sender, EventArgs e)
        {
            Control focusedControl = null;

            try
            {
                IntPtr focusedHandle = GetFocus();

                if (focusedHandle != IntPtr.Zero)
                {
                    focusedControl = Control.FromChildHandle(focusedHandle);
                    //Console.WriteLine("leave:" + focusedControl.Name);
                    if (!(focusedControl.Name == "btnMCAddOne" || focusedControl.Name == "btnMCSubOne"))
                    {
                        tBoxFocused = null;
                        //Console.WriteLine("leave:" + "null");
                    }
                }
            }
            catch { }
        }

        TextBox tBoxFocused;
        /// <summary>
        /// 激活控件,设置选择控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Textbox_Enter(object sender, EventArgs e)
        {
            tBoxFocused = (TextBox)sender;
            //Console.WriteLine(tBoxFocused.Name);
        }

        /// <summary>
        /// 命令框回车发送命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox tbox = sender as TextBox;
                int index = int.Parse(tbox.Name.Replace("tboxMCPanel", ""));
                Button btn = panel1.Controls.Find("btnMCPanel" + index, true)[0] as Button;
                btnClick(btn, e);
            }
        }

        //设置HEX
        private void CheckBox_Click(object sender, EventArgs e)
        {
            CheckBox checkbox = sender as CheckBox;
            int index = int.Parse(checkbox.Name.Replace(cbox + panelFlag, ""));
            atCommands[index].HEX = checkbox.Checked;
        }

        int NowIndex;
        Form2 NoteSettingForm;
        Button btnNoteSave;
        Button btnNoteCancel;
        TextBox tBoxNote;
        //双击命令栏,添加注释
        private void Textbox_DoubleClick(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            NowIndex = int.Parse(textBox.Name.Replace(tbox + panelFlag, ""));
            NoteSettingForm = new Form2(atCommands[NowIndex].Note);
            NoteSettingForm.Text = (NowIndex + 1) + ":" + atCommands[NowIndex].Command;
            NoteSettingForm.Location = setNoteFormLocation(textBox);
            Label label = NoteSettingForm.Controls.Find("label1", true)[0] as Label;
            tBoxNote = NoteSettingForm.Controls.Find("textBox1", true)[0] as TextBox;
            btnNoteSave = NoteSettingForm.Controls.Find("button1", true)[0] as Button;
            btnNoteCancel = NoteSettingForm.Controls.Find("button2", true)[0] as Button;
            btnNoteSave.Text = "保存";
            btnNoteCancel.Text = "取消";
            label.Text = "请输入注释";
            btnNoteSave.Click += NoteSave_Click;
            btnNoteCancel.Click += BtnNoteCancel_Click;
            //textBox.FindForm().AddOwnedForm(NoteSettingForm);
            NoteSettingForm.ShowDialog();
            //Console.WriteLine("Form1:" + textBox.FindForm().Location.ToString() + "------" + NoteSettingForm.Location.ToString());
        }
        //设置添加注释对话框的位置
        private Point setNoteFormLocation(System.Windows.Forms.Control c)
        {
            Point location = new Point();
            int x1 = c.Location.X;
            int y1 = c.Location.Y;
            int x2 = c.FindForm().Controls.Find("gboxMCCS", true)[0].Location.X;
            int y2 = c.FindForm().Controls.Find("gboxMCCS", true)[0].Location.Y;
            int x3 = c.FindForm().Controls.Find("gboxMCL", true)[0].Location.X;
            int y3 = c.FindForm().Controls.Find("gboxMCL", true)[0].Location.Y;
            int x4 = c.FindForm().Location.X;
            int y4 = c.FindForm().Location.Y;
            int x5 = c.FindForm().Controls.Find("panel1", true)[0].Location.X;
            int y5 = c.FindForm().Controls.Find("panel1", true)[0].Location.Y;
            location.X = x1 + x2 + x3 + x4 + y5;
            location.Y = y1 + y2 + y3 + y4 + y5 + 55;
            return location;
        }
        //注释对话框的取消操作
        private void BtnNoteCancel_Click(object sender, EventArgs e)
        {
            NoteSettingForm.Close();
        }
        //注释对话框的保存操作
        private void NoteSave_Click(object sender, EventArgs e)
        {
            atCommands[NowIndex].Note = tBoxNote.Text.Trim() == "" ? atCommands[NowIndex].Note : tBoxNote.Text.Trim();
            NoteSettingForm.Close();
        }
        //指针移动到命令输入框显示注释
        ToolTip toolTip = new ToolTip();
        private void Textbox_MouseHover(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            int index = int.Parse(textBox.Name.Replace(tbox + panelFlag, ""));
            string toolTipText = atCommands[index].Note;

            toolTip.ReshowDelay = 1000;
            toolTip.ShowAlways = false;
            toolTip.IsBalloon = false;
            toolTip.SetToolTip(textBox, toolTipText);
        }
        //当命令输入框的文字改变时保存指令
        private void textboxTextChange(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            int index = int.Parse(textbox.Name.Replace(tbox + panelFlag, ""));
            atCommands[index].Command = textbox.Text.Trim();
        }
        //命令的发送按钮
        public void btnClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int index = int.Parse(button.Name.Replace("btnMCPanel", ""));
            TextBox textbox = panel1.Controls.Find("tboxMCPanel" + index, true)[0] as TextBox;
            atCommands[index].Command = textbox.Text;
            _portControl.portSend(textbox.Text);
        }

        private bool atCommandsChanged()
        {
            if (atCommands.Count != atCommandsTemp.Count)
                return true;
            else
            {
                for (int i = 0; i < atCommands.Count; i++)
                {
                    if (!(atCommandsTemp[i].Command == atCommands[i].Command))
                    {
                        return true;
                    }

                }
                return false;
            }
        }

        private void copyCommand()
        {
            atCommandsTemp = new List<ATCommand>();
            for (int i = 0; i < atCommands.Count; i++)
            {
                ATCommand temp = new ATCommand();
                temp.Command = atCommands[i].Command;
                temp.Function = atCommands[i].Function;
                temp.HEX = atCommands[i].HEX;
                temp.Index = atCommands[i].Index;
                temp.Module = atCommands[i].Module;
                temp.Note = atCommands[i].Note;
                atCommandsTemp.Add(temp);
            }
        }
    }
}