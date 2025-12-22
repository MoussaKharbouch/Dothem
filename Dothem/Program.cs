using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dothem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            RunLoginForm();

        }

        static void RunLoginForm()
        {

            Login Login = new Login();

            /*Main Main = new Main();

            do
            {

                Global.user = null;

                Login = new Login();
                DialogResult succeeded = Login.ShowDialog();

                if (succeeded == DialogResult.OK)
                {

                    Main = new Main(Login.user);
                    Main.ShowDialog();

                }
                else if (succeeded == DialogResult.Cancel)
                    break;

            } while ((Main.DialogResult == DialogResult.Retry));*/

            Login.ShowDialog();

        }

    }
    
}
