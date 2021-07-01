using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public partial class CircleForm : Form
    {
        public int CircleId { set; get; }
        public CircleForm(int Circle_Id)
        {
            InitializeComponent();
            CircleId = Circle_Id;
            var ch = new ColumnHeader();
            
            using(var db=new CircleContext())
            {
                var c = db.circles.SingleOrDefault(ci => ci.CircleID == CircleId);
                if (c != null)
                {
                    string name = c.Owner;
                    ch.Text = name + " 的圈子";
                    ch.Width = 500;
                    listView1.Columns.Add(ch);
                    var comments = db.comments.Where(co => co.Circle.CircleID == CircleId);
                    if (comments != null)
                    {
                        foreach (var cc in comments)
                        {
                            var item = new ListViewItem();
                            item.Text = cc.User_name + " 说：" + cc.C_Content + "      " + cc.time.ToString();
                            listView1.Items.Add(item);
                        }
                    }
                    else MessageBox.Show("空空如也~");
                }
                else MessageBox.Show("信息出错了");


            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            //MessageBox.Show(CircleId.ToString());
            MakeComment comment = new MakeComment(CircleId);
            
            comment.Show();
        }
    }
}
