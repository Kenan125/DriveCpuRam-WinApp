using DriveCpuRam_WinApp.Entity;
using DriveCpuRam_WinApp.InsertInfo;
using DriveCpuRam_WinApp.PcInfo;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Timers;
using System.Windows.Forms;

namespace DriveCpuRam_WinApp.Data
{
    public class SqlDataSender
    {
        private readonly string _connectionString = "Server=KENAN\\MSSQL2022;Database=UserPcInfo;User Id=Kenan;Password=123456; Encrypt=False";
        private readonly string _email;
        //private readonly EmailSettings _emailSettings;
        private System.Timers.Timer _timer;
        //private readonly EmailSender _emailSender;
        private readonly CpuInfoInserter _cpuInfoInserter;
        private readonly RamInfoInserter _ramInfoInserter;
        private readonly DriveInfoInserter _driveInfoInserter;
        private readonly UserIdFromEmail _userIdFromEmail;

        public SqlDataSender(string email, EmailSettings emailSettings)
        {
            _email = email;
            //_emailSettings = emailSettings;
            //_emailSender = new EmailSender(email, emailSettings);
            _cpuInfoInserter = new CpuInfoInserter(_connectionString, email);
            _ramInfoInserter = new RamInfoInserter(_connectionString, email);
            _driveInfoInserter = new DriveInfoInserter(_connectionString, email);
            _userIdFromEmail = new UserIdFromEmail(_connectionString);
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            _timer = new System.Timers.Timer(60000); // 60000 milliseconds = 1 minute
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            SendInfoToSql();
        }

        public void SendInfoToSql()
        {
            try
            {
                // Get Cpu Data
                CpuInfoEntity cpuInfoEntity = new CpuInfoEntity()
                {
                    CpuName = CpuInfo.GetCpuName(),
                    CpuCore = CpuInfo.GetCpuCore(),
                    CpuUsage = CpuInfo.GetCpuUsage()
                };

                // Get Ram Data
                RamInfoEntity ramInfoEntity = new RamInfoEntity()
                {
                    RamAvailable = Math.Round(RamInfo.GetAvailableRam(), 2),
                    RamTotal = Math.Round(RamInfo.GetTotalRam(), 2),
                    RamUsed = Math.Round(RamInfo.GetUsedRam(), 2),
                    RamPercentage = Math.Round(RamInfo.GetPercentageRam(), 2)
                };

                // Get Drive Data
                List<object[]> driveInfos = DriveInfoProvider.GetDriveInfo();

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    // Get UserId based on Email
                    int userId = _userIdFromEmail.GetUserIdFromEmail(_email);
                    if (userId == 0)
                    {
                        MessageBox.Show("User not found.");
                        return;
                    }
                    _cpuInfoInserter.InsertCpuInfo(cpuInfoEntity, userId);
                    _ramInfoInserter.InsertRamInfo(ramInfoEntity, userId);
                    _driveInfoInserter.InsertDriveInfo(driveInfos, userId);

                }

                //_emailSender.SendEmail(cpuInfoEntity, ramInfoEntity, driveInfos);

                MessageBox.Show("Information sent to SQL and email successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }



        
    }


}
