using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;


namespace Main
{
    public partial class browers : Form
    {
        public ChromiumWebBrowser chromeBrowser;
        public int News_Id { set; get; }
        public int User_Id { set; get; }
        public browers(int id,int UserId)
        {
            InitializeComponent();
            // Start the browser after initialize global component
            this.News_Id = id;
            this.User_Id = UserId;
            string url = null;
            using (var db = new Newscontext())
            {
                var news = db.News.SingleOrDefault(n => n.NewsId == News_Id);
                url = news.url;
            }
            if (url != null)
            {
                //this.webBrowser1.Url = new Uri(url);
                this.webBrowser1.Navigate(url);
            }
            else MessageBox.Show("信息丢失");
            Show_Chat();
        }

        public void Show_Chat()
        {
            SimpleChatV1Client chat = new SimpleChatV1Client(User_Id);
            chat.TopLevel = false;
            chat.FormBorderStyle = FormBorderStyle.None;
            chat.Dock = DockStyle.Fill;
            chat.AutoSize = true;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(chat);
            chat.Show();
        }
        //初始化浏览器并启动
        public void InitializeChromium(string url)
        {
            //CefSettings settings = new CefSettings();
            // Initialize cef with the provided settings
            //Cef.Initialize(settings);
            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser(url);
            // Add it to the form and fill it to the form window.
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }

        private void browers_Load(object sender, EventArgs e)
        {

        }
    }
}

