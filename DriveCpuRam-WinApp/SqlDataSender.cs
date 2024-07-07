using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveCpuRam_WinApp
{
    public class SqlDataSender
    {
        public void SendInfoToSql()
        {
            string connectionString = "Server=KENAN\\MSSQL2022;Database=UserPcInfo;User Id=Kenan;Password=123456; Encrypt = False";

            // Get Cpu Data
            string cpuName = CpuInfo.GetCpuName();
            int cpuCore = CpuInfo.GetCpuCore();
            float cpuUsage = CpuInfo.GetCpuUsage();

            // Get Ram Data

            float ramAvailable = (float)Math.Round(RamInfo.GetAvailableRam(), 2);
            float ramTotal = (float)Math.Round(RamInfo.GetTotalRam(), 2);
            float ramUsed = (float)Math.Round(RamInfo.GetUsedRam(), 2);
            float ramPercentage = (float)Math.Round(RamInfo.GetPercentageRam(), 2);


            //Get Drive Data
            List<object[]> driveInfos = DriveInfoProvider.GetDriveInfo();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlCpu = "INSERT INTO CpuInfo (CpuName, CpuCoreNumber, UsedCpuPercentage) VALUES (@CpuName, @CpuCoreNumber, @UsedCpuPercentage)";

                string sqlRam = "INSERT INTO RamInfo (TotalMemory,AvailableMemory,UsedMemory,UsagePercentage) VALUES(@TotalMemory,@AvailableMemory,@UsedMemory,@UsagePercentage)";

                

                using (SqlCommand command = new SqlCommand(sqlCpu, connection))
                {
                    command.Parameters.AddWithValue("@CpuName", cpuName);
                    command.Parameters.AddWithValue("@CpuCoreNumber", cpuCore);
                    command.Parameters.AddWithValue("@UsedCpuPercentage", cpuUsage);

                    command.ExecuteNonQuery();
                }
                using (SqlCommand command = new SqlCommand(sqlRam, connection))
                {
                    command.Parameters.AddWithValue("@TotalMemory", (decimal)ramTotal);
                    command.Parameters.AddWithValue("@AvailableMemory", (decimal)ramAvailable);
                    command.Parameters.AddWithValue("@UsedMemory", (decimal)ramUsed);
                    command.Parameters.AddWithValue("@UsagePercentage", (decimal)ramPercentage);

                    command.ExecuteNonQuery();
                }
                foreach (var driveInfo in driveInfos)
                {
                    string query = "INSERT INTO DriveInfo (DriveName, TotalSpaceGB, AvailableSpaceGB, UsedSpaceGB, UsedPercentage) " +
                                   "VALUES (@DriveName, @TotalSpaceGB, @AvailableSpaceGB, @UsedSpaceGB, @UsedPercentage)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DriveName", driveInfo[0]);
                        command.Parameters.AddWithValue("@TotalSpaceGB", driveInfo[1]);
                        command.Parameters.AddWithValue("@AvailableSpaceGB", driveInfo[2]);
                        command.Parameters.AddWithValue("@UsedSpaceGB", driveInfo[3]);
                        command.Parameters.AddWithValue("@UsedPercentage", driveInfo[4]);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
