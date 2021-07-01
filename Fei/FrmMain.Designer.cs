namespace Fei
{
    partial class FrmMain
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabSearch = new System.Windows.Forms.TabPage();
            this.tabData = new System.Windows.Forms.TabPage();
            this.tabOnline = new System.Windows.Forms.TabPage();
            this.btnYesTalk = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPunish = new System.Windows.Forms.TextBox();
            this.lblOnlineCount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnNoTalk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClearShow = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnSendMsg = new System.Windows.Forms.Button();
            this.txtShow = new System.Windows.Forms.TextBox();
            this.btnWatch = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnKickOut = new System.Windows.Forms.Button();
            this.lvFriends = new System.Windows.Forms.ListView();
            this.btnWarning = new System.Windows.Forms.Button();
            this.tabRunM = new System.Windows.Forms.TabPage();
            this.btnBegin = new System.Windows.Forms.Button();
            this.chkAlReg = new System.Windows.Forms.CheckBox();
            this.chkAlLogin = new System.Windows.Forms.CheckBox();
            this.chkAlConnect = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSaveLog = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboMaxCount = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNowCount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSerProtocol = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSerPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSerIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStatu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabOnline.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabRunM.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSearch
            // 
            this.tabSearch.Location = new System.Drawing.Point(4, 21);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Size = new System.Drawing.Size(748, 430);
            this.tabSearch.TabIndex = 3;
            this.tabSearch.Text = "数据查询";
            this.tabSearch.UseVisualStyleBackColor = true;
            // 
            // tabData
            // 
            this.tabData.Location = new System.Drawing.Point(4, 21);
            this.tabData.Name = "tabData";
            this.tabData.Size = new System.Drawing.Size(748, 430);
            this.tabData.TabIndex = 2;
            this.tabData.Text = "数据管理";
            this.tabData.UseVisualStyleBackColor = true;
            // 
            // tabOnline
            // 
            this.tabOnline.Controls.Add(this.btnYesTalk);
            this.tabOnline.Controls.Add(this.label11);
            this.tabOnline.Controls.Add(this.txtPunish);
            this.tabOnline.Controls.Add(this.lblOnlineCount);
            this.tabOnline.Controls.Add(this.label9);
            this.tabOnline.Controls.Add(this.btnNoTalk);
            this.tabOnline.Controls.Add(this.groupBox1);
            this.tabOnline.Controls.Add(this.btnKickOut);
            this.tabOnline.Controls.Add(this.lvFriends);
            this.tabOnline.Controls.Add(this.btnWarning);
            this.tabOnline.Location = new System.Drawing.Point(4, 21);
            this.tabOnline.Name = "tabOnline";
            this.tabOnline.Padding = new System.Windows.Forms.Padding(3);
            this.tabOnline.Size = new System.Drawing.Size(748, 430);
            this.tabOnline.TabIndex = 1;
            this.tabOnline.Text = "在线管理";
            this.tabOnline.UseVisualStyleBackColor = true;
            // 
            // btnYesTalk
            // 
            this.btnYesTalk.Location = new System.Drawing.Point(86, 399);
            this.btnYesTalk.Name = "btnYesTalk";
            this.btnYesTalk.Size = new System.Drawing.Size(44, 23);
            this.btnYesTalk.TabIndex = 32;
            this.btnYesTalk.Text = "恢复";
            this.btnYesTalk.UseVisualStyleBackColor = true;
            this.btnYesTalk.Click += new System.EventHandler(this.btnYesTalk_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 344);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 31;
            this.label11.Text = "惩罚原因↓";
            // 
            // txtPunish
            // 
            this.txtPunish.Location = new System.Drawing.Point(6, 359);
            this.txtPunish.Multiline = true;
            this.txtPunish.Name = "txtPunish";
            this.txtPunish.Size = new System.Drawing.Size(175, 34);
            this.txtPunish.TabIndex = 27;
            this.txtPunish.Text = "惩罚原因";
            // 
            // lblOnlineCount
            // 
            this.lblOnlineCount.AutoSize = true;
            this.lblOnlineCount.Location = new System.Drawing.Point(167, 344);
            this.lblOnlineCount.Name = "lblOnlineCount";
            this.lblOnlineCount.Size = new System.Drawing.Size(11, 12);
            this.lblOnlineCount.TabIndex = 30;
            this.lblOnlineCount.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(92, 344);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 29;
            this.label9.Text = "总在线人数：";
            // 
            // btnNoTalk
            // 
            this.btnNoTalk.Location = new System.Drawing.Point(46, 399);
            this.btnNoTalk.Name = "btnNoTalk";
            this.btnNoTalk.Size = new System.Drawing.Size(37, 23);
            this.btnNoTalk.TabIndex = 28;
            this.btnNoTalk.Text = "禁言";
            this.btnNoTalk.UseVisualStyleBackColor = true;
            this.btnNoTalk.Click += new System.EventHandler(this.btnNoTalk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClearShow);
            this.groupBox1.Controls.Add(this.txtInput);
            this.groupBox1.Controls.Add(this.btnSendMsg);
            this.groupBox1.Controls.Add(this.txtShow);
            this.groupBox1.Controls.Add(this.btnWatch);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Location = new System.Drawing.Point(189, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(554, 424);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "聊天区域";
            // 
            // btnClearShow
            // 
            this.btnClearShow.Location = new System.Drawing.Point(416, 395);
            this.btnClearShow.Name = "btnClearShow";
            this.btnClearShow.Size = new System.Drawing.Size(62, 23);
            this.btnClearShow.TabIndex = 26;
            this.btnClearShow.Text = "清 屏";
            this.btnClearShow.UseVisualStyleBackColor = true;
            this.btnClearShow.Click += new System.EventHandler(this.btnClearShow_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(6, 273);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(540, 117);
            this.txtInput.TabIndex = 20;
            // 
            // btnSendMsg
            // 
            this.btnSendMsg.Location = new System.Drawing.Point(483, 395);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(63, 23);
            this.btnSendMsg.TabIndex = 19;
            this.btnSendMsg.Text = "发送消息";
            this.btnSendMsg.UseVisualStyleBackColor = true;
            this.btnSendMsg.Click += new System.EventHandler(this.btnSendMsg_Click);
            // 
            // txtShow
            // 
            this.txtShow.BackColor = System.Drawing.Color.White;
            this.txtShow.Location = new System.Drawing.Point(6, 48);
            this.txtShow.Multiline = true;
            this.txtShow.Name = "txtShow";
            this.txtShow.ReadOnly = true;
            this.txtShow.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtShow.Size = new System.Drawing.Size(540, 219);
            this.txtShow.TabIndex = 18;
            this.txtShow.Text = "聊天信息：";
            // 
            // btnWatch
            // 
            this.btnWatch.Location = new System.Drawing.Point(158, 17);
            this.btnWatch.Name = "btnWatch";
            this.btnWatch.Size = new System.Drawing.Size(75, 23);
            this.btnWatch.TabIndex = 17;
            this.btnWatch.Text = "启动监听";
            this.btnWatch.UseVisualStyleBackColor = true;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(110, 20);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(41, 21);
            this.txtPort.TabIndex = 16;
            this.txtPort.Text = "10001";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(6, 20);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 21);
            this.txtIP.TabIndex = 15;
            this.txtIP.Text = "127.0.0.1";
            // 
            // btnKickOut
            // 
            this.btnKickOut.Location = new System.Drawing.Point(133, 399);
            this.btnKickOut.Name = "btnKickOut";
            this.btnKickOut.Size = new System.Drawing.Size(44, 23);
            this.btnKickOut.TabIndex = 27;
            this.btnKickOut.Text = "踢人";
            this.btnKickOut.UseVisualStyleBackColor = true;
            this.btnKickOut.Click += new System.EventHandler(this.btnKickOut_Click);
            // 
            // lvFriends
            // 
            this.lvFriends.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvFriends.HideSelection = false;
            this.lvFriends.Location = new System.Drawing.Point(6, 7);
            this.lvFriends.Name = "lvFriends";
            this.lvFriends.Size = new System.Drawing.Size(177, 334);
            this.lvFriends.TabIndex = 2;
            this.lvFriends.UseCompatibleStateImageBehavior = false;
            this.lvFriends.View = System.Windows.Forms.View.List;
            // 
            // btnWarning
            // 
            this.btnWarning.Location = new System.Drawing.Point(6, 399);
            this.btnWarning.Name = "btnWarning";
            this.btnWarning.Size = new System.Drawing.Size(37, 23);
            this.btnWarning.TabIndex = 26;
            this.btnWarning.Text = "警告";
            this.btnWarning.UseVisualStyleBackColor = true;
            this.btnWarning.Click += new System.EventHandler(this.btnWarning_Click);
            // 
            // tabRunM
            // 
            this.tabRunM.Controls.Add(this.btnBegin);
            this.tabRunM.Controls.Add(this.chkAlReg);
            this.tabRunM.Controls.Add(this.chkAlLogin);
            this.tabRunM.Controls.Add(this.chkAlConnect);
            this.tabRunM.Controls.Add(this.label8);
            this.tabRunM.Controls.Add(this.btnSaveLog);
            this.tabRunM.Controls.Add(this.btnClearLog);
            this.tabRunM.Controls.Add(this.groupBox2);
            this.tabRunM.Controls.Add(this.btnClose);
            this.tabRunM.Controls.Add(this.btnPause);
            this.tabRunM.Controls.Add(this.groupBox3);
            this.tabRunM.Location = new System.Drawing.Point(4, 21);
            this.tabRunM.Name = "tabRunM";
            this.tabRunM.Padding = new System.Windows.Forms.Padding(3);
            this.tabRunM.Size = new System.Drawing.Size(748, 430);
            this.tabRunM.TabIndex = 0;
            this.tabRunM.Text = "运行管理";
            this.tabRunM.UseVisualStyleBackColor = true;
            // 
            // btnBegin
            // 
            this.btnBegin.Location = new System.Drawing.Point(77, 396);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(37, 23);
            this.btnBegin.TabIndex = 10;
            this.btnBegin.Text = "开始";
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // chkAlReg
            // 
            this.chkAlReg.AutoSize = true;
            this.chkAlReg.Location = new System.Drawing.Point(373, 398);
            this.chkAlReg.Name = "chkAlReg";
            this.chkAlReg.Size = new System.Drawing.Size(48, 16);
            this.chkAlReg.TabIndex = 9;
            this.chkAlReg.Text = "注册";
            this.chkAlReg.UseVisualStyleBackColor = true;
            // 
            // chkAlLogin
            // 
            this.chkAlLogin.AutoSize = true;
            this.chkAlLogin.Location = new System.Drawing.Point(309, 398);
            this.chkAlLogin.Name = "chkAlLogin";
            this.chkAlLogin.Size = new System.Drawing.Size(48, 16);
            this.chkAlLogin.TabIndex = 8;
            this.chkAlLogin.Text = "登陆";
            this.chkAlLogin.UseVisualStyleBackColor = true;
            // 
            // chkAlConnect
            // 
            this.chkAlConnect.AutoSize = true;
            this.chkAlConnect.Location = new System.Drawing.Point(255, 398);
            this.chkAlConnect.Name = "chkAlConnect";
            this.chkAlConnect.Size = new System.Drawing.Size(48, 16);
            this.chkAlConnect.TabIndex = 7;
            this.chkAlConnect.Text = "连接";
            this.chkAlConnect.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(183, 400);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "允许用户：";
            // 
            // btnSaveLog
            // 
            this.btnSaveLog.Location = new System.Drawing.Point(264, 363);
            this.btnSaveLog.Name = "btnSaveLog";
            this.btnSaveLog.Size = new System.Drawing.Size(75, 23);
            this.btnSaveLog.TabIndex = 5;
            this.btnSaveLog.Text = "保存日志";
            this.btnSaveLog.UseVisualStyleBackColor = true;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(179, 363);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(75, 23);
            this.btnClearLog.TabIndex = 4;
            this.btnClearLog.Text = "清 屏";
            this.btnClearLog.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtLog);
            this.groupBox2.Location = new System.Drawing.Point(176, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(566, 342);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "服务器日志：";
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.White;
            this.txtLog.Location = new System.Drawing.Point(6, 15);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(554, 318);
            this.txtLog.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(120, 396);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(44, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(24, 396);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(48, 23);
            this.btnPause.TabIndex = 1;
            this.btnPause.Text = "暂停";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.cboMaxCount);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtNowCount);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtSerProtocol);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtSerPort);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtSerIP);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtSerName);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtStatu);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(15, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(155, 372);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "服务器信息";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(123, 343);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "人";
            // 
            // cboMaxCount
            // 
            this.cboMaxCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaxCount.FormattingEnabled = true;
            this.cboMaxCount.Items.AddRange(new object[] {
            "50",
            "40",
            "30",
            "20",
            "10",
            "5"});
            this.cboMaxCount.Location = new System.Drawing.Point(9, 340);
            this.cboMaxCount.Name = "cboMaxCount";
            this.cboMaxCount.Size = new System.Drawing.Size(109, 20);
            this.cboMaxCount.TabIndex = 13;
            this.cboMaxCount.SelectedIndexChanged += new System.EventHandler(this.cboMaxCount_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 324);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "最大负荷(限制)：";
            // 
            // txtNowCount
            // 
            this.txtNowCount.Location = new System.Drawing.Point(9, 290);
            this.txtNowCount.Name = "txtNowCount";
            this.txtNowCount.Size = new System.Drawing.Size(140, 21);
            this.txtNowCount.TabIndex = 11;
            this.txtNowCount.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 274);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "当前连接负荷：";
            // 
            // txtSerProtocol
            // 
            this.txtSerProtocol.Location = new System.Drawing.Point(9, 239);
            this.txtSerProtocol.Name = "txtSerProtocol";
            this.txtSerProtocol.Size = new System.Drawing.Size(140, 21);
            this.txtSerProtocol.TabIndex = 9;
            this.txtSerProtocol.Text = "Tcp";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "访问协议：";
            // 
            // txtSerPort
            // 
            this.txtSerPort.Location = new System.Drawing.Point(9, 188);
            this.txtSerPort.Name = "txtSerPort";
            this.txtSerPort.Size = new System.Drawing.Size(140, 21);
            this.txtSerPort.TabIndex = 7;
            this.txtSerPort.Text = "51001";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "端口：";
            // 
            // txtSerIP
            // 
            this.txtSerIP.Location = new System.Drawing.Point(9, 139);
            this.txtSerIP.Name = "txtSerIP";
            this.txtSerIP.Size = new System.Drawing.Size(140, 21);
            this.txtSerIP.TabIndex = 5;
            this.txtSerIP.Text = "127.0.0.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "服务器IP：";
            // 
            // txtSerName
            // 
            this.txtSerName.Location = new System.Drawing.Point(9, 88);
            this.txtSerName.Name = "txtSerName";
            this.txtSerName.Size = new System.Drawing.Size(140, 21);
            this.txtSerName.TabIndex = 3;
            this.txtSerName.Text = "JZPC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "服务器名称：";
            // 
            // txtStatu
            // 
            this.txtStatu.Location = new System.Drawing.Point(9, 37);
            this.txtStatu.Name = "txtStatu";
            this.txtStatu.Size = new System.Drawing.Size(140, 21);
            this.txtStatu.TabIndex = 1;
            this.txtStatu.Text = "停止";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "状态：";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabRunM);
            this.tabControl1.Controls.Add(this.tabOnline);
            this.tabControl1.Controls.Add(this.tabData);
            this.tabControl1.Controls.Add(this.tabSearch);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(756, 455);
            this.tabControl1.TabIndex = 2;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 474);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主面板";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.tabOnline.ResumeLayout(false);
            this.tabOnline.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabRunM.ResumeLayout(false);
            this.tabRunM.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabSearch;
        private System.Windows.Forms.TabPage tabData;
        private System.Windows.Forms.TabPage tabOnline;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnSendMsg;
        private System.Windows.Forms.TextBox txtShow;
        private System.Windows.Forms.Button btnWatch;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.ListView lvFriends;
        private System.Windows.Forms.TabPage tabRunM;
        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.CheckBox chkAlReg;
        private System.Windows.Forms.CheckBox chkAlLogin;
        private System.Windows.Forms.CheckBox chkAlConnect;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSaveLog;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboMaxCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNowCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSerProtocol;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSerPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSerIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStatu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnNoTalk;
        private System.Windows.Forms.Button btnKickOut;
        private System.Windows.Forms.Button btnWarning;
        private System.Windows.Forms.Label lblOnlineCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnClearShow;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPunish;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnYesTalk;


    }
}

