using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using Core.Utilities;
using Entities.Concrete;

namespace ControlUI
{
    public partial class MainForm : Form
    {
        private readonly IUserService _userService;
        private readonly DataService _dataService;
        private readonly EmailService _emailService;
        private readonly ICpuService _cpuService;
        private readonly IRamService _ramService;
        private readonly IDriveService _driveService;
        private readonly User _user;
        private readonly System.Windows.Forms.Timer _timer;
        private bool _isPaused;

        public MainForm(IUserService userService, ICpuService cpuService, IRamService ramService, IDriveService driveService, User user)
        {
            InitializeComponent();
            _userService = userService;
            _dataService = new DataService(cpuService, ramService, driveService);
            _emailService = new EmailService();
            _cpuService = cpuService;
            _ramService = ramService;
            _driveService = driveService;
            _user = user;

            _timer = new System.Windows.Forms.Timer
            {
                Interval = 6000 // 6 seconds
            };
            _timer.Tick += Timer_Tick;
            _timer.Start();
            _isPaused = false;


            InitializeDataGridViewEvents();
            LoadData();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _dataService.SendDataToSqlServer(_user.Id, _user.Email);
            LoadData();

        }

        private void LoadData()
        {
            DataGridViewHelper.LoadDataGrid(dataGridViewCpu, _cpuService.GetCpuDataByUserId(_user.Id).Data);
            DataGridViewHelper.LoadDataGrid(dataGridViewRam, _ramService.GetRamDataByUserId(_user.Id).Data);
            DataGridViewHelper.LoadDataGrid(dataGridViewDrive, _driveService.GetDriveDataByUserId(_user.Id).Data);
        }


        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            // Send the displayed information to the user's email
            var emailContent = "CPU, RAM, and Drive information..."; // Create the email content based on the data
            SendEmail(_user.Email, "PC Info", emailContent);
        }

        private void SendEmail(string to, string subject, string body)
        {
            // Implement your email sending logic here
            // You can use SmtpClient or any other email sending service
        }

        // This method handles the DataError event
        private void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Handle the data error here
            MessageBox.Show(Messages.GridViewError + e.Exception.Message);
            e.ThrowException = false;
        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm(_userService, _user, _isPaused, this);
            settingsForm.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Handle logout logic
            this.Close();
            Application.Restart(); // Or open the login form again
        }
        private void btnPauseResume_Click(object sender, EventArgs e)
        {
            TogglePauseResume();
        }
        public void TogglePauseResume()
        {
            if (_timer.Enabled)
            {
                _timer.Stop();
                btnPauseResume.Text = "Resume";
                _isPaused = true;
            }
            else
            {
                _timer.Start();
                btnPauseResume.Text = "Pause";
                _isPaused = false;
            }
        }
        
        private void InitializeDataGridViewEvents()
        {
            dataGridViewCpu.DataError += DataGridView_DataError;
            dataGridViewRam.DataError += DataGridView_DataError;
            dataGridViewDrive.DataError += DataGridView_DataError;
        }

    }
}
