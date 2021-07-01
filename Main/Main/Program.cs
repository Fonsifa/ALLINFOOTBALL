using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    static class Program
    {
        public static string loginid;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Main_Form());
            Application.Run(new FLandWidget());
            //Application.Run(new Formtest());
            //Application.Run(new SocketDemo.ClientSocket());
            //Application.Run(new CheckData());
            //Application.Run(new FCircle());
        }
    }
}
