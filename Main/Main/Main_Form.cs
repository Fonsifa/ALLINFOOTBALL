using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using WinHttp;
using fjq= HtmlAgilityPack;
using System.Windows.Forms;

namespace Main
{
    public partial class Main_Form : Form
    {
        string UserId;
        public Main_Form()
        {
            InitializeComponent();
            FLandWidget fLandWidget = new FLandWidget();
            sql s = new sql();
            string loginid = Program.loginid;
            string sc = fLandWidget.uiTextBox1.Text;
            s.connectToDatabase();
            s.createTable();
            s.createTable2();
            s.createTable3();
            this.UserId = loginid;
            string nickName = s.look(loginid);
            string team = s.look2(loginid);
            string soccerStar = s.look3(loginid);
            string profile = s.look4(loginid);
            uiLabel3.Text = nickName;
            uiLabel4.Text = loginid;
            uiLabel5.Text = team;
            uiLabel6.Text = soccerStar;
            uiImageButton1.Image = GetImageByBytes(stringtobyte(profile));
        }
        //字符串变图片
        public Image GetImageByBytes(byte[] bytes)
        {
            Image photo = null;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                ms.Write(bytes, 0, bytes.Length);
                photo = Image.FromStream(ms, true);
            }
            return photo;
        }

        public byte[] stringtobyte(string str)
        {
            byte[] decBytes = Convert.FromBase64String(str);
            return decBytes;
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
        private void Main_Form_Load(object sender, EventArgs e)
        {
            Crawler crawler = new Crawler("http://soccer.hupu.com");
            Task<fjq.HtmlNodeCollection>[] tasks = { Task.Run(() => crawler.GetHtmlNodes(1)),
                    Task.Run(() => crawler.GetHtmlNodes(3)) };

            using (var db = new Newscontext())
            {//获得新闻存入数据库 以便于利用浏览器访问
                db.News.RemoveRange(db.News);
                tasks[0].Wait();
                var Node_list = tasks[0].Result;
                if (Node_list != null)
                {
                    int cont = Node_list.Count;
                    for (int i = 0; i < cont; i++)
                    {
                        var a = Node_list[i];
                        //利用正则表达式获取各个新闻的URL
                        string News_title = a.InnerText;
                        string node = a.OuterHtml;
                        string str1 = "https://";
                        string str2 = "，";
                        string str = str1 + ".*" + str2;
                        Regex regex = new Regex(str, RegexOptions.IgnoreCase);
                        Match match = regex.Match(node);
                        string strResult = match.Value.ToString();
                        int len = strResult.Length;
                        int j;
                        for (j = 0; j < len; j++)
                        {
                            if (strResult[j] == '\"') break;
                        }
                        strResult = strResult.Substring(0, j);
                        News news = new News() { Time = DateTime.Now, url = strResult, Title = News_title };
                        db.News.Add(news);
                        db.SaveChanges();
                    }
                }
                else
                    MessageBox.Show("网络出错。");
                //y用listview显示标题
                var _news = db.News.ToList();
                var ch = new ColumnHeader();
                ch.Text = "新闻";
                ch.TextAlign = HorizontalAlignment.Center;
                ch.Width = listView1.Width;
                listView1.Columns.Add(ch);
                foreach (var i in _news)
                {
                    listView1.BeginUpdate();
                    //Console.WriteLine("sfsf");
                    string t = i.Title;
                    ListViewItem ti = new ListViewItem();
                    ti.Text = t;
                    ti.SubItems.Add(new ListViewItem.ListViewSubItem(ti,i.NewsId.ToString()));
                    listView1.Items.Add(ti);
                    this.listView1.EndUpdate();
                }

            }
            tasks[1].Wait();
            //获得赛程
            var Game_list = tasks[1].Result;
            char[] c = { ' ','\n' };
            try
            {
                string[] s1 = Game_list[0].InnerText.Split(c, StringSplitOptions.RemoveEmptyEntries);
                // MessageBox.Show(s1.Length.ToString());
                Game_Label1.Text = s1[0];
                Game_Label3.Text = s1[2];
                Game_Label4.Text = s1[3];
                Game_Label5.Text = s1[4];
                Game_Label6.Text = s1[5];
                string[] s2 = Game_list[1].InnerText.Split(c, StringSplitOptions.RemoveEmptyEntries);
                Game_Label7.Text = s2[0];
                Game_Label9.Text = s2[2];
                Game_Label10.Text = s2[3];
                Game_Label11.Text = s2[4];
                Game_Label12.Text = s2[5];
                string[] s3 = Game_list[2].InnerText.Split(c, StringSplitOptions.RemoveEmptyEntries);
                Game_Label13.Text = s3[0];
                Game_Label15.Text = s3[2];
                Game_Label16.Text = s3[3];
                Game_Label17.Text = s3[4];
                Game_Label18.Text = s3[5];
            }catch
            {
                MessageBox.Show("网络错误");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count!=0)
            {
                int News_Id = Convert.ToInt32(listView1.SelectedItems[0].SubItems[1].Text.ToString());
                //Form2 form2 = new Form2(id);
                //MessageBox.Show(form2.id.ToString());
                //form2.Show();
                int User_Id = Convert.ToInt32(UserId);
                browers browers = new browers(News_Id,User_Id);
                browers.Show();
               // this.Hide();
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CheckData check = new CheckData();
            check.Show();
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            FCircle fCircle = new FCircle();
            fCircle.Show();
        }
    }
}
