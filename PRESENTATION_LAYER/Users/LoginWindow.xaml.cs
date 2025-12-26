using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BUSINESS_LAYER;

namespace PRESENTATION_LAYER
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        public LoginWindow()
        {

            InitializeComponent();

            //to test main window directly
            /*General.User = clsUser.FindUser("admin", "admin");
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();*/

        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            Login(tbUsername.Text, tbPassword.Text);
        }

        private void Login(string Username, string Password)
        {

            clsUser user = clsUser.FindUser(Username, Password);

            if(user == null)
            {
                MessageBox.Show("Invalid username or password.");
                return;
            }

            if (user.Status == clsUser.enStatus.Expired)
            {
                MessageBox.Show("Your account has expired. Please contact support.");
            }
            else if (user.Status == clsUser.enStatus.Banned)
            {
                MessageBox.Show("Your account has been banned. Please contact support.");
            }

            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();

            this.Close();

        }

        private void tbSignUp_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            Users.SignUpWindow SignUpWindow = new Users.SignUpWindow();
            SignUpWindow.Show();

            this.Close();

        }
    }

}
