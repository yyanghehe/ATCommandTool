using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATCommandTool.Controlers
{
    class PortControl
    {
        public SerialPort serialPort;
        TextBox tBoxPortOut;//输出Textbox
        CheckBox cobxSendLine;//换行发送Checkbox
        GroupBox _gbox;//操作区域
        CheckBox cboxRTS;//RTScheckbox
        CheckBox cboxDTR;//DTR CHECKBOX
        ComboBox cbbboxPort;//串口列表
        ComboBox cbboxBaud;//波特率列表
        Button btnOpenOrClose;//打开或者关闭按钮
        CheckBox cboxHEXSend;//16进制接收
        bool showHEXSend = false;
        CheckBox cboxHEXReceive;//16进制发送
        bool showHEXReceive;
        Label lblR;
        CheckBox cboxTimeShow;
        bool showTime = false;
        //控件类
        public PortControl()
        {

        }
        public PortControl(GroupBox gbox)
        {
            _gbox = gbox;
            tBoxPortOut = gbox.FindForm().Controls.Find("tboxShow", true)[0] as TextBox;
            cobxSendLine = gbox.FindForm().Controls.Find("cobxSendLine", true)[0] as CheckBox;
            cboxRTS = gbox.FindForm().Controls.Find("cboxRTS", true)[0] as CheckBox;
            cboxDTR = gbox.FindForm().Controls.Find("cboxDTR", true)[0] as CheckBox;
            cbbboxPort = _gbox.Controls.Find("cbboxPort", true)[0] as ComboBox;
            cbboxBaud = _gbox.Controls.Find("cbboxBaud", true)[0] as ComboBox;
            cboxHEXSend = gbox.FindForm().Controls.Find("cboxHEXSend", true)[0] as CheckBox;
            cboxHEXSend.Click += CboxHEXSend_Click;
            cboxHEXReceive = gbox.FindForm().Controls.Find("cboxHEXReceive", true)[0] as CheckBox;
            cboxHEXReceive.Click += CboxHEXReceive_Click;
            cboxTimeShow = gbox.FindForm().Controls.Find("cboxShowTime", true)[0] as CheckBox;
            cboxTimeShow.Click += CboxTimeShow_Click;
            cboxRTS.Click += CboxRTS_Click;
            cboxDTR.Click += CboxDTR_Click;
            btnOpenOrClose = _gbox.Controls.Find("btnOpen", true)[0] as Button;
            cbboxBaud.SelectedValueChanged += CbboxBaud_SelectedValueChanged;
            lblR = _gbox.FindForm().Controls.Find("lblR", true)[0] as Label;
            serialPort = new SerialPort();
        }

        private void CboxHEXSend_Click(object sender, EventArgs e)
        {
            showHEXSend = cboxHEXSend.Checked;
        }

        private void CboxHEXReceive_Click(object sender, EventArgs e)
        {
            showHEXReceive = cboxHEXReceive.Checked;
        }

        private void CboxTimeShow_Click(object sender, EventArgs e)
        {
            showTime = cboxTimeShow.Checked;
        }

        private void CbboxBaud_SelectedValueChanged(object sender, EventArgs e)
        {
            if (serialPort != null)
                serialPort.BaudRate = serialPort.BaudRate == int.Parse(cbboxBaud.SelectedItem.ToString()) ? serialPort.BaudRate : int.Parse(cbboxBaud.SelectedItem.ToString());
        }

        private void SerialPort_Disposed(object sender, EventArgs e)
        {
            //Console.WriteLine("串口" + serialPort.PortName);
            //Console.WriteLine("资源销毁中....");
        }
        Thread myThread;
        public void OpenPort()
        {
            Application.DoEvents();
            if (serialPort != null)
            {
                closePort();
            }
            if (cbbboxPort.SelectedItem == null)
            {
                showERROR("请选择端口\r\n");
                return;
            }
            serialPort = new SerialPort();
            serialPort.PortName = cbbboxPort.SelectedItem.ToString();
            serialPort.BaudRate = serialPort.BaudRate == int.Parse(cbboxBaud.SelectedItem.ToString()) ? serialPort.BaudRate : int.Parse(cbboxBaud.SelectedItem.ToString());
            serialPort.DataBits = 8;//数据位
            serialPort.Parity = Parity.None;//校验位
            serialPort.StopBits = StopBits.One;//停止位
            serialPort.WriteTimeout = -1;
            serialPort.ReadTimeout = -1;
            serialPort.ReadBufferSize = 5184;
            serialPort.WriteBufferSize = 2592;
            //serialPort.Handshake = Handshake.XOnXOff; //流控开关
            serialPort.ReceivedBytesThreshold = 1;//必须设置,否者不能接收到返回的数据
            serialPort.DtrEnable = cboxDTR.Checked; //设置电脑收到回显
            serialPort.RtsEnable = cboxRTS.Checked; //设置电脑收到回显
            serialPort.NewLine = "\r\n";


            //ReceviceEvent.Set();
            //打开串口并更改按钮
            try
            {
                Application.DoEvents();
                serialPort.Open();
                if (isOpen())
                {
                    //Console.WriteLine("打开成功");
                    serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
                    serialPort.Disposed += SerialPort_Disposed;

                    myThread = new Thread(showToTBox);
                    myThread.Start();
                }

            }
            catch (System.IO.IOException e)
            {
                //Console.WriteLine("打开" + serialPort.PortName + "失败");
                showERROR(e.Message);
            }
            catch (System.UnauthorizedAccessException e)
            {
                //Console.WriteLine("打开" + serialPort.PortName + "失败");
                showERROR(e.Message);
            }
            catch (System.ArgumentException e)
            {
                //Console.WriteLine("打开" + serialPort.PortName + "失败");
                showERROR(e.Message);
            }
        }
        private void CboxDTR_Click(object sender, EventArgs e)
        {
            if (serialPort != null)
                serialPort.DtrEnable = (sender as CheckBox).Checked;
        }

        private void CboxRTS_Click(object sender, EventArgs e)
        {
            if (serialPort != null)
                serialPort.RtsEnable = (sender as CheckBox).Checked;
        }

        public void closePort()
        {
            try
            {
                if (serialPort != null)
                {
                    Application.DoEvents();
                    serialPort.Close();
                    serialPort = null;
                    GC.Collect();
                    isOpen();
                }
            }
            catch (Exception e)
            {
                showERROR(e.Message + " ====== 关闭串口失败");
            }
            if (myThread != null)
            {
                //OutPutEvent.Dispose();
                listBytes.Clear();
                myThread.Abort();
            }

        }
        AutoResetEvent OutPutEvent = new AutoResetEvent(false);
        AutoResetEvent ReceviceEvent = new AutoResetEvent(false);
        List<byte[]> listBytes = new List<byte[]>();
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int count = serialPort.BytesToRead;
            if (count > 0)
            {
                try
                {
                    //byte[] bufferBytes = new byte[count];
                    //serialPort.Read(bufferBytes, 0, count);
                    //PortBytes portBytes = new PortBytes(showTotBox);
                    //tBoxPortOut.FindForm().BeginInvoke(portBytes, bufferBytes);

                    //countLength += count;
                    //Console.WriteLine("count:" + count);
                    //Console.WriteLine("CountLength:" + countLength);
                    byte[] bufferBytes = new byte[count];
                    serialPort.Read(bufferBytes, 0, count);
                    listBytesAddOrRemove(true, bufferBytes);
                    //listBytes.Add(bufferBytes);
                    //OutPutEvent.Set();
                    //ReceviceEvent.Set();
                    //Thread showThread = new Thread(new ParameterizedThreadStart(dobufferBytes));
                    //showThread.Start(bufferBytes);
                }
                catch (Exception E)
                {
                    ERRORDelegate mySend = new ERRORDelegate(showERROR);
                    _gbox.FindForm().BeginInvoke(mySend, E.Message);
                }
            }
        }
        //double countLength = 0;
        //private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //    ReceviceEvent.WaitOne();
        //    int count = serialPort.BytesToRead;
        //    if (count > 0)
        //    {
        //        countLength += count;
        //        Console.WriteLine("byteCount:" + count);
        //        Console.WriteLine("CountLength:" + countLength);
        //        byte[] bufferBytes = new byte[count];
        //        serialPort.Read(bufferBytes, 0, count);
        //        PortBytes portBytes = new PortBytes(showTotBox);
        //        tBoxPortOut.FindForm().BeginInvoke(portBytes, bufferBytes);
        //        //Thread showThread = new Thread(new ParameterizedThreadStart(dobufferBytes));
        //        //showThread.Start(bufferBytes);
        //    }
        //}
        void waitThread()
        {
            while (true)
            {
                Application.DoEvents();
                Thread.Sleep(200);
                OutPutEvent.Set();
            }
        }

        private delegate void PortBytes(byte[] bytes);
        private void showTotBox(byte[] bytes)
        {
            Console.WriteLine(bytes.Length);
            if (showTime)
            {
                tBoxPortOut.AppendText("\r\n" + NowTime() + "收<===\r\n");
            }

            show(bytes);
        }
        private void showToTBox()
        {
            while (true)
            {
                Application.DoEvents();
                if (listBytes.Count > 0)
                {
                    PortBytes portBytes = new PortBytes(show);
                    tBoxPortOut.FindForm().BeginInvoke(portBytes, listBytes[0]);
                    OutPutEvent.WaitOne();
                }
                else
                {
                    Thread.Sleep(1);
                    continue;
                }

            }
        }
        void listBytesAddOrRemove(bool isAdd, byte[] bytes)
        {
            lock (listBytes)
            {
                if (isAdd)
                {
                    listBytes.Add(bytes);
                }
                else
                {
                    listBytes.RemoveAt(0);
                }
            }
        }
        private void show(byte[] bytes)
        {
            //Console.WriteLine("SHOW_LENGTH:" + bytes.Length);

            if (showHEXReceive)
            {
                byte[] HEXbytes = bytes;
                string str = "";
                foreach (byte b in bytes)
                {
                    str += b.ToString("X2") + " ";
                }
                bytes = new byte[str.Length];
                bytes = Encoding.Default.GetBytes(str);
            }
            try
            {
                loopPrint(bytes);
            }
            catch (Exception e)
            {
                saveAtLog(e.Message + "\r\nbytes:" + bytes.Length + "\r\n");
                closePort();
                MessageBox.Show("ERROR");
            }
            if (listBytes.Count > 0)
                listBytesAddOrRemove(false, bytes);
            OutPutEvent.Set();
            //ReceviceEvent.Set();
        }
        private void saveAtLog(string str)
        {
            //获取当前文件路径
            if (str.Length > 0)
            {
                string nowDirPath = System.Windows.Forms.Application.StartupPath;
                string dirPath = nowDirPath + "\\AtCommandTool_Logs";
                string filePth = dirPath + "\\" + DateTime.Now.ToString("revevice") + "ERROR.log";
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
                File.AppendAllText(filePth, str);
                //MessageBox.Show("log已保存到:\r\n" + filePth);
            }
            else { return; }
        }
        void loopPrint(byte[] bytes)
        {
            long MaxLength = 1269 * 3;
            if (bytes.Length >= 0)
            {

                if (bytes.Length > MaxLength)
                {
                    Console.WriteLine("长度大于" + MaxLength + "=============此时长度为:" + bytes.Length);
                    for (int i = 0; i <= bytes.Length / MaxLength; i++)
                    {
                        Application.DoEvents();
                        byte[] temp;
                        if (i != bytes.Length / MaxLength)
                        {
                            temp = new byte[MaxLength];
                            Array.Copy(bytes, i * MaxLength, temp, 0, MaxLength);
                        }
                        else
                        {
                            temp = new byte[bytes.Length - i * MaxLength];
                            Array.Copy(bytes, i * MaxLength, temp, 0, temp.Length);
                        }
                        showBytes(temp);
                    }
                }
                else
                {
                    showBytes(bytes);
                }
            }
        }
        void showBytes(byte[] bytes)
        {
            if (this.isOpen())
            {
                string showStr = Encoding.Default.GetString(bytes).Replace("\0", "\\0");
                if (showTime)
                {
                    string nowTime = "[" + NowTime() + "]<===";
                    string[] strs = showStr.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string Temp in strs)
                    {
                        tBoxPortOut.AppendText(nowTime + "\t" + Temp + "\r\n");
                    }
                }
                else
                {
                    tBoxPortOut.AppendText(showStr);
                }
                lblR.Text = "R:" + (int.Parse(lblR.Text.Substring(2)) + (!showHEXReceive ? bytes.Length : bytes.Length / 3));
            }
        }
        private void showERROR(string str)
        {
            tBoxPortOut.AppendText(str.Replace("\r\n", "") + "\r\n");
        }
        public string[] refurbishPortNme()
        {
            return refurbishPortNme(cbbboxPort);
        }
        /// <summary>
        /// 更新串口名字
        /// </summary>
        /// <param name="combox"></param>
        public string[] refurbishPortNme(ComboBox combox)
        {
            //方法一
            string[] portNames = new string[] { };
            try
            {
                portNames = SerialPort.GetPortNames();
                combox.Items.Clear();
                foreach (string item in portNames)
                {
                    combox.Items.Add(item);
                }
                if (combox.Items.Count > 0)
                {
                    combox.Text = combox.Items[0].ToString();
                }
                return portNames;
            }
            catch (Exception E)
            {
                showERROR(E.Message);
                return portNames;
            }
            //方法二
            //try {
            //    RegistryKey keycomm = Registry.LocalMachine.OpenSubKey("HARDWARE\\DEVICEMAP\\SERIALCOMM");
            //    combox.Items.Clear();
            //    if (keycomm != null)
            //    {
            //        string[] sSubKeys = keycomm.GetValueNames();
            //        foreach (string sName in sSubKeys)
            //        {
            //            string sValue = (string)keycomm.GetValue(sName);
            //            combox.Items.Add(sValue);
            //        }
            //    }
            //    if (combox.Items.Count > 0)
            //    {
            //        combox.Text = combox.Items[0].ToString();
            //    }
            //    else
            //    {
            //        combox.Text = "";
            //    }
            //}
            //catch (Exception e)
            //{
            //    showERROR(e.Message);
            //}

        }
        /// <summary>
        /// 添加波特率列表
        /// </summary>
        /// <param name="cbboxBaud"></param>
        internal void refubishBaudRate(ComboBox cbboxBaud)
        {
            int[] baudRate = { 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 28800, 38400, 57600, 115200, 230400, 460800, 921600, 2000000, 2900000, 3000000, 3200000, 3686400, 4000000 };
            cbboxBaud.Items.Clear();
            foreach (int i in baudRate)
            {
                cbboxBaud.Items.Add(i);
            }
            cbboxBaud.Text = "115200";
        }
        private delegate void ERRORDelegate(string str);
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="str">需要发送的字符串</param>
        /// <param name="line">是否为行发送</param>
        public void portSend(byte[] bytes)
        {
            try
            {
                if (showTime)
                {
                    tBoxPortOut.AppendText("[" + NowTime() + "]===>\t" + ASCIIEncoding.Default.GetString(bytes).Replace("\r\n", "") + "\r\n");
                }
                ParameterizedThreadStart parameterThread = new ParameterizedThreadStart(threadSend);
                Thread thread = new Thread(parameterThread);
                thread.Start(bytes);
                Form1 form1 = new Form1();
                form1.makeAdd(ASCIIEncoding.Default.GetString(bytes), form1.addToEnd);
            }
            catch (Exception e)
            {
                showERROR(e.Message);
            }
        }

        private void threadSend(object obj)
        {
            byte[] bytes = (byte[])obj;
            try
            {
                serialPort.Write(bytes, 0, bytes.Length);
            }
            catch (Exception e)
            {
                ERRORDelegate mySend = new ERRORDelegate(showERROR);
                _gbox.FindForm().BeginInvoke(mySend, e.Message);
            }
        }

        /// <summary>
        /// 对串口发送数据
        /// </summary>
        /// <param name="strs">需要发送的字符串</param>
        public void portSend(string str)
        {
            //GC.Collect();
            //showTime = true;
            if (str == "" || str == null)
            {
                return;
            }
            if (serialPort == null || !serialPort.IsOpen)
            {
                OpenPort();
            }
            if (serialPort != null && serialPort.IsOpen)
            {
                if (cobxSendLine.Checked)
                {
                    str = str + serialPort.NewLine;
                }
                byte[] bytes;

                if (showHEXSend)
                {
                    string temp = str.Replace(" ", "").Replace("\r\n", "");
                    if (Regex.IsMatch(temp, "^[0-9a-fA-F]+$"))
                    {
                        bytes = new byte[temp.Length / 2];
                        int j = temp.Length / 2;
                        for (int i = 0; i < j; i++)
                        {
                            bytes[i] = Convert.ToByte(temp.Substring(i * 2, 2), 16);
                        }
                    }
                    else
                    {
                        Encoding gb = System.Text.Encoding.GetEncoding("gb2312");
                        bytes = gb.GetBytes(str);
                    }
                }
                else
                {
                    Encoding gb = System.Text.Encoding.GetEncoding("gb2312");
                    bytes = gb.GetBytes(str);

                }
                portSend(bytes);
                Label lblS = _gbox.FindForm().Controls.Find("lblS", true)[0] as Label;
                lblS.Text = "S:" + (int.Parse(lblS.Text.Substring(2)) + Encoding.Default.GetByteCount((str).ToCharArray()));
                Label lblT = _gbox.FindForm().Controls.Find("lblT", true)[0] as Label;
                lblT.Text = "T:" + (int.Parse(lblT.Text.Substring(2)) + 1);
            }
        }
        public void portSend(string str, bool newLine)
        {
            //showTime = false;
            if (str == "" || str == null)
            {
                return;
            }
            if (serialPort == null || !serialPort.IsOpen)
            {
                OpenPort();
            }
            if (serialPort != null && serialPort.IsOpen)
            {
                if (newLine)
                {
                    str = str + serialPort.NewLine;
                }
                Encoding gb = System.Text.Encoding.GetEncoding("gb2312");
                byte[] bytes = gb.GetBytes(str);
                portSend(bytes);
                Label lblS = _gbox.FindForm().Controls.Find("lblS", true)[0] as Label;
                lblS.Text = "S:" + (int.Parse(lblS.Text.Substring(2)) + Encoding.Default.GetByteCount((str).ToCharArray()));
            }
        }
        public bool isOpen()
        {
            if (serialPort == null)
            {
                btnOpenOrClose.Text = "打开串口";
                btnOpenOrClose.BackColor = System.Drawing.Color.Red;
                btnOpenOrClose.ForeColor = System.Drawing.Color.White;
                return false;
            }
            else if (serialPort.IsOpen)
            {
                btnOpenOrClose.Text = "关闭串口";
                btnOpenOrClose.BackColor = System.Drawing.Color.Green;
                btnOpenOrClose.ForeColor = System.Drawing.Color.Black;
                return true;
            }
            else
            {
                btnOpenOrClose.Text = "打开串口";
                btnOpenOrClose.BackColor = System.Drawing.Color.Red;
                btnOpenOrClose.ForeColor = System.Drawing.Color.White;
                return false;
            }
        }
        private string NowTime()
        {
            DateTime currentTime = DateTime.Now;
            //按照格式(yyyy-mm-dd tt:mm:ss:mmmm)返回
            string time = currentTime.ToString("yyyy-MM-dd HH:mm:ss:fff");
            return time;
        }
    }
}
