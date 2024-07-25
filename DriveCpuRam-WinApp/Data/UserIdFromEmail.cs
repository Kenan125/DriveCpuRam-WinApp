using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveCpuRam_WinApp.Data
{
    public class UserIdFromEmail
    {
        private readonly string _connectionString;

        public UserIdFromEmail(string connectionString)
        {
            _connectionString = connectionString;
        }
        public int GetUserIdFromEmail(string email)
        {
            int userId = 0;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
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
            }

            return userId;
        }
    }
}
