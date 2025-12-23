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
using BusinessLayer;

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
            MainWindow MainWindow = new MainWindow(User.FindUser("admin", "admin"));
            MainWindow.Show();
            this.Close();

        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            Login(tbUsername.Text, tbPassword.Text);
        }

        private void Login(string Username, string Password)
        {

            User user = User.FindUser(Username, Password);

            if(user == null)
            {
                MessageBox.Show("Invalid username or password.");
                return;
            }

            if (user.Status == User.enStatus.Expired)
            {
                MessageBox.Show("Your account has expired. Please contact support.");
            }
            else if (user.Status == User.enStatus.Banned)
            {
                MessageBox.Show("Your account has been banned. Please contact support.");
            }

            MainWindow MainWindow = new MainWindow(user);
            MainWindow.Show();

            this.Close();

        }

    }

}
