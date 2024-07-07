using DriveCpuRam_WinApp.Entity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace DriveCpuRam_WinApp
{
    public class SqlDataSender
    {
        private readonly string _connectionString = "Server=KENAN\\MSSQL2022;Database=UserPcInfo;User Id=Kenan;Password=123456; Encrypt=False";
        private readonly string _email;

        public SqlDataSender(string email)
        {
            _email = email;
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

                    InsertCpuInfo(cpuInfoEntity, connection);
                    InsertRamInfo(ramInfoEntity, connection);
                    InsertDriveInfo(driveInfos, connection);

                    int userId = GetUserIdFromEmail(_email, connection);
                    UpdateUserIdInTables(userId, connection);
                }

                MessageBox.Show("Information sent to SQL successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void InsertCpuInfo(CpuInfoEntity cpuInfoEntity, SqlConnection connection)
        {
            string sqlCpu = "INSERT INTO CpuInfo (CpuName, CpuCoreNumber, UsedCpuPercentage, Email) VALUES (@CpuName, @CpuCoreNumber, @UsedCpuPercentage, @Email)";

            using (SqlCommand command = new SqlCommand(sqlCpu, connection))
            {
                command.Parameters.AddWithValue("@CpuName", cpuInfoEntity.CpuName);
                command.Parameters.AddWithValue("@CpuCoreNumber", cpuInfoEntity.CpuCore);
                command.Parameters.AddWithValue("@UsedCpuPercentage", cpuInfoEntity.CpuUsage);
                command.Parameters.AddWithValue("@Email", _email);

                command.ExecuteNonQuery();
            }
        }

        private void InsertRamInfo(RamInfoEntity ramInfoEntity, SqlConnection connection)
        {
            string sqlRam = "INSERT INTO RamInfo (TotalMemory, AvailableMemory, UsedMemory, UsagePercentage, Email) VALUES (@TotalMemory, @AvailableMemory, @UsedMemory, @UsagePercentage, @Email)";

            using (SqlCommand command = new SqlCommand(sqlRam, connection))
            {
                command.Parameters.AddWithValue("@TotalMemory", (decimal)ramInfoEntity.RamTotal);
                command.Parameters.AddWithValue("@AvailableMemory", (decimal)ramInfoEntity.RamAvailable);
                command.Parameters.AddWithValue("@UsedMemory", (decimal)ramInfoEntity.RamUsed);
                command.Parameters.AddWithValue("@UsagePercentage", (decimal)ramInfoEntity.RamPercentage);
                command.Parameters.AddWithValue("@Email", _email);

                command.ExecuteNonQuery();
            }
        }

        private void InsertDriveInfo(List<object[]> driveInfos, SqlConnection connection)
        {
            string query = "INSERT INTO DriveInfo (DriveName, TotalSpaceGB, AvailableSpaceGB, UsedSpaceGB, UsedPercentage, Email) VALUES (@DriveName, @TotalSpaceGB, @AvailableSpaceGB, @UsedSpaceGB, @UsedPercentage, @Email)";

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

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DriveName", driveInfoEntity.DriveName);
                    command.Parameters.AddWithValue("@TotalSpaceGB", driveInfoEntity.TotalSpaceGB);
                    command.Parameters.AddWithValue("@AvailableSpaceGB", driveInfoEntity.AvailableSpaceGB);
                    command.Parameters.AddWithValue("@UsedSpaceGB", driveInfoEntity.UsedSpaceGB);
                    command.Parameters.AddWithValue("@UsedPercentage", driveInfoEntity.UsedPercentage);
                    command.Parameters.AddWithValue("@Email", _email);

                    command.ExecuteNonQuery();
                }
            }
        }

        private int GetUserIdFromEmail(string email, SqlConnection connection)
        {
            int userId = 0;

            using (SqlCommand command = new SqlCommand("SELECT Id FROM UserInfo WHERE Email = @Email", connection))
            {
                command.Parameters.AddWithValue("@Email", email);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    userId = (int)reader["Id"];
                }
                reader.Close();
            }

            return userId;
        }

        private void UpdateUserIdInTables(int userId, SqlConnection connection)
        {
            UpdateUserId("CpuInfo", userId, connection);
            UpdateUserId("RamInfo", userId, connection);
            UpdateUserId("DriveInfo", userId, connection);
        }

        private void UpdateUserId(string tableName, int userId, SqlConnection connection)
        {
            string query = $"UPDATE {tableName} SET UserId = @UserId WHERE Email = @Email";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@Email", _email);

                command.ExecuteNonQuery();
            }
        }
    }
}
