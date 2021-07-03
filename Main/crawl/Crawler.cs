using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinHttp;
using fjq = HtmlAgilityPack;
using System.Threading.Tasks;

namespace Main
{
    class Crawler
    {
        public string Start_Url { set; get; }
        public Crawler(string url) { Start_Url = url; }
        public fjq.HtmlNodeCollection GetHtmlNodes(int type)//1->爬新闻；2->爬数据；3->爬赛程
        {
            WinHttpRequest win = new WinHttpRequest();//创建WinHttpRequest
            win.Open("GET", Start_Url, false);//win.Oen("请求方式","请求地址",是否异步请求)
            win.Send();//发送

            byte[] bs = win.ResponseBody;//返回的数据 用byte数组接收   注：win.ResponseText直接输出有中文乱码的情况
            string docHtml = System.Text.Encoding.UTF8.GetString(bs);//转码

            fjq.HtmlDocument hdoc = new fjq.HtmlDocument();//HtmlAgilityPack的HtmlDocument的实例化
            hdoc.LoadHtml(docHtml);//加载HTML网页文本

            //通过选择器 定位到a标签 返回a标签的集合（需要分析网页HTML代码） 
            if (type == 1)
            {
                fjq.HtmlNodeCollection aList = hdoc.DocumentNode.SelectNodes(@"//*[@class=""latest24""]//div//a");
                return aList;
            }
            else if (type == 2)
            {
                fjq.HtmlNodeCollection aList = hdoc.DocumentNode.SelectNodes(@"//*[@class=""td""]//span");
                return aList;
            }
            else
            {
                fjq.HtmlNodeCollection aList = hdoc.DocumentNode.SelectNodes(@"//*[@class=""swiper-wrapper""]//section");
                return aList;
            }
        }
    }
}
