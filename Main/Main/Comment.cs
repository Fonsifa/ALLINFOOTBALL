using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Comment
    {
        public int CommentID { set; get; }
        public string C_Content { set; get; }
        public string User_name { set; get; }
        public DateTime time { set; get; }
        public int CircleID { set; get; }
        public Circles Circle { set; get; }
    }
}
