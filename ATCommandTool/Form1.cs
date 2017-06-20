
using ATCommandTool.Controlers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATCommandTool
{
    public partial class Form1 : Form
    {
        PortControl portControl;
        Form5 form5 = new Form5();
        ListBox lstBoxRe;
        int thisX;
        int thisY;
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
            portControl = new PortControl(gboxPort);
            multiCommands();
            portControl.refurbishPortNme(cbboxPort);//串口列表更新
            portControl.refubishBaudRate(cbboxBaud); //波特率添加
            form5.TopMost = true;
            lstBoxRe = form5.listBox1;
            lstBoxRe.Width = this.tboxSend.Width;
            lstBoxRe.KeyPress += LstBoxRe_KeyPress;
            lstBoxRe.KeyDown += LstBoxRe_KeyDown;
            lstBoxRe.DoubleClick += LstBoxRe_DoubleClick;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            thisX = Size.Width;
            thisY = Size.Height;
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("是否退出串口工具", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                e.Cancel = false;
                portControl.closePort();
                this.Dispose();
                this.Close();
            }
            else
            {
                e.Cancel = true;
            }
        }

        MultiControl multiControl;
        /// <summary>
        /// 对多条指令的添加设置
        /// </summary>
        private void multiCommands()
        {
            //界面的控件的更改和添加(atCommand);
            tboxMCLCount.ReadOnly = true;
            multiControl = new MultiControl(int.Parse(tboxMCLCount.Text), panel1, portControl);
        }
        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (btnOpen.Text.Equals("打开串口"))
                portControl.OpenPort();
            else
                portControl.closePort();
        }
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            string text = tboxSend.Text.Trim();
            portControl.portSend(text);
            //makeAdd(text, addToEnd);
        }
        public void makeAdd(string str, addTo doAdd)
        {
            if (str.EndsWith("\r\n"))
                str = str.Replace("\r\n", "");
            doAdd(str);
        }
        public delegate void addTo(string str);
        //添加一个到尾部
        public void addToEnd(string str)
        {
            if (atTemp.Count >= maxTemp)
                atTemp.RemoveAt(0);
            if (atTemp.Contains(str))
            {
                atTemp.RemoveAt(atTemp.IndexOf(str));
            }
            atTemp.Add(str);
        }
        /// <summary>
        /// 发送成功的AT指令
        /// </summary>
        public static List<string> atTemp = new List<string> { };
        static int maxTemp = 10000;
        /// <summary>
        /// 定时发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboxSendTime_Click(object sender, EventArgs e)
        {

            if (cboxSendTime.Checked)
            {
                if (tboxSend.Text.Trim() != null)
                {
                    portControl.portSend(tboxSend.Text.Trim());
                    //mySleep(500);
                    //portControl.portSend(tboxData.Text + "\u001a");

                    long startTime = (long)DateTime.UtcNow.Ticks / 10000;
                    long time = long.Parse(tboxSendTime.Text);
                    long step = 1;
                    while (true)
                    {
                        Application.DoEvents();//死循环时界面不卡顿
                        long endTime = (long)DateTime.UtcNow.Ticks / 10000;

                        if (endTime - startTime > time * step)
                        {
                            Application.DoEvents();
                            portControl.portSend(tboxSend.Text.Trim());
                            //mySleep(500);
                            //portControl.portSend(tboxData.Text + "\u001a");
                            step++;
                        }
                        if (!cboxSendTime.Checked)
                        {
                            return;
                        }
                    }
                }
            }
        }

        private void mySleep(long time)
        {
            long startTime = (long)DateTime.UtcNow.Ticks / 10000;
            while (true)
            {
                Application.DoEvents();//死循环时界面不卡顿
                long endTime = (long)DateTime.UtcNow.Ticks / 10000;

                if (endTime - startTime > time)
                {
                    return;
                }
            }
        }

        /// <summary>
        /// 定时发送的时间值的判定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tboxSendTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsNumber(e.KeyChar)) || e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                tboxShow.AppendText("请输入0-9的数字");
            }
        }
        /// <summary>
        /// 更新串口名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefur_Click(object sender, EventArgs e)
        {
            portControl.closePort();
            portControl.refurbishPortNme(cbboxPort);
        }
        /// <summary>
        /// 串口选择更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbboxPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            portControl.closePort();
            portControl.isOpen();
        }
        /// <summary>
        /// 发送框按键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tboxSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend_Click(sender, e);
            }
            if (e.KeyCode == Keys.Down && lstboxIsShow)
            {
                form5.listBox1.Focus();
                form5.listBox1.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// 特殊发送(短信,ftp,tcp)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tboxShow_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.ComponentModel.CancelEventArgs e1 = new System.ComponentModel.CancelEventArgs();
            contextMenuStrip1_Opening(sender, e1);
            //e.Handled = true;
            //keyChars.Add(e.KeyChar);
            //复制到剪切板CTRL+C
            if (e.KeyChar == 3)
            {
                RightClik_C_Click(sender, e);
                e.Handled = true;
            }
            //粘贴到文本框CTRL+V
            if (e.KeyChar == 22)
            {
                RightClik_V_Click(sender, e);
                e.Handled = true;
            }
            //CTRL+A
            if (e.KeyChar == 1)
            {
                RightClik_A_Click(sender, e);
                e.Handled = true;
            }
            //CTRL+D
            if (e.KeyChar == 4)
            {
                RightClik_D_Click(sender, e);
                e.Handled = true;
            }
            //CTRL+S
            if (e.KeyChar == 19)
            {
                RightClik_S_Click(sender, e);
                e.Handled = true;
            }
            if (!e.Handled)
            {
                portControl.portSend(Encoding.Default.GetString(Encoding.Default.GetBytes(new char[] { e.KeyChar })), false);
                e.Handled = true;
            }

        }

        private void tboxTimes_Leave(object sender, EventArgs e)
        {
            TextBox tbox = sender as TextBox;
            if (tbox.Text == "" || long.Parse(tbox.Text) == 0)
            {
                if (tbox.Name == "tBoxMCCTime")
                    (sender as TextBox).Text = "1";
                else if (tbox.Name == "tboxTimes")
                    (sender as TextBox).Text = "0";
            }
        }

        private void RightClik_A_Click(object sender, EventArgs e)
        {
            if (RightClik_A.Enabled)
            {
                tboxShow.Focus();
                tboxShow.SelectAll();
            }
        }

        private void RightClik_C_Click(object sender, EventArgs e)
        {
            tboxShow.Focus();
            if (this.tboxShow.SelectedText != "")
            {
                Clipboard.Clear();
                Clipboard.SetDataObject(this.tboxShow.SelectedText);
            }
        }

        private void RightClik_V_Click(object sender, EventArgs e)
        {
            tboxShow.Focus();
            string text = Clipboard.GetText();
            if (text != "")
            {
                portControl.portSend(text, false);
            }
        }
        /// <summary>
        /// 对右键的全选,保存,清空按钮的可操作判断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int lblS_int = int.Parse(lblS.Text.Substring(2));
            int lblT_int = int.Parse(lblT.Text.Substring(2));
            int lblR_int = int.Parse(lblR.Text.Substring(2));
            int all = lblS_int + lblT_int + lblR_int;
            if (tboxShow.Text.Length == 0 && all == 0)
            {

                RightClik_A.Enabled = false;
                RightClik_D.Enabled = false;
                RightClik_S.Enabled = false;
            }
            else
            {
                RightClik_A.Enabled = true;
                RightClik_D.Enabled = true;
                RightClik_S.Enabled = true;
            }
        }

        private void RightClik_D_Click(object sender, EventArgs e)
        {
            if (RightClik_D.Enabled)
            {
                tboxShow.Clear();
                lblR.Text = "R:0";
                lblS.Text = "S:0";
                lblT.Text = "T:0";
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.ComponentModel.CancelEventArgs e1 = new System.ComponentModel.CancelEventArgs();
            contextMenuStrip1_Opening(sender, e1);
            //CTRL+A
            if (e.KeyChar == 1)
            {
                RightClik_A_Click(sender, e);
                e.Handled = true;
            }
            //CTRL+D
            if (e.KeyChar == 4)
            {
                RightClik_D_Click(sender, e);
                e.Handled = true;
            }
            //CTRL+S
            if (e.KeyChar == 19)
            {
                RightClik_S_Click(sender, e);
                e.Handled = true;
            }
        }
        private void LstBoxRe_DoubleClick(object sender, EventArgs e)
        {
            if (lstBoxRe.SelectedItem != null)
            {
                tboxSend.Text = lstBoxRe.SelectedItem.ToString();
                tboxSend.Focus();
                tboxSend.SelectionStart = lstBoxRe.Text.Length;
            }
        }

        private void LstBoxRe_KeyDown(object sender, KeyEventArgs e)
        {
            Keys keys = e.KeyCode;
            if (keys == Keys.Enter)
            {
                if (lstBoxRe.SelectedItem != null)
                {
                    tboxSend.Text = lstBoxRe.SelectedItem.ToString();
                    tboxSend.Focus();
                    tboxSend.SelectionStart = tboxSend.Text.Length;
                }
                e.Handled = true;
            }
            if (keys == Keys.Back)
            {
                if (lstBoxRe.SelectedItem != null)
                {
                    tboxSend.Text = tboxSend.Text.Substring(0, tboxSend.Text.Length - 1);
                    tboxSend.Focus();
                    tboxSend.SelectionStart = tboxSend.Text.Length;
                }
                e.Handled = true;
            }
            if (keys == Keys.Delete)
            {
                if (lstBoxRe.SelectedItem != null)
                {
                    atTemp.Remove(lstBoxRe.SelectedItem.ToString());
                    lstBoxRe.Items.Remove(lstBoxRe.SelectedItem.ToString());

                    tboxSend_TextChanged(new object(), new EventArgs());
                    if (lstBoxRe.Items.Count > 0)
                    {
                        form5.listBox1.Focus();
                        form5.listBox1.SelectedIndex = 0;
                    }
                }
                //atTemp.ToString();
            }
        }

        private void LstBoxRe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (32 <= e.KeyChar && e.KeyChar <= 127)
            {
                tboxSend.Focus();
                //e.Handled = false;
                tboxSend.Text += e.KeyChar;
                tboxSend.SelectionStart = tboxSend.Text.Length;
            }
        }
        bool lstboxIsShow = false;
        private void tboxSend_TextChanged(object sender, EventArgs e)
        {
            string searchText = tboxSend.Text;
            form5.listBox1.Items.Clear();
            if (tboxSend.Text != "")
            {
                for (int i = atTemp.Count - 1; i >= 0; i--)
                {
                    if (atTemp[i].ToUpper().StartsWith(searchText.ToUpper()))
                    {
                        if (form5.listBox1.Items.Count < 5)
                            form5.listBox1.Items.Add(atTemp[i]);
                    }
                }
            }
            if (form5.listBox1.Items.Count > 0)
            {
                if (form5.listBox1.Items.Count == 1)
                {
                    form5.listBox1.Height = 30;
                }
                else
                    form5.listBox1.Height = (form5.listBox1.Font.Height) * (form5.listBox1.Items.Count) + 3;
                setListFromLocation();
                form5.Show();
                lstboxIsShow = true;
                tboxSend.Focus();
            }
            else
            {
                form5.Hide();
                lstboxIsShow = false;
            }
        }
        /// <summary>
        /// 命令提示窗口的位置设置
        /// </summary>
        private void setListFromLocation()
        {
            Point point = new Point(tboxSend.Location.X + tboxSend.Parent.Location.X + this.Location.X + 10,
                tboxSend.Location.Y + gboxSend.Location.Y + gboxPort.Location.Y + 371 + this.Location.Y + 50);
            System.Drawing.Rectangle rec = Screen.GetWorkingArea(this);
            int SH = rec.Height;
            int SW = rec.Width;
            if (point.Y + form5.Height > SH)
            {
                point.Y = point.Y - form5.Height - 30;
            }
            form5.Location = point;
            form5.Height = form5.listBox1.ItemHeight * form5.listBox1.Items.Count + 6;
            form5.Width = tboxSend.Width;
        }
        private void Form1_Move(object sender, EventArgs e)
        {
            setListFromLocation();
        }
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        /// <summary>
        /// 主窗口被激活
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Deactivate(object sender, EventArgs e)
        {
            IntPtr OmyPtr = GetForegroundWindow();
            //Console.WriteLine("Form5的窗体句柄" + Form5.myPtr.ToInt32());
            //Console.WriteLine("现在激活的窗体句柄" + OmyPtr.ToInt32());
            //判断应用程序的状态
            if (lstboxIsShow && (Form5.myPtr.ToInt32() != OmyPtr.ToInt32()))
            {
                form5.Hide();
                lstboxIsShow = false;
                //Console.WriteLine("HIDE");

            }
            //lstboxIsShow = false;
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// 发送AT指令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tboxSend_MouseClick(object sender, MouseEventArgs e)
        {
            tboxSend_TextChanged(sender, e);
        }

        /// <summary>
        /// 保存ATlog
        /// </summary>
        private void saveAtLog()
        {
            //获取当前文件路径
            if (tboxShow.Text.Length > 0)
            {
                string nowDirPath = System.Windows.Forms.Application.StartupPath;
                string dirPath = nowDirPath + "\\AtCommandTool_Logs";
                string filePth = dirPath + "\\" + DateTime.Now.ToString("yyyyMMddHHmmmmssfff") + ".log";
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
                if (!File.Exists(filePth))
                {
                    using (File.Create(filePth))
                    {

                    }
                }
                File.WriteAllText(filePth, tboxShow.Text);
                MessageBox.Show("log已保存到:\r\n" + filePth);
            }
            else { return; }
        }

        private void RightClik_S_Click(object sender, EventArgs e)
        {
            saveAtLog();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Console.WriteLine("change" + (this.Size.Height - this.tboxShow.Size.Height));
            int changY = Size.Height - thisY;
            int changX = Size.Width - thisX;
            tboxShow.SetBounds(tboxShow.Left, tboxShow.Right, tboxShow.Height, 351 + Size.Height - thisY);
            panel1.Height = 327 + Size.Height - thisY;
            gboxMCL.Height= 366 + Size.Height - thisY;
            gboxSend.Width = 539 + changX;
            tboxSend.Width = 424 + changX;
            //btnSend.Location = new Point(btnSend.Location.X + changX, btnSend.Location.Y);
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            Console.WriteLine("begin");
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            Console.WriteLine("end");
        }


        /* 判断设备是否连接
        protected override void WndProc(ref Message m)
        {
            string[] ports;
            //Console.WriteLine(m.Msg);

            if (m.Msg == 0x0219)
            {//设备被拔出
                if (m.WParam.ToInt32() == 0x8004)//usb串口
                {
                    //Console.WriteLine("设备被拔出" + portControl.isOpen());
                    Console.WriteLine("设备被拔出");
                    portControl.closePort();
                    ports = portControl.refurbishPortNme();
                    string nowPort = portControl.serialPort.PortName;
                    if (nowPort != null)
                    {
                        if (strIsInList(nowPort, ports))
                        {
                            cbboxPort.Text = nowPort;
                            portControl.OpenPort();
                        }
                    }
                }
                else
                {
                    //Console.WriteLine("设备插入"+ portControl.isOpen());
                    Console.WriteLine("设备插入");
                    //portControl.refurbishPortNme();
                }

            }

            base.WndProc(ref m);

        }

        private bool strIsInList(string str, string[] strList)
        {
            bool isIn = false;
            foreach (string temp in strList)
            {
                if (temp == str)
                    isIn = true;
            }
            return isIn;
        }
        */
    }
}
