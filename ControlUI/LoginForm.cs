using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Concrete;
namespace ControlUI
{
    public partial class LoginForm : Form
    {
        private UserManager _userManager;
        public LoginForm(UserManager userManager)
        {
            InitializeComponent();
            _userManager = userManager;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            var result = _userManager.Login(txtEmail.Text, txtPassword.Text);
            if (result.Success)
            {
                MainForm mainForm = new MainForm(_userManager);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm(_userManager);
            registrationForm.Show();
            this.Hide();
        }
    }
}
