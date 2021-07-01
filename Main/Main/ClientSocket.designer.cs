namespace SocketDemo
{
    partial class ClientSocket
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_start = new System.Windows.Forms.Button();
            this.tb_Point = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_IP = new System.Windows.Forms.TextBox();
            this.rtb_sendmsg = new System.Windows.Forms.RichTextBox();
            this.rtb_log = new System.Windows.Forms.RichTextBox();
            this.bt_send = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.tp_news = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ltb_Image = new System.Windows.Forms.ListBox();
            this.tbp_image = new System.Windows.Forms.TabPage();
            this.bt_SendImage = new System.Windows.Forms.Button();
            this.bt_OpeImage = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pt_Image = new System.Windows.Forms.PictureBox();
            this.tp_news.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pt_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_start
            // 
            this.bt_start.Location = new System.Drawing.Point(570, 23);
            this.bt_start.Name = "bt_start";
            this.bt_start.Size = new System.Drawing.Size(75, 23);
            this.bt_start.TabIndex = 11;
            this.bt_start.Text = "连接";
            this.bt_start.UseVisualStyleBackColor = true;
            this.bt_start.Click += new System.EventHandler(this.bt_start_Click);
            // 
            // tb_Point
            // 
            this.tb_Point.Location = new System.Drawing.Point(298, 25);
            this.tb_Point.Name = "tb_Point";
            this.tb_Point.Size = new System.Drawing.Size(66, 21);
            this.tb_Point.TabIndex = 7;
            this.tb_Point.Text = "50000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "IP地址：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "端口号：";
            // 
            // tb_IP
            // 
            this.tb_IP.Location = new System.Drawing.Point(76, 25);
            this.tb_IP.Name = "tb_IP";
            this.tb_IP.Size = new System.Drawing.Size(151, 21);
            this.tb_IP.TabIndex = 6;
            this.tb_IP.Text = "127.0.0.1";
            // 
            // rtb_sendmsg
            // 
            this.rtb_sendmsg.Location = new System.Drawing.Point(30, 326);
            this.rtb_sendmsg.Name = "rtb_sendmsg";
            this.rtb_sendmsg.Size = new System.Drawing.Size(385, 24);
            this.rtb_sendmsg.TabIndex = 13;
            this.rtb_sendmsg.Text = "";
            // 
            // rtb_log
            // 
            this.rtb_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_log.Location = new System.Drawing.Point(3, 3);
            this.rtb_log.Name = "rtb_log";
            this.rtb_log.Size = new System.Drawing.Size(374, 236);
            this.rtb_log.TabIndex = 12;
            this.rtb_log.Text = "";
            // 
            // bt_send
            // 
            this.bt_send.Location = new System.Drawing.Point(325, 366);
            this.bt_send.Name = "bt_send";
            this.bt_send.Size = new System.Drawing.Size(75, 23);
            this.bt_send.TabIndex = 14;
            this.bt_send.Text = "发送消息";
            this.bt_send.UseVisualStyleBackColor = true;
            this.bt_send.Click += new System.EventHandler(this.bt_send_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(376, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "设置昵称：";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(447, 25);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(86, 21);
            this.tb_name.TabIndex = 15;
            // 
            // tp_news
            // 
            this.tp_news.Controls.Add(this.tabPage1);
            this.tp_news.Controls.Add(this.tbp_image);
            this.tp_news.Location = new System.Drawing.Point(30, 52);
            this.tp_news.Name = "tp_news";
            this.tp_news.SelectedIndex = 0;
            this.tp_news.Size = new System.Drawing.Size(388, 268);
            this.tp_news.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rtb_log);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(380, 242);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "消息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ltb_Image
            // 
            this.ltb_Image.FormattingEnabled = true;
            this.ltb_Image.ItemHeight = 12;
            this.ltb_Image.Location = new System.Drawing.Point(424, 74);
            this.ltb_Image.Name = "ltb_Image";
            this.ltb_Image.Size = new System.Drawing.Size(205, 112);
            this.ltb_Image.TabIndex = 19;
            this.ltb_Image.SelectedIndexChanged += new System.EventHandler(this.ltb_Image_SelectedIndexChanged);
            // 
            // tbp_image
            // 
            this.tbp_image.Location = new System.Drawing.Point(4, 22);
            this.tbp_image.Name = "tbp_image";
            this.tbp_image.Size = new System.Drawing.Size(376, 176);
            this.tbp_image.TabIndex = 1;
            this.tbp_image.Text = "图片";
            this.tbp_image.UseVisualStyleBackColor = true;
            // 
            // bt_SendImage
            // 
            this.bt_SendImage.Location = new System.Drawing.Point(540, 327);
            this.bt_SendImage.Name = "bt_SendImage";
            this.bt_SendImage.Size = new System.Drawing.Size(75, 23);
            this.bt_SendImage.TabIndex = 20;
            this.bt_SendImage.Text = "发送图片";
            this.bt_SendImage.UseVisualStyleBackColor = true;
            this.bt_SendImage.Click += new System.EventHandler(this.bt_SendImage_Click);
            // 
            // bt_OpeImage
            // 
            this.bt_OpeImage.Location = new System.Drawing.Point(433, 327);
            this.bt_OpeImage.Name = "bt_OpeImage";
            this.bt_OpeImage.Size = new System.Drawing.Size(75, 23);
            this.bt_OpeImage.TabIndex = 19;
            this.bt_OpeImage.Text = "选择";
            this.bt_OpeImage.UseVisualStyleBackColor = true;
            this.bt_OpeImage.Click += new System.EventHandler(this.bt_OpeImage_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(406, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "接收图片：";
            // 
            // pt_Image
            // 
            this.pt_Image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;

            this.pt_Image.Location = new System.Drawing.Point(424, 197);
            this.pt_Image.Name = "pt_Image";
            this.pt_Image.Size = new System.Drawing.Size(205, 123);
            this.pt_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pt_Image.TabIndex = 18;
            this.pt_Image.TabStop = false;
            // 
            // ClientSocket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 401);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ltb_Image);
            this.Controls.Add(this.bt_SendImage);
            this.Controls.Add(this.bt_OpeImage);
            this.Controls.Add(this.tp_news);
            this.Controls.Add(this.pt_Image);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.bt_send);
            this.Controls.Add(this.rtb_sendmsg);
            this.Controls.Add(this.bt_start);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_Point);
            this.Controls.Add(this.tb_IP);
            this.Name = "ClientSocket";
            this.Text = "ClientSocket";
            this.tp_news.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pt_Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_start;
        private System.Windows.Forms.TextBox tb_Point;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_IP;
        private System.Windows.Forms.RichTextBox rtb_sendmsg;
        private System.Windows.Forms.RichTextBox rtb_log;
        private System.Windows.Forms.Button bt_send;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.TabControl tp_news;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListBox ltb_Image;
        private System.Windows.Forms.PictureBox pt_Image;
        private System.Windows.Forms.TabPage tbp_image;
        private System.Windows.Forms.Button bt_SendImage;
        private System.Windows.Forms.Button bt_OpeImage;
        private System.Windows.Forms.Label label4;
    }
}