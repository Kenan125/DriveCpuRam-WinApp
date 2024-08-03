using Business.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ControlUI
{
    public partial class RegistrationForm : Form
    {
        private UserManager _userManager;
        public RegistrationForm(UserManager _userManager, UserManager userManager)
        {
            InitializeComponent();
            this._userManager = userManager;
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            User newUser = new User
            {
                Name = txtName.Text,
                Surname = txtSurname.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Email = txtEmail.Text,
                Password = txtPassword.Text
            };

            var result = _userManager.Register(newUser);
            if (result.Success)
            {
                MessageBox.Show(result.Message);
                LoginForm loginForm = new LoginForm(_userManager);
                loginForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm(_userManager);
            loginForm.Show();
            this.Hide();
        }
    }
}
