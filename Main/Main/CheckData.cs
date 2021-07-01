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
    public partial class CheckData : Form
    {
        string[] Type = { "231", "1", "3", "4", "2" };//分别是中超英超西甲德甲意甲的域名最后
        string Url_head = "https://dongqiudi.com/data/";
        public string Url { set; get; }
        Crawler crawler=new Crawler("https://dongqiudi.com/data/231");
        public CheckData()
        {
            InitializeComponent();
            Url = Url_head + Type[0];
            
        }

        private void CheckData_Load(object sender, EventArgs e)
        {
            var ch1 = new ColumnHeader();ch1.Text = "排名";
            ch1.Width = 60;
            listView1.Columns.Add(ch1);
            var ch2 = new ColumnHeader(); ch2.Text = "球队";
            ch2.Width = 150;
            listView1.Columns.Add(ch2);
            var ch3 = new ColumnHeader(); ch3.Text = "场次";
            ch3.Width = 60;
            listView1.Columns.Add(ch3);
            var ch4 = new ColumnHeader(); ch4.Text = "胜";
            ch4.Width = 60;
            listView1.Columns.Add(ch4);
            var ch5 = new ColumnHeader(); ch5.Text = "平";
            ch5.Width = 60;
            listView1.Columns.Add(ch5);
            var ch6 = new ColumnHeader(); ch6.Text = "负";
            ch6.Width = 60;
            listView1.Columns.Add(ch6);
            var ch7 = new ColumnHeader(); ch7.Text = "积分";
            ch7.Width = 60;
            listView1.Columns.Add(ch7);
            Show_Data();
        }
        public void Show_Data()
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();
            var alist = crawler.GetHtmlNodes(2);

            if (alist != null)
            {//将数据写入listview
                int len = alist.Count();
                for (int i = 0; i < len; i += 10)
                {

                    string[] ss = new string[]{alist[i].InnerText.Trim(), alist[i+1].InnerText.Trim(),
                        alist[i+2].InnerText.Trim(),alist[i+3].InnerText.Trim(),alist[i+4].InnerText.Trim(),
                        alist[i+5].InnerText.Trim(),alist[i+9].InnerText.Trim() };

                    var item = new ListViewItem(ss);
                    // MessageBox.Show(item.SubItems.Count.ToString());
                    listView1.Items.Add(item);
                }
            }
            else
                MessageBox.Show("找不到了");
            listView1.EndUpdate();
        }
        private void uiButton1_Click(object sender, EventArgs e)
        {
            Url = Url_head + "231";
            crawler.Start_Url = Url;
            Show_Data();
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            Url = Url_head + "1";
            crawler.Start_Url = Url;
            Show_Data();
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            Url = Url_head + "3";
            crawler.Start_Url = Url;
            Show_Data();
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            Url = Url_head + "4";
            crawler.Start_Url = Url;
            Show_Data();
        }

        private void uiButton5_Click(object sender, EventArgs e)
        {
            Url = Url_head + "2";
            crawler.Start_Url = Url;
            Show_Data();
        }

        private void uiButton6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Form main = new Main_Form();
            main.Show();
        }
    }
}
