using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.Entity;

using System.Windows.Forms;

namespace Main
{
    public partial class MakeComment : Form
    {
        int CircleId;
        public string User_name;
        public MakeComment(int Circleid)
        {
            InitializeComponent();
            this.CircleId = Circleid;
            sql s = new sql();
            string loginid = Program.loginid;
            //string loginid = "1901";
            s.connectToDatabase();
            s.createTable();
            s.createTable2();
            s.createTable3();
            User_name = s.look(loginid);
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            using (var db = new CircleContext())
            {
                var c = new Comment { C_Content = uiRichTextBox1.Text, CircleID=this.CircleId,time=DateTime.Now,
                User_name=User_name};
                db.Entry(c).State = EntityState.Added;
                db.SaveChanges();
                CircleForm circleForm = new CircleForm(CircleId);
                this.Close();
                circleForm.Show();
            }
            
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}