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
    public partial class FCircle : Form
    {
        public FCircle()
        {
            InitializeComponent();

        }

        private void Circle_Load(object sender, EventArgs e)
        {
            var ch = new ColumnHeader();
            ch.Text = "圈子";ch.Width = 500;
            listView1.Columns.Add(ch);
            
            using(var db=new CircleContext())
            {
                var CList = db.circles.ToList();
                foreach(var i in CList)
                {
                    var item = new ListViewItem();
                    item.Text = i.Owner;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, i.CircleID.ToString()));
                    listView1.Items.Add(item);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                int Circle_Id = Convert.ToInt32(listView1.SelectedItems[0].SubItems[1].Text.ToString());
                CircleForm circleForm = new CircleForm(Circle_Id);
                circleForm.Show();
                // this.Hide();
            }
        }

       
    }
}
