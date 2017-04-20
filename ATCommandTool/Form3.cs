using ATCommandTool.Controlers;
using ATCommandTool.Mode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCommandTool
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        //

        public List<ATCommand> atCommands = new List<ATCommand>();
        public List<ModuleCommand> _moduleList = new List<ModuleCommand>();
        int checkedNum = 0;
        public int savedNum=-1;
        public Form3(bool writeorread)
        {
            InitializeComponent();
            this.FormClosed += Form3_FormClosed;
            XMLUnit xmlUnit = new XMLUnit();
            _moduleList = xmlUnit.QueryModuleList();


            if (writeorread)
            {
                button1.Text = "保存";
                button1.Click += ButtonWrite_Click;
                button3.Click += btnAddMoudle;
                //读取列表
            }
            else
            {
                this.Text = "读取";
                button1.Text = "读取";
                button1.Click += ButtonRead_Click;
                button3.Visible = false;
                button4.Visible = false;
                panel1.Size = new Size(panel1.Size.Width, 260);
                panel2.Size = new Size(panel2.Size.Width, 260);
                //读取列表
            }
            AddModuleRB(_moduleList, 0);
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            XMLUnit xmlunit = new XMLUnit();
            List<ATCommand> acs = xmlunit.XMLUnitRead();
            if (acs.Count <= 0)
            {
                xmlunit.XMLUnitWrite(new ModuleCommand(), acs);
            }
        }


        public Form3(List<ATCommand> CommandList)
        {

            atCommands = CommandList;
            XMLUnit xmlUnit = new XMLUnit();
            _moduleList = xmlUnit.QueryModuleList();
            for (int i = 0; i < _moduleList.Count; i++) {
                if (_moduleList[i].Function == atCommands[0].Function && _moduleList[i].Module == atCommands[0].Module) {
                    checkedNum = i;
                    break;
                }
            }
            InitializeComponent();
            this.FormClosed += Form3_FormClosed;
            button1.Text = "保存";
            button1.Click += ButtonWrite_Click;
            button3.Click += btnAddMoudle;
            button4.Click += btnAddMoudle;
            AddModuleRB(_moduleList, checkedNum);
            this.Text = "保存";
        }

        bool moduleAddFlag = false;
        //添加模块/功能按钮点击事件
        private void btnAddMoudle(object sender, EventArgs e)
        {

            Button btn = sender as Button;
            Form2 form = new Form2();
            form.StartPosition = FormStartPosition.CenterParent;
            this.AddOwnedForm(form);
            Label form2Label1 = form.Controls.Find("label1", true)[0] as Label;
            Button btnModuleSave = form.Controls.Find("button1", true)[0] as Button;
            Button btnModuleCancel = form.Controls.Find("button2", true)[0] as Button;
            btnModuleSave.Text = "保存";
            btnModuleCancel.Text = "取消";
            btnModuleSave.Click += Form2Btn_Click;
            btnModuleCancel.Click += BtnModuleCancel_Click;
            //添加模块
            if (btn.Name.Equals(button3.Name))
            {
                form.Text = "模块添加";
                form2Label1.Text = "请输入需要添加的模块名称";
                moduleAddFlag = true;
            }
            if (btn.Name.Equals(button4.Name))
            {
                form.Text = "功能添加";
                form2Label1.Text = "请输入需要添加的功能名称";
                moduleAddFlag = false;
            }
            form.ShowDialog();
        }

        private void BtnModuleCancel_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.FindForm().Close();
        }

        //添加模块/功能列表界面的按钮点击事件
        private void Form2Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            TextBox tbox = btn.FindForm().Controls.Find("textBox1", true)[0] as TextBox;
            string tboxText = tbox.Text.Trim();
            ModuleCommand MC = new ModuleCommand();
            //添加模块界面保存
            if (btn.Name.Equals("button1") && moduleAddFlag)
            {

                if (!tboxText.Equals(""))
                {
                    MC.Module = tboxText;
                    foreach (ModuleCommand temp in _moduleList) {
                        if (temp.Module.ToUpper().Equals(MC.Module.ToUpper())) {
                            MessageBox.Show("模块" + MC.Module + "已存在.", "警告!!!", MessageBoxButtons.OK);
                            return;
                        }
                    }
                    _moduleList.Add(MC);
                    AddModuleRB(_moduleList, _moduleList.Count - 1);
                }
                btn.FindForm().Close();
            }
            //添加功能界面保存
            if (btn.Name.Equals("button1") && !moduleAddFlag)
            {
                if (!tboxText.Equals(""))
                {
                    MC.Module = _moduleList[checkedNum].Module;
                    MC.Function = tboxText;
                    
                    if (_moduleList[checkedNum].Function == null)
                    {
                        _moduleList[checkedNum].Function = tboxText;
                    }
                    else
                    {
                        foreach (ModuleCommand temp in _moduleList)
                        {
                            if (temp.Module.ToUpper().Equals(MC.Module.ToUpper())&&temp.Function.ToUpper().Equals(MC.Function.ToUpper()))
                            {
                                MessageBox.Show("模块" + MC.Module + "下的功能"+MC.Function+"已存在.", "警告!!!", MessageBoxButtons.OK);
                                return;
                            }
                        }
                        _moduleList.Add(MC);
                    }
                    AddModuleRB(_moduleList, _moduleList.Count - 1);
                }
                btn.FindForm().Close();
            }
            if (btn.Name.Equals("button2"))
            {
                btn.FindForm().Close();
            }
        }
        /// <summary>
        /// 添加模版列表,并指定选中某一个
        /// </summary>
        /// <param name="moduleList">模块,功能列表</param>
        /// <param name="checkNum">指定选中模版的序列</param>
        private void AddModuleRB(List<ModuleCommand> moduleList, int checkNum)
        {
            if (moduleList.Count > 0)
            {
                checkedNum = checkNum;
                panel1.Controls.Clear();
                panel2.Controls.Clear();
                int step = 0;
                for (int i = 0; i < moduleList.Count; i++)
                {
                    RadioButton rb = IRadioButton("rbm", moduleList[i].Module,step);
                    if (panel1.Controls.Find("rbm" + moduleList[i].Module, true).Length == 0)
                    {
                        panel1.Controls.Add(rb);
                        step++;
                    }
                }
                RadioButton checkRB = panel1.Controls.Find("rbm" + moduleList[checkNum].Module, true)[0] as RadioButton;

                checkRB.Checked = true;
                moduleCheckedText = checkRB.Text;
                AddFunctionRB(moduleList[checkNum], moduleList);
            }
            return;
        }



        private void AddFunctionRB(ModuleCommand module, List<ModuleCommand> moduleList)
        {
            if (module.Function != "")
            {
                int step = 0;
                for (int i = 0; i < moduleList.Count; i++)
                {
                    if (moduleList[i].Module.Equals(module.Module))
                    {
                        if (moduleList[i].Function != null)
                        {
                            RadioButton rb = IRadioButton("rbf", moduleList[i].Function, step);
                            rb.MouseClick += Rb_MouseClick;
                            if (!moduleList[i].Function.Equals(""))
                            {
                                panel2.Controls.Add(rb);
                                step++;
                            }
                        }
                    }
                }
                RadioButton checkRB = panel2.Controls.Find("rbf" + module.Function, true)[0] as RadioButton;
                checkRB.Checked = true;
                functionCheckedText = checkRB.Text;
            }
        }
        long startTime;
        private void Rb_MouseClick(object sender, MouseEventArgs e)
        {
            if (startTime == 0)
                startTime = (long)DateTime.UtcNow.Ticks / 10000;
            else {
                long endTime = (long)DateTime.UtcNow.Ticks / 10000;
                if (endTime - startTime < 500)
                {
                    RadioButton rb = sender as RadioButton;
                    //处理双击事件
                    Form2 form = new Form2((sender as RadioButton).Text);
                    Label label = form.Controls.Find("label1", true)[0] as Label;
                    //label.Text = _moduleList[checkedNum].Module;
                    ModuleCommand oldM = _moduleList[checkedNum];
                    ModuleCommand newM = new ModuleCommand();
                    form.StartPosition = FormStartPosition.CenterParent;
                    TextBox tBoxNote = form.Controls.Find("textBox1", true)[0] as TextBox;
                    Button btnSave = form.Controls.Find("button1", true)[0] as Button;
                    Button btnCancel = form.Controls.Find("button2", true)[0] as Button;
                    tBoxNote.TextChanged += TBoxNote_TextChanged;

                    btnSave.DialogResult = DialogResult.Yes;
                    btnCancel.DialogResult = DialogResult.No;
                    DialogResult result = form.ShowDialog();
                    if (result == DialogResult.Yes)
                    {
                        if (rb.Name.StartsWith("rbf")) {
                            newM = new ModuleCommand(oldM.Module, newFunction==null?oldM.Function:newFunction);
                            foreach (ModuleCommand mb in _moduleList) {
                                if (mb.Function.ToUpper() == newM.Function.ToUpper() && mb.Module.ToUpper() == newM.Module.ToUpper()) {
                                    DialogResult RESULT = MessageBox.Show("模块" + mb.Module + "下的功能" + mb.Function + "已存在.", "警告!!!", MessageBoxButtons.OK);
                                    return;
                                }
                            }
                            XMLUnit xml = new XMLUnit();
                            xml.ChangeModultList(oldM, newM);
                            _moduleList = xml.QueryModuleList();
                            AddModuleRB(_moduleList, checkedNum);
                        }
                    }
                    else {
                        Console.WriteLine("不保存列表");
                    }
                }
                startTime = 0;
            }
            
        }
        string newFunction;
        private void TBoxNote_TextChanged(object sender, EventArgs e)
        {
            newFunction = (sender as TextBox).Text;
        }

        private void Rb_Click(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Name.StartsWith("rbm"))
            {
                moduleCheckedText = rb.Text;
                for (int i = 0; i < _moduleList.Count; i++)
                {
                    if (_moduleList[i].Module == moduleCheckedText)
                    {
                        checkedNum = i;
                        AddModuleRB(_moduleList, checkedNum);
                        //Console.WriteLine("" + _moduleList[checkedNum].Module);
                        return;
                    }
                }
            }
            if (rb.Name.StartsWith("rbf"))
            {
                functionCheckedText = rb.Text;
                for (int i = 0; i < _moduleList.Count; i++)
                {
                    if (_moduleList[i].Module == moduleCheckedText && _moduleList[i].Function == functionCheckedText)
                    {
                        checkedNum = i;
                        //Console.WriteLine("" + _moduleList[checkedNum].Module + ":" + _moduleList[checkedNum].Function);
                        return;
                    }
                }
            }

        }

        private RadioButton IRadioButton(string nameBegin,string text,int step) {
            RadioButton rb = new RadioButton();
            rb.Text = text;
            rb.Name = nameBegin + text;
            rb.Margin = new Padding(0);
            rb.Location = new Point(3, (step * 20));
            rb.Size = new Size(panel1.Width, 16);
            rb.AutoEllipsis = true;
            rb.AutoSize = false;
            rb.Click += Rb_Click;
            return rb;
        }
        string moduleCheckedText;
        string functionCheckedText;
        private void ButtonRead_Click(object sender, EventArgs e)
        {
            ModuleCommand module = new ModuleCommand(moduleCheckedText, functionCheckedText);
            XMLUnit xmlUnit = new XMLUnit();
            atCommands = xmlUnit.XMLUnitRead(module);
            this.Close();
        }

        public void ButtonWrite_Click() {
            object sender = button1;
            EventArgs e = new EventArgs();
            ButtonWrite_Click(sender,e);
        }
        private void ButtonWrite_Click(object sender, EventArgs e)
        {
            //string messAge = "是否确定将内容保存到:" + _moduleList[checkedNum].Module + "的\""
            //        + _moduleList[checkedNum].Function + "\"功能命令列表";
            //string caption = "警告!!!!";
            //MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //DialogResult result = MessageBox.Show(messAge, caption, buttons);
            //if (result == DialogResult.Yes)
            //{
                XMLUnit xmlUnit = new XMLUnit();
            if (_moduleList.Count > 0 && _moduleList[checkedNum].Function != "")
            {
                xmlUnit.XMLUnitWrite(_moduleList[checkedNum], atCommands);
                this.Close();
            }
            savedNum = checkedNum;
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_moduleList.Count > 0)
            {
                string messAge = "是否确定删除模版:" + _moduleList[checkedNum].Module + "的\""
                    + _moduleList[checkedNum].Function + "\"功能命令列表";
                string caption = "警告!!!!";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(messAge, caption, buttons);
                if (result == DialogResult.Yes)
                {
                    XMLUnit xmlUnit = new XMLUnit();
                    xmlUnit.DelModuleList(_moduleList[checkedNum]);
                    _moduleList.RemoveAt(checkedNum);
                    checkedNum = 0;
                    if (_moduleList.Count > 0)
                    {
                        AddModuleRB(_moduleList, checkedNum);
                    }
                    else
                    {
                        panel1.Controls.Clear();
                        panel2.Controls.Clear();
                    }
                }
                else
                {
                    return;
                }
            }
        }
        //radiobutton数据绑定
    }
}
