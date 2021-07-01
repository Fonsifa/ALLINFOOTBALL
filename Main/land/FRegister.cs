using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
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
            this.BackgroundImage = Image.FromFile("D:/vs_test/作业/Main/bgg.jpeg");
           // s.createNewDatabase();
            s.connectToDatabase();
            s.createTable();
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

            else if(s.select1(uiTextBox1.Text)==0)
            {
                s.fillTable(uiTextBox1.Text, uiTextBox2.Text);
                s.fillTable2(uiTextBox1.Text, uiTextBox5.Text, uiTextBox4.Text, uiTextBox6.Text);
                this.Close();
                fLandWidget.ShowDialog();
            }
            //con.Close();
        }
        private void uiButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            fLandWidget.Show();
        }

        private void uiLabel4_Click(object sender, EventArgs e)
        {

        }

        private void uiLabel2_Click(object sender, EventArgs e)
        {

        }

        //private void FRegister_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //   fLandWidget.Close();
        //}
    }
    }


