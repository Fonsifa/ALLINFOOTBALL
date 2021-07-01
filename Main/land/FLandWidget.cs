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
    public partial class FLandWidget : Form
    {
        SQLiteConnection m_dbConnection;
        sql s = new sql();
        // private string id;
        //public Action<FRegister> ShowFRegister { get; set; }
        public string getuiTextBox()
        {
            return this.uiTextBox1.Text;
        }
        public FLandWidget()
        {
            
            InitializeComponent();
            //s.createNewDatabase();
            s.connectToDatabase();
            s.createTable();
            s.createTable2();

        }
   

        public void sing_Click(object sender, EventArgs e)
        {
            string myName = uiTextBox1.Text;
            string myPassword = uiTextBox2.Text;
            try
            {
                if (uiTextBox1.Text == "")
                {
                    MessageBox.Show("用户名不能为空");
                }
                else
                {
                    if (uiTextBox2.Text == "")
                    {
                        MessageBox.Show("密码不能为空!");
                    }
                    else
                    {
                        Program.loginid = myName;
                        s.select(myName,myPassword);
                        this.Hide();
                    }
                }
        }
            catch (Exception ex)
            {
                MessageBox.Show("异常错误" + ex);
            }
            /*
            OleDbConnection myconn = new OleDbConnection();
            mystr = @"Provider=Microsoft.ACE.OLEDB.12.0;
              Data Source=D:\shixun\Database1_be.accdb";
            myconn.ConnectionString = mystr;
            myconn.Open();
            // string  mysql;
            // shujuku shujuku1=new shujuku();
            //OleDbConnection myconn=shujuku1.lianjieshujuku();
            mysql = "SELECT * FROM 登陆 WHERE 账号='" + uiTextBox1.Text + "'";
            DataSet myds = new DataSet();
            DataTable mydt = new DataTable("登陆");
            OleDbDataAdapter myda = new OleDbDataAdapter(mysql, myconn);
            myda.Fill(myds);
            myconn.Close();

            if (myds.Tables[0].Rows.Count == 0)
                MessageBox.Show("不存在该账号");
            else
            {
                {
                    if (uiTextBox2.Text == myds.Tables[0].Rows[0]["密码"].ToString())
                    {
                        MessageBox.Show("登陆成功");
                        fPersonal.fLandWidget = this;

                        this.Hide();
                        fPersonal.ShowDialog();
                    }
                    else
                        MessageBox.Show("密码错误");
                }
            }
            */
        }
        public string getnickName( string username)
        {
            username = uiTextBox1.Text;
            string nickName = s.look(username);
            return nickName;
        }

        private void register_Click(object sender, EventArgs e)
        {
            this.Hide();//关闭第一个窗口
            FRegister fRegister = new FRegister();
            fRegister.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
            FBack fBack = new FBack();
            fBack.ShowDialog();
        }

        private void FLandWidget_Load(object sender, EventArgs e)
        {

        }
    }
}

