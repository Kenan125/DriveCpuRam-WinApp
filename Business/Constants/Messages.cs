using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string SendCpuSql = "CPU data has been sent to the SQL server.";
        public static string SendDriveSql = "Drive data has been sent to the SQL server.";
        public static string SendRamSql = "RAM data has been sent to the SQL server.";
        public static string UserAdded = "User added successfully.";
        public static string UserUpdated = "User updated successfully.";
        public static string UserDeleted = "User deleted successfully.";
        public static string UserNotFound = "User not found.";
        public static string UserRetrieved = "User retrieved successfully.";
        public static string UserAllRetrieved = "Users retrieved successfully.";
        public static string PasswordEmailFail = "Invalid email or password.";
        public static string LoginSuccess = "Login successful.";
        public static string PasswordChange = "Password changed successfully.";
        public static string LogoutSuccess = "Logout successful.";
        public static string RegistrationSuccess = "Registration successful.";
        public static string UserIdRetrieved = "User ID retrieved successfully.";
        public static string LoginError = "An error occurred while trying to log in. Please try again.";
        public static string UserExist = "User already exists with this email!";
        public static string PasswordNotMatch = "Passwords do not match!";
        public static string GridViewError = "An error occurred while binding data to the DataGridView: ";


    }
}
