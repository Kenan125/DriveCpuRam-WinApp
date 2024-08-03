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
using DataAccess.Concrete.EntityFramework;
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
                var userIdResult = _userManager.GetUserIdByEmail(txtEmail.Text);
                if (userIdResult.Success)
                {
                    var userId = userIdResult.Data;
                    var cpuManager = new CpuManager(new EfCpuDal());
                    var ramManager = new RamManager(new EfRamDal());
                    var driveManager = new DriveManager(new EfDriveDal());
                    var user = _userManager.GetUserById(userId).Data;
                    MainForm mainForm = new MainForm(_userManager, cpuManager, ramManager, driveManager, user);
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(userIdResult.Message);
                }
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var registrationForm = new RegistrationForm(_userManager);
            registrationForm.Show();
            this.Hide();
        }
    }
}
