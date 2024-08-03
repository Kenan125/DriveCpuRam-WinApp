using Business.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
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
            _timer.Interval = 6000; // 6 seconds
            _timer.Tick += Timer_Tick;
            _timer.Start();

            dataGridView1.DataError += DataGridView1_DataError;

            LoadData();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            LoadData();
            SendDataToSqlServer();
        }
        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Handle the data error here
            MessageBox.Show("An error occurred while binding data to the DataGridView: " + e.Exception.Message);
            e.ThrowException = false;
        }

        private void LoadData()
        {
            var cpuData = _userManager.GetUserCpuInfo(_user.Id).Data;
            var ramData = _userManager.GetUserRamInfo(_user.Id).Data;
            var driveData = _userManager.GetUserDriveInfo(_user.Id).Data;

            // Combine the data into a single list if necessary
            var allData = new List<object>();
            allData.AddRange(cpuData);
            allData.AddRange(ramData);
            allData.AddRange(driveData);

            // Assuming you have a DataGridView named dataGridView1
            dataGridView1.DataSource = allData;
        }

        private void SendDataToSqlServer()
        {
            _cpuManager.SendCpuData(_user.Id);
            _ramManager.SendRamData(_user.Id);
            _driveManager.SendDriveData(_user.Id);
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

        
    }
}
