using System;
using System.Windows;
using System.Windows.Input;
using BUSINESS_LAYER;

namespace PRESENTATION_LAYER
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            Login(tbUsername.Text, tbPassword.Password);
        }

        private void Login(string Username, string Password)
        {

            clsUser user = clsUser.FindUser(Username, Password);

            if (user == null)
            {
                MessageBox.Show("Invalid username or password.");
                return;
            }

            if (user.Status == clsUser.enStatus.Expired)
            {
                MessageBox.Show("Your account has expired. Please contact support.");
                return;
            }
            else if (user.Status == clsUser.enStatus.Banned)
            {
                MessageBox.Show("Your account has been banned. Please contact support.");
                return;
            }

            General.User = user;

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
