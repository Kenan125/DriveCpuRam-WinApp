using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using Entities.Concrete;

namespace ControlUI
{
    public partial class RegistrationForm : Form
    {
        private IUserService _userService;
        IServiceFactory serviceFactory = new ServiceFactory();
        public RegistrationForm(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Check if any textbox is empty
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtSurname.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneNumber.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show(Messages.PasswordNotMatch);
                return;
            }

            var existingUser = _userService.GetUserByEmail(txtEmail.Text);
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

            var result = _userService.Register(newUser);
            if (result.Success)
            {
                MessageBox.Show(result.Message);
                var loginForm = new LoginForm(_userService,serviceFactory);
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
