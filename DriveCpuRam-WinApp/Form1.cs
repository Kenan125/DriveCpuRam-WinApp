using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;
using BCryptNET = BCrypt.Net.BCrypt;

namespace DriveCpuRam_WinApp
{
    public partial class Form1 : Form
    {
        private readonly string connectionString = "Server=KENAN\\MSSQL2022;Database=UserPcInfo;User Id=Kenan;Password=123456; Encrypt=False";

        public Form1()
        {
            InitializeComponent();
            panel1.Visible = false;
            panel2.Visible = false;
        }

        private void UserNameTextbox_TextChanged(object sender, EventArgs e)
        {
            ValidateInputFields();
        }

        private void UserSurnameTextbox_TextChanged(object sender, EventArgs e)
        {
            ValidateInputFields();
        }

        private void UserEmailTextbox_TextChanged(object sender, EventArgs e)
        {
            ValidateInputFields();
        }

        private void UserPhoneNumberTextbox_TextChanged(object sender, EventArgs e)
        {
            ValidateInputFields();
        }

        private void UserPasswordTextbox_TextChanged(object sender, EventArgs e)
        {
            ValidateInputFields();
        }

        private void ValidateInputFields()
        {
            btnCreateAccount.Enabled = !string.IsNullOrWhiteSpace(UserNameTextbox.Text)
                                       && !string.IsNullOrWhiteSpace(UserSurnameTextbox.Text)
                                       && !string.IsNullOrWhiteSpace(UserEmailTextbox.Text)
                                       && !string.IsNullOrWhiteSpace(UserPhoneNumberTextbox.Text)
                                       && !string.IsNullOrWhiteSpace(UserPasswordTextbox.Text);
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            // Get the user input values
            string name = UserNameTextbox.Text;
            string surname = UserSurnameTextbox.Text;
            string email = UserEmailTextbox.Text;
            string phoneNumber = UserPhoneNumberTextbox.Text;
            string password = UserPasswordTextbox.Text;
            int workFactor = 12; // Cost factor
            string hashedPassword = BCryptNET.HashPassword(password, workFactor);

            // Create a SQL connection object
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create a SQL command object
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        // Set the command text to the insert script
                        command.CommandText = @"
                            INSERT INTO UserInfo (Name, Surname, Email, PhoneNumber, Password)
                            VALUES (@Name, @Surname, @Email, @PhoneNumber, @Password);
                        ";

                        // Add parameters to the command
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Surname", surname);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@Password", hashedPassword);

                        // Execute the command
                        command.ExecuteNonQuery();
                    }
                }

                // Show a success message
                MessageBox.Show("Account created successfully!");
                SqlDataSender sqlDataSender = new SqlDataSender(email);
                sqlDataSender.SendInfoToSql();
                panel1.Visible = false;
                panel2.Visible = true;
            }
            catch (Exception ex)
            {
                // Handle any errors that might have occurred
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        public void btnLoginSubmit_Click(object sender, EventArgs e)
        {
            // Get the user input values
            string email = UserEmailLoginTextbox.Text;
            string password = UserPasswordLoginTextbox.Text;

            if (IsValidEmailAndPassword(email, password))
            {
                // Login successful
                MessageBox.Show("Login successful!");

                // You can add your logic to retrieve UserId if needed
                /*SqlDataSender sqlDataSender = new SqlDataSender(email);
                sqlDataSender.SendInfoToSql();*/
                SqlDataUpdater sqlUpdater = new SqlDataUpdater(email);
                sqlUpdater.UpdateLogin();

                panel3.Visible = false;
                panel2.Visible = false;
                panel1.Visible = false;
            }
            else
            {
                // Login failed
                MessageBox.Show("Invalid email or password.");
            }
        }

        private bool IsValidEmailAndPassword(string email, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = @"
                            SELECT Password 
                            FROM UserInfo 
                            WHERE Email = @Email;
                        ";
                        command.Parameters.AddWithValue("@Email", email);
                        command.Connection = connection;

                        string storedHashedPassword = (string)command.ExecuteScalar();

                        if (storedHashedPassword != null)
                        {
                            // Verify the password using BCrypt
                            return BCryptNET.Verify(password, storedHashedPassword);
                        }
                        else
                        {
                            return false; // Email not found
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that might have occurred
                MessageBox.Show("An error occurred: " + ex.Message);
                return false;
            }
        }
    }
}
