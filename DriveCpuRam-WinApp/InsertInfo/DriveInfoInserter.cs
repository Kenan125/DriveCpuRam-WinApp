using DriveCpuRam_WinApp.Entity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveCpuRam_WinApp.InsertInfo
{
    public class DriveInfoInserter
    {
        private readonly string _connectionString;
        private readonly string _email;

        public DriveInfoInserter(string connectionString, string email)
        {
            _connectionString = connectionString;
            _email = email;
        }

        public void InsertDriveInfo(List<object[]> driveInfos, int userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO DriveInfo (DriveName, TotalSpaceGB, AvailableSpaceGB, UsedSpaceGB, UsedPercentage,UserId, Email) VALUES (@DriveName, @TotalSpaceGB, @AvailableSpaceGB, @UsedSpaceGB, @UsedPercentage,@UserId, @Email)";

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
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@Email", _email);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
