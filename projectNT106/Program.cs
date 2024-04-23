using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectNT106
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /*Application.Run(new frmLogin());*/

            Menu gameMenu = new Menu();
            if (gameMenu.ShowDialog() == DialogResult.OK)
            {
                gameMenu.Close();
                Application.Run(new frmLogin());
            }
            Application.Exit();
        }
    }
}
