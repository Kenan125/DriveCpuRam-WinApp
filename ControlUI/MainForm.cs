using Business.Concrete;
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
        private UserManager _userManager;
        private CpuManager _cpuManager;
        private RamManager _ramManager;
        private DriveManager _driveManager;
        public MainForm(UserManager _userManager, UserManager userManager, CpuManager cpuManager, RamManager ramManager, DriveManager driveManager)
        {
            InitializeComponent();
            this._userManager = userManager;
            _cpuManager = cpuManager;
            _ramManager = ramManager;
            _driveManager = driveManager;

            Timer timer = new Timer();
            timer.Interval = 60000; // 60 seconds
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            var cpuInfo = _cpuManager.GetCpuUsage().Data;
            var ramInfo = _ramManager.GetUsedRam().Data;
            var driveInfo = _driveManager.GetDrives().Data;

            lblCpuUsage.Text = $"CPU Usage: {cpuInfo.CpuUsage}%";
            lblRamUsage.Text = $"RAM Used: {ramInfo.RamUsed} GB";
            lblDriveInfo.Text = $"Drive Info: {driveInfo[0].DriveName}, Used: {driveInfo[0].UsedSpacePercentage}%";
        }

        private void btnSendToEmail_Click(object sender, EventArgs e)
        {
            var result = _userManager.SendEmail(); // Implement this method in UserManager
            if (result.Success)
            {
                MessageBox.Show("Email sent successfully.");
            }
            else
            {
                MessageBox.Show("Failed to send email.");
            }
        }
    }
}
