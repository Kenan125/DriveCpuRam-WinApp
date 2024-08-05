using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
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
        public RegistrationForm(UserManager userManager)
        {
            InitializeComponent();
            _userManager = userManager;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show(Messages.PasswordNotMatch);
                return;
            }

            var existingUser = _userManager.GetUserByEmail(txtEmail.Text);
            if (existingUser.Data != null)
            {
                MessageBox.Show(Messages.UserExist);
                return;
            }

            var newUser = new User
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
                var loginForm = new LoginForm(_userManager);
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
            var initialForm = new InitialForm();
            initialForm.Show();
            this.Hide();
        }
    }
}
