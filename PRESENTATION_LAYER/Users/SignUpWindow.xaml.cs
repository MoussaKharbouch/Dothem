using System;
using System.Windows;
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

            if (string.IsNullOrEmpty(tbUsername.Text)) return false;
            if (string.IsNullOrEmpty(pbPassword.Password)) return false;
            if (pbPassword.Password != pbConfirmPassword.Password) return false;
            return true;

        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {

            if (!ValidateInput())
            {
                MessageBox.Show("Please fill all fields correctly.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //Make a new user with the new informations
            clsUser NewUser = new clsUser
            {
                Username = tbUsername.Text,
                Password = pbPassword.Password
            };

            if (NewUser.Save())
            {
                General.User = clsUser.FindUser(NewUser.Username, NewUser.Password);

                if (General.User != null)
                {

                    //Add default task type so user can use it
                    clsTaskType TaskType = new clsTaskType
                    {
                        Name = "General",
                        Description = "General tasks",
                        Color = "#FFCCCCCC",
                        UserID = General.User.UserID
                    };

                    TaskType.Save();

                    MessageBox.Show("User created successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    //Log in the new user
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Error retrieving user after creation.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Error creating user. Try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void tbBackToLogin_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            LoginWindow LoginWindow = new LoginWindow();
            LoginWindow.Show();

            this.Close();

        }
    }

}