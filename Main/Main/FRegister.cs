using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public partial class FRegister : Form
    {
        sql s = new sql();
        FLandWidget fLandWidget = new FLandWidget();
        //public Action<FRegister> CloseEditFrom { get; set; }
        public FRegister()
        {
            InitializeComponent();
            // s.createNewDatabase();
            s.connectToDatabase();
            s.createTable();
            s.createTable3();
        }
        private void uiButton1_Click(object sender, EventArgs e)
        {


            if (uiTextBox1.TextLength > 16)
            {
                MessageBox.Show("用户名太长，我怕你记不住，请换个短的吧！", "提示");
            }
            else if (uiTextBox2.Text != uiTextBox3.Text)
            {
                MessageBox.Show("两次输入的密码不一致！", "提示");
                uiTextBox2.Text = "";
                uiTextBox3.Text = "";
            }
            else if (uiTextBox1.Text == "" || uiTextBox2.Text == "")
            {
                MessageBox.Show("用户名或密码不能为空！", "提示");
            }

            else if (s.select1(uiTextBox1.Text) == 0)
            {
                s.fillTable(uiTextBox1.Text, uiTextBox2.Text);
                s.fillTable2(uiTextBox1.Text, uiTextBox5.Text, uiTextBox4.Text, uiTextBox6.Text);
                s.fillTable3(uiTextBox1.Text, bytetostring(GetByteImage(uiImageButton2.Image)));
                this.Close();
                fLandWidget.ShowDialog();
            }
            //bytetostring(GetByteImage(uiImageButton2.Image))
            //con.Close();
        }
        private void uiButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            fLandWidget.Show();
        }

        private void uiImageButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string name = uiTextBox1.Text;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string temp = openFileDialog.FileName;
                uiImageButton2.SizeMode = PictureBoxSizeMode.StretchImage;
                uiImageButton2.BackgroundImageLayout = ImageLayout.Stretch;
               // MessageBox.Show(temp);
                uiImageButton2.Image = new Bitmap(@temp);
                // Name = temp;
            }
            //bytetostring(GetByteImage(uiImageButton2.Image))
            try
            {
                //s.fillTable3(name, bytetostring(GetByteImage(uiImageButton2.Image)));
                MessageBox.Show("上传成功");
            }
            catch (Exception)
            {
                MessageBox.Show("请选择图片");
            }
        }

        public string bytetostring(byte[] bytes)
        {
            string str = Convert.ToBase64String(bytes);
            return str;
        }
        public byte[] GetByteImage(Image img)
        {
            byte[] bt = null;
            if (!img.Equals(null))
            {
                using (MemoryStream mostream = new MemoryStream())
                {
                    Bitmap bmp = new Bitmap(img);
                    bmp.Save(mostream, System.Drawing.Imaging.ImageFormat.Bmp);//将图像以指定的格式存入缓存内存流

                    bt = new byte[mostream.Length];
                    mostream.Position = 0;//设置留的初始位置
                    mostream.Read(bt, 0, Convert.ToInt32(bt.Length));
                }
            }
            return bt;
        }

      
    }
}


