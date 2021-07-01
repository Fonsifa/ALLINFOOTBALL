
namespace Main
{
    partial class FLandWidget
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FLandWidget));
            this.sing = new Sunny.UI.UIButton();
            this.register = new Sunny.UI.UIButton();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiTextBox1 = new Sunny.UI.UITextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiTextBox2 = new Sunny.UI.UITextBox();
            this.uiImageButton1 = new Sunny.UI.UIImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // sing
            // 
            this.sing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sing.FillColor = System.Drawing.Color.Black;
            this.sing.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.sing.ForeDisableColor = System.Drawing.Color.Black;
            this.sing.Location = new System.Drawing.Point(191, 480);
            this.sing.MinimumSize = new System.Drawing.Size(1, 1);
            this.sing.Name = "sing";
            this.sing.Size = new System.Drawing.Size(100, 35);
            this.sing.Style = Sunny.UI.UIStyle.Custom;
            this.sing.TabIndex = 0;
            this.sing.Text = "登录";
            this.sing.Click += new System.EventHandler(this.sing_Click);
            // 
            // register
            // 
            this.register.Cursor = System.Windows.Forms.Cursors.Hand;
            this.register.FillColor = System.Drawing.Color.WhiteSmoke;
            this.register.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.register.ForeColor = System.Drawing.Color.Black;
            this.register.ForeHoverColor = System.Drawing.Color.Black;
            this.register.Location = new System.Drawing.Point(458, 480);
            this.register.MinimumSize = new System.Drawing.Size(1, 1);
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(100, 35);
            this.register.Style = Sunny.UI.UIStyle.Custom;
            this.register.TabIndex = 1;
            this.register.Text = "注册";
            this.register.TipsColor = System.Drawing.Color.Black;
            this.register.Click += new System.EventHandler(this.register_Click);
            // 
            // uiLabel1
            // 
            this.uiLabel1.BackColor = System.Drawing.Color.GreenYellow;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(115, 123);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(60, 40);
            this.uiLabel1.TabIndex = 2;
            this.uiLabel1.Text = "账号";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTextBox1
            // 
            this.uiTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox1.FillColor = System.Drawing.Color.White;
            this.uiTextBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiTextBox1.Location = new System.Drawing.Point(228, 123);
            this.uiTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox1.Maximum = 2147483647D;
            this.uiTextBox1.Minimum = -2147483648D;
            this.uiTextBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTextBox1.Name = "uiTextBox1";
            this.uiTextBox1.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox1.Size = new System.Drawing.Size(424, 34);
            this.uiTextBox1.TabIndex = 3;
            this.uiTextBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.BackColor = System.Drawing.Color.GreenYellow;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(115, 318);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(60, 40);
            this.uiLabel2.TabIndex = 2;
            this.uiLabel2.Text = "密码";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTextBox2
            // 
            this.uiTextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox2.FillColor = System.Drawing.Color.White;
            this.uiTextBox2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiTextBox2.Location = new System.Drawing.Point(228, 324);
            this.uiTextBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox2.Maximum = 2147483647D;
            this.uiTextBox2.Minimum = -2147483648D;
            this.uiTextBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTextBox2.Name = "uiTextBox2";
            this.uiTextBox2.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox2.PasswordChar = '*';
            this.uiTextBox2.Size = new System.Drawing.Size(424, 34);
            this.uiTextBox2.TabIndex = 2;
            this.uiTextBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiImageButton1
            // 
            this.uiImageButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiImageButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiImageButton1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("uiImageButton1.Image")));
            this.uiImageButton1.Location = new System.Drawing.Point(0, 0);
            this.uiImageButton1.MaximumSize = new System.Drawing.Size(1004, 590);
            this.uiImageButton1.MinimumSize = new System.Drawing.Size(1004, 590);
            this.uiImageButton1.Name = "uiImageButton1";
            this.uiImageButton1.Size = new System.Drawing.Size(1004, 590);
            this.uiImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.uiImageButton1.TabIndex = 4;
            this.uiImageButton1.TabStop = false;
            this.uiImageButton1.Text = null;
            // 
            // FLandWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 590);
            this.Controls.Add(this.uiTextBox2);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiTextBox1);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.register);
            this.Controls.Add(this.sing);
            this.Controls.Add(this.uiImageButton1);
            this.MaximumSize = new System.Drawing.Size(1022, 637);
            this.MinimizeBox = false;
            this.Name = "FLandWidget";
            this.Text = "登录";
            this.Load += new System.EventHandler(this.FLandWidget_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIButton sing;
        private Sunny.UI.UIButton register;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox uiTextBox2;
        private Sunny.UI.UIImageButton uiImageButton1;
        public Sunny.UI.UITextBox uiTextBox1;
    }
}

