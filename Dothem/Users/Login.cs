using Dothem.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dothem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
            Utils.GUI.InitializeForm(this);
            Utils.GUI.CenterText(lblLogin);

        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {

            tbPassword.PasswordChar = cbShowPassword.Checked ? '\0' : '•';

        }

        private void lnklblSignIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            //Add delegate here to return username and password after sign in is completed
            new SignIn().ShowDialog();

        }

    }

}
