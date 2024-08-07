using Business.Abstract;
using Business.Concrete;
using Business.Constants;
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

namespace ControlUI
{
    public partial class MainForm : Form
    {
        private readonly IUserService _userService;        
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
            _cpuService = cpuService;
            _ramService = ramService;
            _driveService = driveService;
            _user = user;

            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 6000; // 6 seconds
            _timer.Tick += Timer_Tick;
            _timer.Start();
            _isPaused = false;

            
            dataGridViewCpu.DataError += DataGridView_DataError;
            dataGridViewRam.DataError += DataGridView_DataError;
            dataGridViewDrive.DataError += DataGridView_DataError;
            LoadData();
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            SendDataToSqlServer();
            LoadData();

        }

        private void LoadData()
        {
            var cpuData = _cpuService.GetCpuDataByUserId(_user.Id).Data.OrderByDescending(c=>c.Id).ToList();
            var ramData = _ramService.GetRamDataByUserId(_user.Id).Data.OrderByDescending(c=>c.Id).ToList();
            var driveData = _driveService.GetDriveDataByUserId(_user.Id).Data.OrderByDescending(c => c.Id).ToList();

            dataGridViewCpu.DataSource = cpuData;
            HideUnwantedColumns(dataGridViewCpu);

            dataGridViewRam.DataSource = ramData;
            HideUnwantedColumns(dataGridViewRam);

            dataGridViewDrive.DataSource = driveData;
            HideUnwantedColumns(dataGridViewDrive);
        }
        private void HideUnwantedColumns(DataGridView dataGridView)
        {
            if (dataGridView.Columns["UserId"] != null)
            {
                dataGridView.Columns["UserId"].Visible = false;
            }
            if (dataGridView.Columns["Email"] != null)
            {
                dataGridView.Columns["Email"].Visible = false;
                
            }
        }
        private void SendDataToSqlServer()
        {
            _cpuService.SendCpuData(_user.Id, _user.Email);
            _ramService.SendRamData(_user.Id, _user.Email);
            _driveService.SendDriveData(_user.Id, _user.Email);
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
            var settingsForm = new SettingsForm( _userService, _user, _isPaused,this);
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
        public void ResumeIfPaused()
        {
            if (_isPaused)
            {
                _timer.Stop();
                btnPauseResume.Text = "Resume";
            }
            else
            {
                _timer.Start();
                btnPauseResume.Text = "Pause";
            }
        }

    }
}
