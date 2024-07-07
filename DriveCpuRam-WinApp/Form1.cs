using Microsoft.Data.SqlClient;

namespace DriveCpuRam_WinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel1.Visible = false;
            panel2.Visible = false;

        }



        private void UserName_Click(object sender, EventArgs e)
        {

        }

        private void UserSurname_Click(object sender, EventArgs e)
        {

        }

        private void UserNameTextbox_TextChanged(object sender, EventArgs e)
        {
            string userName = UserNameTextbox.Text.Trim();
            if (string.IsNullOrWhiteSpace(userName))
            {
                // Show an error message or disable a button
                //ErrorLabel.Text = "Please enter a valid username";
                btnCreateAccount.Enabled = false;
            }
            else
            {
                // Clear the error message or enable a button
                //ErrorLabel.Text = string.Empty;
                btnCreateAccount.Enabled = true;
            }
        }

        private void UserSurnameTextbox_TextChanged(object sender, EventArgs e)
        {
            string userSurname = UserSurnameTextbox.Text.Trim();
            if (string.IsNullOrWhiteSpace(userSurname))
            {
                // Show an error message or disable a button
                //ErrorLabel.Text = "Please enter a valid username";
                btnCreateAccount.Enabled = false;
            }
            else
            {
                // Clear the error message or enable a button
                //ErrorLabel.Text = string.Empty;
                btnCreateAccount.Enabled = true;
            }
        }

        private void UserEmailTextbox_TextChanged(object sender, EventArgs e)
        {
            string userEmail = UserEmailTextbox.Text.Trim();
            if (string.IsNullOrWhiteSpace(userEmail))
            {
                // Show an error message or disable a button
                //ErrorLabel.Text = "Please enter a valid username";
                btnCreateAccount.Enabled = false;
            }
            else
            {
                // Clear the error message or enable a button
                //ErrorLabel.Text = string.Empty;
                btnCreateAccount.Enabled = true;
            }
        }

        private void UserPhoneNumberTextbox_TextChanged(object sender, EventArgs e)
        {
            string userPhoneNumber = UserPhoneNumberTextbox.Text.Trim();
            if (string.IsNullOrWhiteSpace(userPhoneNumber))
            {
                // Show an error message or disable a button
                //ErrorLabel.Text = "Please enter a valid username";
                btnCreateAccount.Enabled = false;
            }
            else
            {
                // Clear the error message or enable a button
                //ErrorLabel.Text = string.Empty;
                btnCreateAccount.Enabled = true;
            }
        }

        private void UserPasswordTextbox_TextChanged(object sender, EventArgs e)
        {
            string userPassword = UserPasswordTextbox.Text.Trim();
            if (string.IsNullOrWhiteSpace(userPassword))
            {
                // Show an error message or disable a button
                //ErrorLabel.Text = "Please enter a valid username";
                btnCreateAccount.Enabled = false;
            }
            else
            {
                // Clear the error message or enable a button
                //ErrorLabel.Text = string.Empty;
                btnCreateAccount.Enabled = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

            // Create a connection string to your SQL database

            string connectionString = "Server=KENAN\\MSSQL2022;Database=UserPcInfo;User Id=Kenan;Password=123456; Encrypt=False";
            // Create a SQL connection object
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
                    command.Parameters.AddWithValue("@Password", password);

                    // Execute the command
                    command.ExecuteNonQuery();
                    panel1.Visible = false;
                    panel2.Visible = true;
                }
            }

            // Show a success message
            MessageBox.Show("Account created successfully!");
        }

        public void btnLoginSubmit_Click(object sender, EventArgs e)
        {
            // Get the user input values
            string email = UserEmailLoginTextbox.Text;
            string password = UserPasswordLoginTextbox.Text;

            // Create a connection string to your SQL database
            string connectionString = "Server=KENAN\\MSSQL2022;Database=UserPcInfo;User Id=Kenan;Password=123456; Encrypt=False";



            // Create a SQL connection object
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a SQL command object
                using (SqlCommand command = new SqlCommand())
                {
                    // Set the command text to the select script
                    command.CommandText = @"
                SELECT COUNT(*) 
                FROM UserInfo 
                WHERE Email = @Email AND Password = @Password;
            ";

                    // Add parameters to the command
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    // Set the connection property of the command
                    command.Connection = connection;

                    // Execute the command and get the result
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        // Login successful
                        MessageBox.Show("Login successful!");

                        SqlDataSender sqlDataSender = new SqlDataSender();
                        sqlDataSender.SendInfoToSql();




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
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
