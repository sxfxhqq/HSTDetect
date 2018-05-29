using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client;

namespace HSTClient
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            
            Client.Login lg = new Login();
            lg.ShowDialog();

            if (lg.ExitFlag)
            {
                Application.Exit();
                return;
            }

            Application.Run(new MainForm());
        }
    }
}
