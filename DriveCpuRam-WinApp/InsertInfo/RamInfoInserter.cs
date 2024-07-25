using DriveCpuRam_WinApp.Entity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveCpuRam_WinApp.InsertInfo
{
    public class RamInfoInserter
    {
        private readonly string _connectionString;
        private readonly string _email;

        public RamInfoInserter(string connectionString, string email)
        {
            _connectionString = connectionString;
            _email = email;
        }

        public void InsertRamInfo(RamInfoEntity ramInfoEntity, int userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sqlRam = "INSERT INTO RamInfo (TotalMemory, AvailableMemory, UsedMemory, UsagePercentage,UserId, Email) VALUES (@TotalMemory, @AvailableMemory, @UsedMemory, @UsagePercentage,@UserId, @Email)";

                using (SqlCommand command = new SqlCommand(sqlRam, connection))
                {
                    command.Parameters.AddWithValue("@TotalMemory", (decimal)ramInfoEntity.RamTotal);
                    command.Parameters.AddWithValue("@AvailableMemory", (decimal)ramInfoEntity.RamAvailable);
                    command.Parameters.AddWithValue("@UsedMemory", (decimal)ramInfoEntity.RamUsed);
                    command.Parameters.AddWithValue("@UsagePercentage", (decimal)ramInfoEntity.RamPercentage);
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@Email", _email);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
