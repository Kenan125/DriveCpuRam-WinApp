using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
namespace ControlUI
{
    public partial class LoginForm : Form
    {
        private IUserService _userService;
        private readonly IServiceFactory _serviceFactory;

        public LoginForm(IUserService userService, IServiceFactory serviceFactory)
        {
            InitializeComponent();
            _userService = userService;
            _serviceFactory = serviceFactory;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var result = _userService.Login(txtEmail.Text, txtPassword.Text);
                if (result.Success)
                {
                    if (string.IsNullOrEmpty(txtEmail.Text) ||
                        string.IsNullOrEmpty(txtPassword.Text))
                    {
                        MessageBox.Show("Empty spaces should be filled");
                        return;
                    }

                    var userIdResult = _userService.GetUserIdByEmail(txtEmail.Text);
                    if (userIdResult.Success)
                    {
                        var userId = userIdResult.Data;
                        var cpuManager = new CpuManager(new EfCpuDal());
                        var ramManager = new RamManager(new EfRamDal());
                        var driveManager = new DriveManager(new EfDriveDal());
                        var user = _userService.GetUserById(userId).Data;
                        var mainForm = new MainForm(_userService, cpuManager, ramManager, driveManager, user);
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
            catch (Exception ex)
            {
                // Handle or log the exception appropriately
                MessageBox.Show(Messages.LoginError);
            }
        }



        private void btnRegister_Click(object sender, EventArgs e)
        {
            var registrationForm = new RegistrationForm(_userService);
            registrationForm.Show();
            this.Hide();
        }
    }
}
