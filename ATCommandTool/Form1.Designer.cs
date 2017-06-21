namespace ATCommandTool
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gboxMCCS = new System.Windows.Forms.GroupBox();
            this.gboxMCPD = new System.Windows.Forms.GroupBox();
            this.btnMCPDRead = new System.Windows.Forms.Button();
            this.btnMCPDSave = new System.Windows.Forms.Button();
            this.gboxMCL = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gboxMCPS = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tboxTimes = new System.Windows.Forms.TextBox();
            this.cboxMCCircle = new System.Windows.Forms.CheckBox();
            this.btnMCSubOne = new System.Windows.Forms.Button();
            this.rbSelected = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.btnMCClear = new System.Windows.Forms.Button();
            this.btnMCAddOne = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tboxMCLCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tBoxMCCTime = new System.Windows.Forms.TextBox();
            this.gboxPort = new System.Windows.Forms.GroupBox();
            this.gboxPortControl = new System.Windows.Forms.GroupBox();
            this.gboxPortSetting = new System.Windows.Forms.GroupBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.cboxShowTime = new System.Windows.Forms.CheckBox();
            this.lblT = new System.Windows.Forms.Label();
            this.cboxHEXReceive = new System.Windows.Forms.CheckBox();
            this.cboxHEXSend = new System.Windows.Forms.CheckBox();
            this.lblR = new System.Windows.Forms.Label();
            this.lblS = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tboxSendTime = new System.Windows.Forms.TextBox();
            this.cboxSendTime = new System.Windows.Forms.CheckBox();
            this.cobxSendLine = new System.Windows.Forms.CheckBox();
            this.cboxRTS = new System.Windows.Forms.CheckBox();
            this.cboxDTR = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbboxBaud = new System.Windows.Forms.ComboBox();
            this.cbboxPort = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnRefur = new System.Windows.Forms.Button();
            this.gboxSend = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.tboxSend = new System.Windows.Forms.TextBox();
            this.tboxShow = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RightClik_C = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClik_A = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClik_V = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClik_D = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClik_S = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.gboxMCCS.SuspendLayout();
            this.gboxMCPD.SuspendLayout();
            this.gboxMCL.SuspendLayout();
            this.gboxMCPS.SuspendLayout();
            this.gboxPort.SuspendLayout();
            this.gboxPortControl.SuspendLayout();
            this.gboxPortSetting.SuspendLayout();
            this.gboxSend.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // gboxMCCS
            // 
            this.gboxMCCS.Controls.Add(this.gboxMCPD);
            this.gboxMCCS.Controls.Add(this.gboxMCL);
            this.gboxMCCS.Controls.Add(this.gboxMCPS);
            this.gboxMCCS.Dock = System.Windows.Forms.DockStyle.Right;
            this.gboxMCCS.Location = new System.Drawing.Point(554, 0);
            this.gboxMCCS.Margin = new System.Windows.Forms.Padding(0);
            this.gboxMCCS.Name = "gboxMCCS";
            this.gboxMCCS.Size = new System.Drawing.Size(350, 512);
            this.gboxMCCS.TabIndex = 0;
            this.gboxMCCS.TabStop = false;
            // 
            // gboxMCPD
            // 
            this.gboxMCPD.Controls.Add(this.btnMCPDRead);
            this.gboxMCPD.Controls.Add(this.btnMCPDSave);
            this.gboxMCPD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gboxMCPD.Location = new System.Drawing.Point(3, 462);
            this.gboxMCPD.Name = "gboxMCPD";
            this.gboxMCPD.Size = new System.Drawing.Size(344, 47);
            this.gboxMCPD.TabIndex = 4;
            this.gboxMCPD.TabStop = false;
            this.gboxMCPD.Text = "数据操作";
            // 
            // btnMCPDRead
            // 
            this.btnMCPDRead.Location = new System.Drawing.Point(175, 20);
            this.btnMCPDRead.Name = "btnMCPDRead";
            this.btnMCPDRead.Size = new System.Drawing.Size(75, 23);
            this.btnMCPDRead.TabIndex = 1;
            this.btnMCPDRead.Text = "读取";
            this.btnMCPDRead.UseVisualStyleBackColor = true;
            // 
            // btnMCPDSave
            // 
            this.btnMCPDSave.Location = new System.Drawing.Point(56, 20);
            this.btnMCPDSave.Name = "btnMCPDSave";
            this.btnMCPDSave.Size = new System.Drawing.Size(75, 23);
            this.btnMCPDSave.TabIndex = 0;
            this.btnMCPDSave.Text = "保存";
            this.btnMCPDSave.UseVisualStyleBackColor = true;
            // 
            // gboxMCL
            // 
            this.gboxMCL.Controls.Add(this.label7);
            this.gboxMCL.Controls.Add(this.panel1);
            this.gboxMCL.Controls.Add(this.label6);
            this.gboxMCL.Controls.Add(this.label5);
            this.gboxMCL.Location = new System.Drawing.Point(7, 90);
            this.gboxMCL.Name = "gboxMCL";
            this.gboxMCL.Size = new System.Drawing.Size(328, 366);
            this.gboxMCL.TabIndex = 3;
            this.gboxMCL.TabStop = false;
            this.gboxMCL.Text = "多条指令";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(269, 17);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "序号";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(5, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(317, 327);
            this.panel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(150, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "字符串";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "选中";
            // 
            // gboxMCPS
            // 
            this.gboxMCPS.Controls.Add(this.label4);
            this.gboxMCPS.Controls.Add(this.tboxTimes);
            this.gboxMCPS.Controls.Add(this.cboxMCCircle);
            this.gboxMCPS.Controls.Add(this.btnMCSubOne);
            this.gboxMCPS.Controls.Add(this.rbSelected);
            this.gboxMCPS.Controls.Add(this.rbAll);
            this.gboxMCPS.Controls.Add(this.btnMCClear);
            this.gboxMCPS.Controls.Add(this.btnMCAddOne);
            this.gboxMCPS.Controls.Add(this.label3);
            this.gboxMCPS.Controls.Add(this.tboxMCLCount);
            this.gboxMCPS.Controls.Add(this.label1);
            this.gboxMCPS.Controls.Add(this.label2);
            this.gboxMCPS.Controls.Add(this.tBoxMCCTime);
            this.gboxMCPS.Location = new System.Drawing.Point(6, 12);
            this.gboxMCPS.Name = "gboxMCPS";
            this.gboxMCPS.Size = new System.Drawing.Size(329, 75);
            this.gboxMCPS.TabIndex = 2;
            this.gboxMCPS.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(160, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "次";
            // 
            // tboxTimes
            // 
            this.tboxTimes.Location = new System.Drawing.Point(132, 12);
            this.tboxTimes.Name = "tboxTimes";
            this.tboxTimes.Size = new System.Drawing.Size(30, 21);
            this.tboxTimes.TabIndex = 8;
            this.tboxTimes.Text = "100";
            this.tboxTimes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxSendTime_KeyPress);
            this.tboxTimes.Leave += new System.EventHandler(this.tboxTimes_Leave);
            // 
            // cboxMCCircle
            // 
            this.cboxMCCircle.AutoSize = true;
            this.cboxMCCircle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboxMCCircle.Location = new System.Drawing.Point(2, 14);
            this.cboxMCCircle.Name = "cboxMCCircle";
            this.cboxMCCircle.Size = new System.Drawing.Size(72, 16);
            this.cboxMCCircle.TabIndex = 0;
            this.cboxMCCircle.Text = "定时发送";
            this.cboxMCCircle.UseVisualStyleBackColor = true;
            // 
            // btnMCSubOne
            // 
            this.btnMCSubOne.Location = new System.Drawing.Point(216, 49);
            this.btnMCSubOne.Name = "btnMCSubOne";
            this.btnMCSubOne.Size = new System.Drawing.Size(18, 23);
            this.btnMCSubOne.TabIndex = 4;
            this.btnMCSubOne.Text = "-";
            this.btnMCSubOne.UseVisualStyleBackColor = true;
            // 
            // rbSelected
            // 
            this.rbSelected.AutoSize = true;
            this.rbSelected.Location = new System.Drawing.Point(252, 14);
            this.rbSelected.Name = "rbSelected";
            this.rbSelected.Size = new System.Drawing.Size(71, 16);
            this.rbSelected.TabIndex = 7;
            this.rbSelected.Text = "选择循环";
            this.rbSelected.UseVisualStyleBackColor = true;
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(180, 13);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(71, 16);
            this.rbAll.TabIndex = 6;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "全部循环";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // btnMCClear
            // 
            this.btnMCClear.Location = new System.Drawing.Point(240, 49);
            this.btnMCClear.Name = "btnMCClear";
            this.btnMCClear.Size = new System.Drawing.Size(77, 23);
            this.btnMCClear.TabIndex = 5;
            this.btnMCClear.Text = "列表初始化";
            this.btnMCClear.UseVisualStyleBackColor = true;
            // 
            // btnMCAddOne
            // 
            this.btnMCAddOne.Location = new System.Drawing.Point(192, 49);
            this.btnMCAddOne.Name = "btnMCAddOne";
            this.btnMCAddOne.Size = new System.Drawing.Size(18, 23);
            this.btnMCAddOne.TabIndex = 3;
            this.btnMCAddOne.Text = "+";
            this.btnMCAddOne.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "条指令(<100条)添加/删除";
            // 
            // tboxMCLCount
            // 
            this.tboxMCLCount.Location = new System.Drawing.Point(26, 51);
            this.tboxMCLCount.Name = "tboxMCLCount";
            this.tboxMCLCount.Size = new System.Drawing.Size(22, 21);
            this.tboxMCLCount.TabIndex = 2;
            this.tboxMCLCount.Text = "20";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "ms";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "共有";
            // 
            // tBoxMCCTime
            // 
            this.tBoxMCCTime.Location = new System.Drawing.Point(71, 12);
            this.tBoxMCCTime.Name = "tBoxMCCTime";
            this.tBoxMCCTime.Size = new System.Drawing.Size(38, 21);
            this.tBoxMCCTime.TabIndex = 1;
            this.tBoxMCCTime.Text = "1000";
            this.tBoxMCCTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxSendTime_KeyPress);
            this.tBoxMCCTime.Leave += new System.EventHandler(this.tboxTimes_Leave);
            // 
            // gboxPort
            // 
            this.gboxPort.Controls.Add(this.gboxPortControl);
            this.gboxPort.Controls.Add(this.tboxShow);
            this.gboxPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gboxPort.Location = new System.Drawing.Point(0, 0);
            this.gboxPort.Name = "gboxPort";
            this.gboxPort.Size = new System.Drawing.Size(554, 512);
            this.gboxPort.TabIndex = 1;
            this.gboxPort.TabStop = false;
            // 
            // gboxPortControl
            // 
            this.gboxPortControl.Controls.Add(this.gboxPortSetting);
            this.gboxPortControl.Controls.Add(this.gboxSend);
            this.gboxPortControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gboxPortControl.Location = new System.Drawing.Point(3, 371);
            this.gboxPortControl.Margin = new System.Windows.Forms.Padding(0);
            this.gboxPortControl.Name = "gboxPortControl";
            this.gboxPortControl.Padding = new System.Windows.Forms.Padding(0);
            this.gboxPortControl.Size = new System.Drawing.Size(548, 138);
            this.gboxPortControl.TabIndex = 1;
            this.gboxPortControl.TabStop = false;
            // 
            // gboxPortSetting
            // 
            this.gboxPortSetting.Controls.Add(this.btnOpen);
            this.gboxPortSetting.Controls.Add(this.cboxShowTime);
            this.gboxPortSetting.Controls.Add(this.lblT);
            this.gboxPortSetting.Controls.Add(this.cboxHEXReceive);
            this.gboxPortSetting.Controls.Add(this.cboxHEXSend);
            this.gboxPortSetting.Controls.Add(this.lblR);
            this.gboxPortSetting.Controls.Add(this.lblS);
            this.gboxPortSetting.Controls.Add(this.label10);
            this.gboxPortSetting.Controls.Add(this.tboxSendTime);
            this.gboxPortSetting.Controls.Add(this.cboxSendTime);
            this.gboxPortSetting.Controls.Add(this.cobxSendLine);
            this.gboxPortSetting.Controls.Add(this.cboxRTS);
            this.gboxPortSetting.Controls.Add(this.cboxDTR);
            this.gboxPortSetting.Controls.Add(this.label8);
            this.gboxPortSetting.Controls.Add(this.cbboxBaud);
            this.gboxPortSetting.Controls.Add(this.cbboxPort);
            this.gboxPortSetting.Controls.Add(this.label9);
            this.gboxPortSetting.Controls.Add(this.btnRefur);
            this.gboxPortSetting.Location = new System.Drawing.Point(3, 17);
            this.gboxPortSetting.Name = "gboxPortSetting";
            this.gboxPortSetting.Size = new System.Drawing.Size(538, 64);
            this.gboxPortSetting.TabIndex = 5;
            this.gboxPortSetting.TabStop = false;
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.Red;
            this.btnOpen.ForeColor = System.Drawing.Color.White;
            this.btnOpen.Location = new System.Drawing.Point(177, 35);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(63, 26);
            this.btnOpen.TabIndex = 11;
            this.btnOpen.Text = "打开串口";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // cboxShowTime
            // 
            this.cboxShowTime.AutoSize = true;
            this.cboxShowTime.Location = new System.Drawing.Point(480, 16);
            this.cboxShowTime.Margin = new System.Windows.Forms.Padding(0);
            this.cboxShowTime.Name = "cboxShowTime";
            this.cboxShowTime.Size = new System.Drawing.Size(48, 16);
            this.cboxShowTime.TabIndex = 18;
            this.cboxShowTime.Text = "Time";
            this.cboxShowTime.UseVisualStyleBackColor = true;
            // 
            // lblT
            // 
            this.lblT.AutoSize = true;
            this.lblT.Location = new System.Drawing.Point(483, 32);
            this.lblT.Name = "lblT";
            this.lblT.Size = new System.Drawing.Size(23, 12);
            this.lblT.TabIndex = 17;
            this.lblT.Text = "T:0";
            // 
            // cboxHEXReceive
            // 
            this.cboxHEXReceive.AutoSize = true;
            this.cboxHEXReceive.Location = new System.Drawing.Point(246, 39);
            this.cboxHEXReceive.Name = "cboxHEXReceive";
            this.cboxHEXReceive.Size = new System.Drawing.Size(84, 16);
            this.cboxHEXReceive.TabIndex = 16;
            this.cboxHEXReceive.Text = "16进制接收";
            this.cboxHEXReceive.UseVisualStyleBackColor = true;
            // 
            // cboxHEXSend
            // 
            this.cboxHEXSend.AutoSize = true;
            this.cboxHEXSend.Location = new System.Drawing.Point(336, 39);
            this.cboxHEXSend.Name = "cboxHEXSend";
            this.cboxHEXSend.Size = new System.Drawing.Size(84, 16);
            this.cboxHEXSend.TabIndex = 15;
            this.cboxHEXSend.Text = "16进制发送";
            this.cboxHEXSend.UseVisualStyleBackColor = true;
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Location = new System.Drawing.Point(426, 49);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(23, 12);
            this.lblR.TabIndex = 14;
            this.lblR.Text = "R:0";
            // 
            // lblS
            // 
            this.lblS.AutoSize = true;
            this.lblS.Location = new System.Drawing.Point(426, 32);
            this.lblS.Name = "lblS";
            this.lblS.Size = new System.Drawing.Size(23, 12);
            this.lblS.TabIndex = 13;
            this.lblS.Text = "S:0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(136, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 12);
            this.label10.TabIndex = 10;
            this.label10.Text = "ms/次";
            // 
            // tboxSendTime
            // 
            this.tboxSendTime.Location = new System.Drawing.Point(77, 37);
            this.tboxSendTime.MaxLength = 10;
            this.tboxSendTime.Name = "tboxSendTime";
            this.tboxSendTime.Size = new System.Drawing.Size(53, 21);
            this.tboxSendTime.TabIndex = 9;
            this.tboxSendTime.Text = "1000";
            this.tboxSendTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxSendTime_KeyPress);
            // 
            // cboxSendTime
            // 
            this.cboxSendTime.AutoSize = true;
            this.cboxSendTime.Location = new System.Drawing.Point(6, 39);
            this.cboxSendTime.Name = "cboxSendTime";
            this.cboxSendTime.Size = new System.Drawing.Size(72, 16);
            this.cboxSendTime.TabIndex = 8;
            this.cboxSendTime.Text = "定时发送";
            this.cboxSendTime.UseVisualStyleBackColor = true;
            this.cboxSendTime.Click += new System.EventHandler(this.cboxSendTime_Click);
            // 
            // cobxSendLine
            // 
            this.cobxSendLine.AutoSize = true;
            this.cobxSendLine.Checked = true;
            this.cobxSendLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cobxSendLine.Location = new System.Drawing.Point(405, 16);
            this.cobxSendLine.Name = "cobxSendLine";
            this.cobxSendLine.Size = new System.Drawing.Size(72, 16);
            this.cobxSendLine.TabIndex = 7;
            this.cobxSendLine.Text = "发送新行";
            this.cobxSendLine.UseVisualStyleBackColor = true;
            // 
            // cboxRTS
            // 
            this.cboxRTS.AutoSize = true;
            this.cboxRTS.Checked = true;
            this.cboxRTS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxRTS.Location = new System.Drawing.Point(357, 15);
            this.cboxRTS.Name = "cboxRTS";
            this.cboxRTS.Size = new System.Drawing.Size(42, 16);
            this.cboxRTS.TabIndex = 6;
            this.cboxRTS.Text = "RTS";
            this.cboxRTS.UseVisualStyleBackColor = true;
            // 
            // cboxDTR
            // 
            this.cboxDTR.AutoSize = true;
            this.cboxDTR.Checked = true;
            this.cboxDTR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxDTR.Location = new System.Drawing.Point(309, 15);
            this.cboxDTR.Name = "cboxDTR";
            this.cboxDTR.Size = new System.Drawing.Size(42, 16);
            this.cboxDTR.TabIndex = 5;
            this.cboxDTR.Text = "DTR";
            this.cboxDTR.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "串口:";
            // 
            // cbboxBaud
            // 
            this.cbboxBaud.FormattingEnabled = true;
            this.cbboxBaud.Location = new System.Drawing.Point(246, 13);
            this.cbboxBaud.Name = "cbboxBaud";
            this.cbboxBaud.Size = new System.Drawing.Size(59, 20);
            this.cbboxBaud.TabIndex = 4;
            // 
            // cbboxPort
            // 
            this.cbboxPort.FormattingEnabled = true;
            this.cbboxPort.Location = new System.Drawing.Point(47, 14);
            this.cbboxPort.Name = "cbboxPort";
            this.cbboxPort.Size = new System.Drawing.Size(59, 20);
            this.cbboxPort.TabIndex = 1;
            this.cbboxPort.SelectionChangeCommitted += new System.EventHandler(this.cbboxPort_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(193, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 3;
            this.label9.Text = "波特率:";
            // 
            // btnRefur
            // 
            this.btnRefur.Location = new System.Drawing.Point(112, 11);
            this.btnRefur.Name = "btnRefur";
            this.btnRefur.Size = new System.Drawing.Size(75, 23);
            this.btnRefur.TabIndex = 2;
            this.btnRefur.Text = "串口刷新";
            this.btnRefur.UseVisualStyleBackColor = true;
            this.btnRefur.Click += new System.EventHandler(this.btnRefur_Click);
            // 
            // gboxSend
            // 
            this.gboxSend.Controls.Add(this.btnSend);
            this.gboxSend.Controls.Add(this.tboxSend);
            this.gboxSend.Location = new System.Drawing.Point(3, 87);
            this.gboxSend.Name = "gboxSend";
            this.gboxSend.Size = new System.Drawing.Size(538, 42);
            this.gboxSend.TabIndex = 6;
            this.gboxSend.TabStop = false;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(446, 13);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(82, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tboxSend
            // 
            this.tboxSend.Location = new System.Drawing.Point(6, 15);
            this.tboxSend.Name = "tboxSend";
            this.tboxSend.Size = new System.Drawing.Size(434, 21);
            this.tboxSend.TabIndex = 0;
            this.tboxSend.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tboxSend_MouseClick);
            this.tboxSend.TextChanged += new System.EventHandler(this.tboxSend_TextChanged);
            this.tboxSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tboxSend_KeyDown);
            // 
            // tboxShow
            // 
            this.tboxShow.BackColor = System.Drawing.SystemColors.Window;
            this.tboxShow.ContextMenuStrip = this.contextMenuStrip1;
            this.tboxShow.Dock = System.Windows.Forms.DockStyle.Top;
            this.tboxShow.Location = new System.Drawing.Point(3, 17);
            this.tboxShow.Multiline = true;
            this.tboxShow.Name = "tboxShow";
            this.tboxShow.ReadOnly = true;
            this.tboxShow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tboxShow.Size = new System.Drawing.Size(548, 351);
            this.tboxShow.TabIndex = 0;
            this.tboxShow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxShow_KeyPress);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RightClik_C,
            this.RightClik_A,
            this.RightClik_V,
            this.RightClik_D,
            this.RightClik_S});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(147, 114);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // RightClik_C
            // 
            this.RightClik_C.Name = "RightClik_C";
            this.RightClik_C.Size = new System.Drawing.Size(146, 22);
            this.RightClik_C.Text = "复制(Ctrl+C)";
            this.RightClik_C.Click += new System.EventHandler(this.RightClik_C_Click);
            // 
            // RightClik_A
            // 
            this.RightClik_A.Name = "RightClik_A";
            this.RightClik_A.Size = new System.Drawing.Size(146, 22);
            this.RightClik_A.Text = "全选(Ctrl+A)";
            this.RightClik_A.Click += new System.EventHandler(this.RightClik_A_Click);
            // 
            // RightClik_V
            // 
            this.RightClik_V.Name = "RightClik_V";
            this.RightClik_V.Size = new System.Drawing.Size(146, 22);
            this.RightClik_V.Text = "粘贴(Ctrl+V)";
            this.RightClik_V.Click += new System.EventHandler(this.RightClik_V_Click);
            // 
            // RightClik_D
            // 
            this.RightClik_D.Name = "RightClik_D";
            this.RightClik_D.Size = new System.Drawing.Size(146, 22);
            this.RightClik_D.Text = "清空(Ctrl+D)";
            this.RightClik_D.Click += new System.EventHandler(this.RightClik_D_Click);
            // 
            // RightClik_S
            // 
            this.RightClik_S.Name = "RightClik_S";
            this.RightClik_S.Size = new System.Drawing.Size(146, 22);
            this.RightClik_S.Text = "保存(Ctrl+S)";
            this.RightClik_S.Click += new System.EventHandler(this.RightClik_S_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 512);
            this.Controls.Add(this.gboxPort);
            this.Controls.Add(this.gboxMCCS);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "串口工具V2.9";
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.ResizeBegin += new System.EventHandler(this.Form1_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.Move += new System.EventHandler(this.Form1_Move);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.gboxMCCS.ResumeLayout(false);
            this.gboxMCPD.ResumeLayout(false);
            this.gboxMCL.ResumeLayout(false);
            this.gboxMCL.PerformLayout();
            this.gboxMCPS.ResumeLayout(false);
            this.gboxMCPS.PerformLayout();
            this.gboxPort.ResumeLayout(false);
            this.gboxPort.PerformLayout();
            this.gboxPortControl.ResumeLayout(false);
            this.gboxPortSetting.ResumeLayout(false);
            this.gboxPortSetting.PerformLayout();
            this.gboxSend.ResumeLayout(false);
            this.gboxSend.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxMCCS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBoxMCCTime;
        private System.Windows.Forms.GroupBox gboxMCPD;
        private System.Windows.Forms.Button btnMCPDRead;
        private System.Windows.Forms.Button btnMCPDSave;
        private System.Windows.Forms.GroupBox gboxMCL;
        private System.Windows.Forms.GroupBox gboxMCPS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tboxMCLCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMCAddOne;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gboxPort;
        private System.Windows.Forms.GroupBox gboxPortControl;
        private System.Windows.Forms.GroupBox gboxPortSetting;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tboxSendTime;
        private System.Windows.Forms.CheckBox cboxSendTime;
        private System.Windows.Forms.CheckBox cobxSendLine;
        private System.Windows.Forms.CheckBox cboxRTS;
        private System.Windows.Forms.CheckBox cboxDTR;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbboxBaud;
        private System.Windows.Forms.ComboBox cbboxPort;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnRefur;
        private System.Windows.Forms.TextBox tboxShow;
        private System.Windows.Forms.GroupBox gboxSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tboxSend;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.Label lblS;
        private System.Windows.Forms.Button btnMCClear;
        private System.Windows.Forms.RadioButton rbSelected;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.Button btnMCSubOne;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.CheckBox cboxHEXReceive;
        private System.Windows.Forms.CheckBox cboxHEXSend;
        private System.Windows.Forms.Label lblT;
        private System.Windows.Forms.CheckBox cboxMCCircle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tboxTimes;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem RightClik_C;
        private System.Windows.Forms.ToolStripMenuItem RightClik_A;
        private System.Windows.Forms.ToolStripMenuItem RightClik_V;
        private System.Windows.Forms.CheckBox cboxShowTime;
        private System.Windows.Forms.ToolStripMenuItem RightClik_D;
        private System.Windows.Forms.ToolStripMenuItem RightClik_S;
    }
}

