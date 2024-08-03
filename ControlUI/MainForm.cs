using Business.Concrete;
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
        private readonly UserManager _userManager;
        private readonly CpuManager _cpuManager;
        private readonly RamManager _ramManager;
        private readonly DriveManager _driveManager;
        private readonly User _user;
        private readonly System.Windows.Forms.Timer _timer;

        public MainForm(UserManager userManager, CpuManager cpuManager, RamManager ramManager, DriveManager driveManager, User user)
        {
            InitializeComponent();
            _userManager = userManager;
            _cpuManager = cpuManager;
            _ramManager = ramManager;
            _driveManager = driveManager;
            _user = user;

            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 60000; // 60 seconds
            _timer.Tick += Timer_Tick;
            _timer.Start();

            //dataGridView1.DataError += DataGridView1_DataError; // Subscribe to DataError event
            dataGridViewCpu.DataError += DataGridView_DataError;
            dataGridViewRam.DataError += DataGridView_DataError;
            dataGridViewDrive.DataError += DataGridView_DataError;
            LoadData();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            LoadData();
            SendDataToSqlServer();
        }

        private void LoadData()
        {
            var cpuData = _cpuManager.GetCpuDataByUserId(_user.Id).Data;
            var ramData = _ramManager.GetRamDataByUserId(_user.Id).Data;
            var driveData = _driveManager.GetDriveDataByUserId(_user.Id).Data;

            dataGridViewCpu.DataSource = cpuData;
            dataGridViewRam.DataSource = ramData;
            dataGridViewDrive.DataSource = driveData;
        }

        private void SendDataToSqlServer()
        {
            _cpuManager.SendCpuData(_user.Id, _user.Email);
            _ramManager.SendRamData(_user.Id, _user.Email);
            _driveManager.SendDriveData(_user.Id, _user.Email);
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
            MessageBox.Show("An error occurred while binding data to the DataGridView: " + e.Exception.Message);
            e.ThrowException = false;
        }
    }
}
