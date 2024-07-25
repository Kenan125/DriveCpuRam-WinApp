using DriveCpuRam_WinApp.Entity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveCpuRam_WinApp.InsertInfo
{
    public class CpuInfoInserter
    {
        private readonly string _connectionString;
        private readonly string _email;

        public CpuInfoInserter(string connectionString, string email)
        {
            _connectionString = connectionString;
            _email = email;
        }

        public void InsertCpuInfo(CpuInfoEntity cpuInfoEntity, int userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sqlCpu = "INSERT INTO CpuInfo (CpuName, CpuCoreNumber, UsedCpuPercentage,UserId, Email) VALUES (@CpuName, @CpuCoreNumber, @UsedCpuPercentage,@UserId, @Email)";

                using (SqlCommand command = new SqlCommand(sqlCpu, connection))
                {
                    command.Parameters.AddWithValue("@CpuName", cpuInfoEntity.CpuName);
                    command.Parameters.AddWithValue("@CpuCoreNumber", cpuInfoEntity.CpuCore);
                    command.Parameters.AddWithValue("@UsedCpuPercentage", cpuInfoEntity.CpuUsage);
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@Email", _email);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
