using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public partial class FPersonal : Form
    {
           FLandWidget fLandWidget = new FLandWidget() ;
           sql s = new sql();
        public FPersonal()
        {
            InitializeComponent();
            string loginid = Program.loginid;
            string sc = fLandWidget.uiTextBox1.Text;
            s.connectToDatabase();
            s.createTable();
            s.createTable2();
            string nickName = s.look(loginid);
            string team = s.look2(loginid);
            string soccerStar = s.look3(loginid);
            uiTextBox1.Text = nickName;
            uiTextBox2.Text = loginid;
            uiTextBox3.Text = team;
           uiTextBox4.Text = soccerStar;
        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }

        private void FPersonal_Load(object sender, EventArgs e)
        {

        }
    }
}
