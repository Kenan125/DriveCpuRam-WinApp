using DriveCpuRam_WinApp.Data;
using DriveCpuRam_WinApp.Entity;
using DriveCpuRam_WinApp.PcInfo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DriveCpuRam_WinApp
{
    public partial class UserInfoDisplay : Form
    {
        private readonly string _connectionString = "Server=KENAN\\MSSQL2022;Database=UserPcInfo;User Id=Kenan;Password=123456; Encrypt=False";
        private DataGridView driveDataGridView;
        private DataGridView cpuDataGridView;
        private DataGridView ramDataGridView;
        private Button sendEmailButton;


        private readonly UserInfoEntity _userInfoEntity;
        private readonly EmailSettings _emailSettings;
        private readonly EmailSender _emailSender;




        public UserInfoDisplay(string email, EmailSettings emailSettings)
        {
            
            _emailSettings = emailSettings;
            _emailSender = new EmailSender(email, emailSettings);
            _userInfoEntity = new UserInfoEntity();
            
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 10000; // Set the interval to 60 seconds (60000 ms)
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
            InitializeSendEmailButton();
            UpdateInfo();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateInfo();
        }

        private void InitializeDataGridViews()
        {
            // Initialize driveDataGridView
            driveDataGridView = new DataGridView
            {
                Location = new Point(10, 10),
                Size = new Size(Width, 100),
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
                Size = new Size(Width, 60),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            cpuDataGridView.Columns.Add("CpuName", "Name");
            cpuDataGridView.Columns.Add("CpuCoreCount", "CPU Cores");
            cpuDataGridView.Columns.Add("CpuUsage", "CPU Usage (%)");
            this.Controls.Add(cpuDataGridView);

            // Initialize ramDataGridView
            ramDataGridView = new DataGridView
            {
                Location = new Point(10, 190),
                Size = new Size(Width, 80),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            ramDataGridView.Columns.Add("TotalRam", "Total RAM (GB)");
            ramDataGridView.Columns.Add("AvailableRam", "Available RAM (GB)");
            ramDataGridView.Columns.Add("UsedRam", "Used RAM (GB)");
            ramDataGridView.Columns.Add("RamUsagePercentage", "RAM Usage (%)");
            this.Controls.Add(ramDataGridView);
        }


        private void InitializeSendEmailButton()
        {
            sendEmailButton = new Button
            {
                Text = "Send Info to Email",
                Location = new Point(10, 280),
                Size = new Size(200, 30)
            };
            sendEmailButton.Click += new EventHandler(SendEmailButton_Click);
            this.Controls.Add(sendEmailButton);
        }

        private void SendEmailButton_Click(object sender, EventArgs e)
        {
            var cpuInfoEntity = new CpuInfoEntity
            {
                CpuName = cpuDataGridView.Rows[0].Cells["CpuName"].Value.ToString(),
                CpuCore = int.Parse(cpuDataGridView.Rows[0].Cells["CpuCoreCount"].Value.ToString()),
                CpuUsage = float.Parse(cpuDataGridView.Rows[0].Cells["CpuUsage"].Value.ToString())
            };

            var ramInfoEntity = new RamInfoEntity
            {
                RamTotal = decimal.Parse(ramDataGridView.Rows[0].Cells["TotalRam"].Value.ToString()),
                RamAvailable = decimal.Parse(ramDataGridView.Rows[0].Cells["AvailableRam"].Value.ToString()),
                RamUsed = decimal.Parse(ramDataGridView.Rows[0].Cells["UsedRam"].Value.ToString()),
                RamPercentage = decimal.Parse(ramDataGridView.Rows[0].Cells["RamUsagePercentage"].Value.ToString())
            };

            var driveInfos = new List<object[]>();
            foreach (DataGridViewRow row in driveDataGridView.Rows)
            {
                if (row.IsNewRow) continue;
                var driveInfo = new object[]
                {
            row.Cells["DriveName"].Value.ToString(),
            Convert.ToDouble(row.Cells["TotalSpace"].Value.ToString()),
            Convert.ToDouble(row.Cells["AvailableSpace"].Value.ToString()),
            Convert.ToDouble(row.Cells["UsedSpace"].Value.ToString()),
            Convert.ToDouble(row.Cells["UsedSpacePercentage"].Value.ToString())
                };
                driveInfos.Add(driveInfo);
            }

            _emailSender.SendEmail(cpuInfoEntity, ramInfoEntity, driveInfos);
        }

        private void UpdateInfo()
        {
            try
            {
                // Clear existing data
                driveDataGridView.Rows.Clear();
                cpuDataGridView.Rows.Clear();
                ramDataGridView.Rows.Clear();

                // Update drive info
                List<object[]> driveInfos = DriveInfoProvider.GetDriveInfo();
                if (driveInfos != null)
                {
                    foreach (var driveInfo in driveInfos)
                    {
                        if (driveInfo != null && driveInfo.Length >= 5)
                        {
                            string driveName = driveInfo[0]?.ToString() ?? "N/A";
                            double totalSpace = ParseDouble(driveInfo[1]);
                            double availableSpace = ParseDouble(driveInfo[2]);
                            double usedSpace = ParseDouble(driveInfo[3]);
                            double usedPercentage = ParseDouble(driveInfo[4]);

                            driveDataGridView.Rows.Add(driveName, totalSpace.ToString("F2"), availableSpace.ToString("F2"), usedSpace.ToString("F2"), usedPercentage.ToString("F2"));
                        }
                        else
                        {
                            // Handle cases where driveInfo is null or has insufficient length
                            MessageBox.Show("Drive info array is null or has insufficient length.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Failed to retrieve drive info.");
                    return;
                }

                // Update CPU info
                string cpuName = CpuInfo.GetCpuName() ?? "N/A";
                int cpuCoreCount = CpuInfo.GetCpuCore();
                float cpuUsage = CpuInfo.GetCpuUsage();

                cpuDataGridView.Rows.Add(cpuName, cpuCoreCount, cpuUsage.ToString("F2"));

                // Update RAM info
                decimal totalRam = RamInfo.GetTotalRam();
                decimal availableRam = RamInfo.GetAvailableRam();
                decimal usedRam = RamInfo.GetUsedRam();
                decimal ramUsagePercentage = RamInfo.GetPercentageRam();

                ramDataGridView.Rows.Add(totalRam, availableRam, usedRam, ramUsagePercentage.ToString("F2"));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred in UpdateInfo: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private double ParseDouble(object value)
        {
            if (value == null)
            {
                return 0.0;
            }

            double result;
            if (double.TryParse(value.ToString(), out result))
            {
                return result;
            }
            else
            {
                return 0.0;
            }
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
