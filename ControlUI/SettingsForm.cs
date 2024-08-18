using Business.Abstract;
using Entities.Concrete;

namespace ControlUI
{
    public partial class SettingsForm : Form
    {
        private readonly MainForm _mainForm;
        private readonly IUserService _userService;
        private readonly User _user;
        private readonly bool _isPaused;
        public SettingsForm(IUserService userService, User user, bool isPaused, MainForm mainForm)
        {
            InitializeComponent();
            _userService = userService;
            _user = user;
            _isPaused = isPaused;
            _mainForm = mainForm;
        }
        private void btnChangeName_Click(object sender, EventArgs e)
        {
            ToggleFieldVisibility(lblName, txtName, btnSaveName);
        }

        private void btnChangeSurname_Click(object sender, EventArgs e)
        {
            ToggleFieldVisibility(lblSurname, txtSurname, btnSaveSurname);
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ToggleFieldVisibility(lblPassword, txtPassword, btnSavePassword);
        }

        private void btnChangePhoneNumber_Click(object sender, EventArgs e)
        {
            ToggleFieldVisibility(lblPhoneNumber, txtPhoneNumber, btnSavePhoneNumber);
        }

        private void btnSaveName_Click(object sender, EventArgs e)
        {
            UpdateUserField(txtName, user => user.Name = txtName.Text);
        }

        private void btnSaveSurname_Click(object sender, EventArgs e)
        {
            UpdateUserField(txtSurname, user => user.Surname = txtSurname.Text);
        }

        private void btnSavePassword_Click(object sender, EventArgs e)
        {
            UpdateUserField(txtPassword, user => user.Password = txtPassword.Text);
        }

        private void btnSavePhoneNumber_Click(object sender, EventArgs e)
        {
            UpdateUserField(txtPhoneNumber, user => user.PhoneNumber = txtPhoneNumber.Text);
        }

        private void ToggleFieldVisibility(Label label, TextBox textBox, Button saveButton)
        {
            label.Visible = !label.Visible;
            textBox.Visible = !textBox.Visible;
            saveButton.Visible = !saveButton.Visible;
        }

        private void UpdateUserField(TextBox textBox, Action<User> updateAction)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show("Field cannot be empty.");
                return;
            }

            updateAction(_user);
            var result = _userService.UpdateUser(_user);
            MessageBox.Show(result.Message);
        }
        private void btnBack_Click(object sender, EventArgs e)
        {

            _mainForm.Show();
            if (_isPaused)
            {
                _mainForm.TogglePauseResume(); // Ensure the main form's timer state is correct
            }
            this.Close();

        }
    }
}
