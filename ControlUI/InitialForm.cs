using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlUI
{
    public partial class InitialForm : Form
    {
        public InitialForm()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            var userManager = new UserManager(new EfUserDal(), new EfCpuDal(), new EfDriveDal(), new EfRamDal());
            IServiceFactory serviceFactory = new ServiceFactory();
            LoginForm loginForm = new LoginForm(userManager,serviceFactory);
            loginForm.Show();
            this.Hide();
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            var userManager = new UserManager(new EfUserDal(), new EfCpuDal(), new EfDriveDal(), new EfRamDal());
            RegistrationForm registrationForm = new RegistrationForm(userManager);
            registrationForm.Show();
            this.Hide();
        }
    }
}
