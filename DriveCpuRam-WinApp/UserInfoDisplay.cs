using DriveCpuRam_WinApp.PcInfo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DriveCpuRam_WinApp
{
    public partial class UserInfoDisplay : Form
    {
        private DataGridView driveDataGridView;
        private DataGridView cpuDataGridView;
        private DataGridView ramDataGridView;

        private readonly string _email;

        public UserInfoDisplay(string email)
        {
            _email = email;
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 60000; // Set the interval to 60 seconds (60000 ms)
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }

        private static UserInfoDisplay _instance;

        public UserInfoDisplay()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 60000; // Set the interval to 60 seconds (60000 ms)
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeDataGridViews();
            UpdateInfo();
        }

        private void InitializeDataGridViews()
        {
            // Initialize driveDataGridView
            driveDataGridView = new DataGridView
            {
                Location = new Point(10, 10),
                Size = new Size(500, 100),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            driveDataGridView.Columns.Add("DriveName", "Drive");
            driveDataGridView.Columns.Add("TotalSpace", "Total Size (GB)");
            driveDataGridView.Columns.Add("AvailableSpace", "Free Space (GB)");
            driveDataGridView.Columns.Add("UsedSpace", "Used Space (GB)");
            driveDataGridView.Columns.Add("UsedSpacePercentage", "Used Space (%)");
            this.Controls.Add(driveDataGridView);

            // Initialize cpuDataGridView
            cpuDataGridView = new DataGridView
            {
                Location = new Point(10, 120),
                Size = new Size(500, 60),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            cpuDataGridView.Columns.Add("CpuCoreCount", "CPU Cores");
            cpuDataGridView.Columns.Add("CpuUsage", "CPU Usage (%)");
            this.Controls.Add(cpuDataGridView);

            // Initialize ramDataGridView
            ramDataGridView = new DataGridView
            {
                Location = new Point(10, 190),
                Size = new Size(500, 80),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            ramDataGridView.Columns.Add("TotalRam", "Total RAM (GB)");
            ramDataGridView.Columns.Add("AvailableRam", "Available RAM (GB)");
            ramDataGridView.Columns.Add("UsedRam", "Used RAM (GB)");
            ramDataGridView.Columns.Add("RamUsagePercentage", "RAM Usage (%)");
            this.Controls.Add(ramDataGridView);
        }

        private void UpdateInfo()
        {
            // Clear existing data
            driveDataGridView.Rows.Clear();
            cpuDataGridView.Rows.Clear();
            ramDataGridView.Rows.Clear();

            // Update drive info
            List<object[]> driveInfos = DriveInfoProvider.GetDriveInfo();
            foreach (var driveInfo in driveInfos)
            {
                string driveName = driveInfo[0].ToString();
                double totalSpace = (double)driveInfo[1];
                double availableSpace = (double)driveInfo[2];
                double usedSpace = (double)driveInfo[3];
                double usedPercentage = (double)driveInfo[4];

                driveDataGridView.Rows.Add(driveName, totalSpace.ToString("F2"), availableSpace.ToString("F2"), usedSpace.ToString("F2"), usedPercentage.ToString("F2"));
            }

            // Update CPU info
            string cpuName = CpuInfo.GetCpuName();
            int cpuCoreCount = CpuInfo.GetCpuCore();
            float cpuUsage = CpuInfo.GetCpuUsage();

            cpuDataGridView.Rows.Add(cpuCoreCount, cpuUsage.ToString("F2"));

            // Update RAM info
            decimal totalRam = RamInfo.GetTotalRam();
            decimal availableRam = RamInfo.GetAvailableRam();
            decimal usedRam = RamInfo.GetUsedRam();
            decimal ramUsagePercentage = RamInfo.GetPercentageRam();

            ramDataGridView.Rows.Add(totalRam, availableRam, usedRam, ramUsagePercentage.ToString("F2"));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateInfo();
        }

        public static UserInfoDisplay GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new UserInfoDisplay();
            }
            return _instance;
        }
    }
}
