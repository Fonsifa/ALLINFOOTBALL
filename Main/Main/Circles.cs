using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Main
{

    public class Circles
    {
        [Key]
        public int CircleID { set; get; }
        public string Owner { set; get; }
        public int User_Cont { set; get; }

        public List<Comment> Comments { set; get; }

    }
}
