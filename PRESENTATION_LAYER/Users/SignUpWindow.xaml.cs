using System;
using System.Windows;
using System.Windows.Controls;
using BUSINESS_LAYER;

namespace PRESENTATION_LAYER.Users
{
    public partial class SignUpWindow : Window
    {
        public SignUpWindow()
        {
            InitializeComponent();
        }

        private bool ValidateInput()
        {

            if (string.IsNullOrEmpty(tbUsername.Text))
                return false;

            if (string.IsNullOrEmpty(pbPassword.Password))
                return false;

            if (pbPassword.Password != pbConfirmPassword.Password)
                return false;

            return true;

        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {

            if (!ValidateInput())
            {
                MessageBox.Show("Please fill all fields correctly.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            clsUser NewUser = new clsUser
            {
                Username = tbUsername.Text,
                Password = pbPassword.Password
            };

            if (NewUser.Save())
            {
                General.User = clsUser.FindUser(NewUser.Username, NewUser.Password);

                clsTaskType TaskType = new clsTaskType
                {
                    Name = "General",
                    Description = "General tasks",
                    Color = "#FFCCCCCC",
                    UserID = General.User.UserID
                };

                TaskType.Save();

                MessageBox.Show("User created successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("Error creating user. Try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

    }

}
