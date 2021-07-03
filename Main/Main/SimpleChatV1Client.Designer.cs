namespace Main
{
    partial class SimpleChatV1Client
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
            this.txtMsgPublic = new System.Windows.Forms.TextBox();
            this.btnSendMsg = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMyUID = new System.Windows.Forms.Label();
            this.btnClearPrivate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMood = new System.Windows.Forms.ComboBox();
            this.chkPrivateTalk = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnShake = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMsgPublic
            // 
            this.txtMsgPublic.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtMsgPublic.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMsgPublic.ForeColor = System.Drawing.Color.Black;
            this.txtMsgPublic.Location = new System.Drawing.Point(8, 60);
            this.txtMsgPublic.Margin = new System.Windows.Forms.Padding(4);
            this.txtMsgPublic.Multiline = true;
            this.txtMsgPublic.Name = "txtMsgPublic";
            this.txtMsgPublic.ReadOnly = true;
            this.txtMsgPublic.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsgPublic.Size = new System.Drawing.Size(625, 450);
            this.txtMsgPublic.TabIndex = 7;
            this.txtMsgPublic.TextChanged += new System.EventHandler(this.txtMsgPublic_TextChanged);
            // 
            // btnSendMsg
            // 
            this.btnSendMsg.Location = new System.Drawing.Point(558, 676);
            this.btnSendMsg.Margin = new System.Windows.Forms.Padding(4);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(88, 29);
            this.btnSendMsg.TabIndex = 8;
            this.btnSendMsg.Text = "发送消息";
            this.btnSendMsg.UseVisualStyleBackColor = true;
            this.btnSendMsg.Click += new System.EventHandler(this.btnSendMsg_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(8, 550);
            this.txtInput.Margin = new System.Windows.Forms.Padding(4);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(625, 108);
            this.txtInput.TabIndex = 9;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(538, 727);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(108, 29);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "退 出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblMyUID);
            this.groupBox1.Controls.Add(this.btnClearPrivate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboMood);
            this.groupBox1.Controls.Add(this.chkPrivateTalk);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtInput);
            this.groupBox1.Controls.Add(this.txtMsgPublic);
            this.groupBox1.Location = new System.Drawing.Point(13, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(642, 666);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "聊天区";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 28);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 15);
            this.label6.TabIndex = 32;
            this.label6.Text = "UID：";
            // 
            // lblMyUID
            // 
            this.lblMyUID.AutoSize = true;
            this.lblMyUID.Location = new System.Drawing.Point(54, 28);
            this.lblMyUID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMyUID.Name = "lblMyUID";
            this.lblMyUID.Size = new System.Drawing.Size(75, 15);
            this.lblMyUID.TabIndex = 18;
            this.lblMyUID.Text = "尚未连接.";
            // 
            // btnClearPrivate
            // 
            this.btnClearPrivate.Location = new System.Drawing.Point(550, 518);
            this.btnClearPrivate.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearPrivate.Name = "btnClearPrivate";
            this.btnClearPrivate.Size = new System.Drawing.Size(83, 29);
            this.btnClearPrivate.TabIndex = 31;
            this.btnClearPrivate.Text = "清屏↑";
            this.btnClearPrivate.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 526);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "说：";
            // 
            // cboMood
            // 
            this.cboMood.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMood.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboMood.FormattingEnabled = true;
            this.cboMood.Location = new System.Drawing.Point(137, 519);
            this.cboMood.Margin = new System.Windows.Forms.Padding(4);
            this.cboMood.Name = "cboMood";
            this.cboMood.Size = new System.Drawing.Size(108, 28);
            this.cboMood.TabIndex = 15;
            // 
            // chkPrivateTalk
            // 
            this.chkPrivateTalk.AutoSize = true;
            this.chkPrivateTalk.Location = new System.Drawing.Point(40, 522);
            this.chkPrivateTalk.Margin = new System.Windows.Forms.Padding(4);
            this.chkPrivateTalk.Name = "chkPrivateTalk";
            this.chkPrivateTalk.Size = new System.Drawing.Size(89, 19);
            this.chkPrivateTalk.TabIndex = 11;
            this.chkPrivateTalk.Text = "悄悄的：";
            this.chkPrivateTalk.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 524);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "你";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 720);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "其他功能：";
            // 
            // btnShake
            // 
            this.btnShake.Location = new System.Drawing.Point(114, 720);
            this.btnShake.Margin = new System.Windows.Forms.Padding(4);
            this.btnShake.Name = "btnShake";
            this.btnShake.Size = new System.Drawing.Size(117, 29);
            this.btnShake.TabIndex = 30;
            this.btnShake.Text = "发送窗口抖动";
            this.btnShake.UseVisualStyleBackColor = true;
            this.btnShake.Click += new System.EventHandler(this.btnShake_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.BackColor = System.Drawing.Color.LavenderBlush;
            this.txtFilePath.Location = new System.Drawing.Point(114, 680);
            this.txtFilePath.Margin = new System.Windows.Forms.Padding(4);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(210, 25);
            this.txtFilePath.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 685);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 32;
            this.label5.Text = "文件路径：";
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(430, 676);
            this.btnSendFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(85, 29);
            this.btnSendFile.TabIndex = 29;
            this.btnSendFile.Text = "发送文件";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(332, 677);
            this.btnChooseFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(81, 29);
            this.btnChooseFile.TabIndex = 27;
            this.btnChooseFile.Text = "选择文件";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // SimpleChatV1Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(672, 769);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSendMsg);
            this.Controls.Add(this.btnSendFile);
            this.Controls.Add(this.btnChooseFile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnShake);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SimpleChatV1Client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "客户端";
            this.Load += new System.EventHandler(this.SimpleChatV1Client_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMsgPublic;
        private System.Windows.Forms.Button btnSendMsg;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkPrivateTalk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMood;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClearPrivate;
        private System.Windows.Forms.Button btnShake;
        private System.Windows.Forms.Label lblMyUID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.Button btnChooseFile;
    }
}

