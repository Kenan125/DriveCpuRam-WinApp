using DriveCpuRam_WinApp.Entity;
using DriveCpuRam_WinApp.PcInfo;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace DriveCpuRam_WinApp
{
    internal class SqlDataUpdater
    {
        private readonly string _connectionString = "Server=KENAN\\MSSQL2022;Database=UserPcInfo;User Id=Kenan;Password=123456; Encrypt=False";
        private readonly string _email;

        public SqlDataUpdater(string email)
        {
            _email = email;
        }

        public void UpdateLogin()
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
                    RamAvailable = (float)Math.Round(RamInfo.GetAvailableRam(), 2),
                    RamTotal = (float)Math.Round(RamInfo.GetTotalRam(), 2),
                    RamUsed = (float)Math.Round(RamInfo.GetUsedRam(), 2),
                    RamPercentage = (float)Math.Round(RamInfo.GetPercentageRam(), 2)
                };

                // Get Drive Data
                List<object[]> driveInfos = DriveInfoProvider.GetDriveInfo();

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    UpdateCpuInfo(cpuInfoEntity, connection);
                    UpdateRamInfo(ramInfoEntity, connection);
                    UpdateDriveInfo(driveInfos, connection);


                }

                MessageBox.Show("Information sent to SQL successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private bool ValidateLogin(string email, string password)
        {
            // Validate login credentials against UserInfo table
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(*) FROM UserInfo WHERE Email = @Email AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                conn.Open();
                int result = (int)cmd.ExecuteScalar();
                return result > 0;
            }
        }

        private int GetUserIdByEmail(string email)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id FROM UserInfo WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        private void UpdateCpuInfo(CpuInfoEntity cpuInfoEntity, SqlConnection connection)
        {
            

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "UPDATE CpuInfo SET CpuName = @CpuName, CpuCoreNumber = @CpuCoreNumber, UsedCpuPercentage = @UsedCpuPercentage WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CpuName", cpuInfoEntity.CpuName);
                cmd.Parameters.AddWithValue("@CpuCoreNumber", cpuInfoEntity.CpuCore);
                cmd.Parameters.AddWithValue("@UsedCpuPercentage", cpuInfoEntity.CpuUsage);
                cmd.Parameters.AddWithValue("@Email", _email);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void UpdateDriveInfo(List<object[]> driveInfos, SqlConnection connection)
        {
            // Get Drive Data
            

            foreach (var driveInfo in driveInfos)
            {
                DriveInfoEntity driveInfoEntity = new DriveInfoEntity()
                {
                    DriveName = driveInfo[0].ToString(),
                    TotalSpaceGB = decimal.Parse(driveInfo[1].ToString()),
                    AvailableSpaceGB = decimal.Parse(driveInfo[2].ToString()),
                    UsedSpaceGB = decimal.Parse(driveInfo[3].ToString()),
                    UsedPercentage = decimal.Parse(driveInfo[4].ToString()),
                };

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "UPDATE DriveInfo SET DriveName = @DriveName, TotalSpaceGB = @TotalSpaceGB, AvailableSpaceGB = @AvailableSpaceGB, UsedSpaceGB = @UsedSpaceGB, UsedPercentage = @UsedPercentage WHERE Email = @Email";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@DriveName", driveInfoEntity.DriveName);
                    cmd.Parameters.AddWithValue("@TotalSpaceGB", driveInfoEntity.TotalSpaceGB);
                    cmd.Parameters.AddWithValue("@AvailableSpaceGB", driveInfoEntity.AvailableSpaceGB);
                    cmd.Parameters.AddWithValue("@UsedSpaceGB", driveInfoEntity.UsedSpaceGB);
                    cmd.Parameters.AddWithValue("@UsedPercentage", driveInfoEntity.UsedPercentage);
                    
                    cmd.Parameters.AddWithValue("@Email", _email);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            
        }

        private void UpdateRamInfo(RamInfoEntity ramInfoEntity, SqlConnection connection)
        {
            

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "UPDATE RamInfo SET TotalMemory = @TotalMemory, AvailableMemory = @AvailableMemory, UsedMemory = @UsedMemory, UsagePercentage = @UsagePercentage WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TotalMemory", (decimal)ramInfoEntity.RamTotal);
                cmd.Parameters.AddWithValue("@AvailableMemory", (decimal)ramInfoEntity.RamAvailable);
                cmd.Parameters.AddWithValue("@UsedMemory", (decimal)ramInfoEntity.RamUsed);
                cmd.Parameters.AddWithValue("@UsagePercentage", (decimal)ramInfoEntity.RamPercentage);
                cmd.Parameters.AddWithValue("@Email", _email);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
