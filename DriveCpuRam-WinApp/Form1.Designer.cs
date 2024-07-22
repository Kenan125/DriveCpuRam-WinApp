namespace DriveCpuRam_WinApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnCreate = new Button();
            UserPasswordTextbox = new TextBox();
            UserPhoneNumberTextbox = new TextBox();
            UserEmailTextbox = new TextBox();
            UserSurnameTextbox = new TextBox();
            UserPassword = new Label();
            UserPhoneNumber = new Label();
            UserEmail = new Label();
            UserSurname = new Label();
            UserName = new Label();
            UserNameTextbox = new TextBox();
            btnCreateAccount = new Button();
            panel2 = new Panel();
            btnLoginSubmit = new Button();
            UserPasswordLoginTextbox = new TextBox();
            UserEmailLoginTextbox = new TextBox();
            UserPassword1 = new Label();
            UserEmail1 = new Label();
            btnLogin = new Button();
            panel3 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCreate);
            panel1.Controls.Add(UserPasswordTextbox);
            panel1.Controls.Add(UserPhoneNumberTextbox);
            panel1.Controls.Add(UserEmailTextbox);
            panel1.Controls.Add(UserSurnameTextbox);
            panel1.Controls.Add(UserPassword);
            panel1.Controls.Add(UserPhoneNumber);
            panel1.Controls.Add(UserEmail);
            panel1.Controls.Add(UserSurname);
            panel1.Controls.Add(UserName);
            panel1.Controls.Add(UserNameTextbox);
            panel1.Location = new Point(38, 144);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(289, 279);
            panel1.TabIndex = 2;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(81, 244);
            btnCreate.Margin = new Padding(3, 4, 3, 4);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(118, 31);
            btnCreate.TabIndex = 12;
            btnCreate.Text = "Create Account";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // UserPasswordTextbox
            // 
            UserPasswordTextbox.Location = new Point(171, 175);
            UserPasswordTextbox.Margin = new Padding(3, 4, 3, 4);
            UserPasswordTextbox.Name = "UserPasswordTextbox";
            UserPasswordTextbox.PasswordChar = '*';
            UserPasswordTextbox.Size = new Size(114, 27);
            UserPasswordTextbox.TabIndex = 9;
            UserPasswordTextbox.TextChanged += UserPasswordTextbox_TextChanged;
            // 
            // UserPhoneNumberTextbox
            // 
            UserPhoneNumberTextbox.Location = new Point(171, 131);
            UserPhoneNumberTextbox.Margin = new Padding(3, 4, 3, 4);
            UserPhoneNumberTextbox.Name = "UserPhoneNumberTextbox";
            UserPhoneNumberTextbox.Size = new Size(114, 27);
            UserPhoneNumberTextbox.TabIndex = 8;
            UserPhoneNumberTextbox.TextChanged += UserPhoneNumberTextbox_TextChanged;
            // 
            // UserEmailTextbox
            // 
            UserEmailTextbox.Location = new Point(171, 85);
            UserEmailTextbox.Margin = new Padding(3, 4, 3, 4);
            UserEmailTextbox.Name = "UserEmailTextbox";
            UserEmailTextbox.Size = new Size(114, 27);
            UserEmailTextbox.TabIndex = 7;
            UserEmailTextbox.TextChanged += UserEmailTextbox_TextChanged;
            // 
            // UserSurnameTextbox
            // 
            UserSurnameTextbox.Location = new Point(171, 47);
            UserSurnameTextbox.Margin = new Padding(3, 4, 3, 4);
            UserSurnameTextbox.Name = "UserSurnameTextbox";
            UserSurnameTextbox.Size = new Size(114, 27);
            UserSurnameTextbox.TabIndex = 6;
            UserSurnameTextbox.TextChanged += UserSurnameTextbox_TextChanged;
            // 
            // UserPassword
            // 
            UserPassword.AutoSize = true;
            UserPassword.Location = new Point(3, 179);
            UserPassword.Name = "UserPassword";
            UserPassword.Size = new Size(70, 20);
            UserPassword.TabIndex = 5;
            UserPassword.Text = "Password";
            // 
            // UserPhoneNumber
            // 
            UserPhoneNumber.AutoSize = true;
            UserPhoneNumber.Location = new Point(3, 141);
            UserPhoneNumber.Name = "UserPhoneNumber";
            UserPhoneNumber.Size = new Size(108, 20);
            UserPhoneNumber.TabIndex = 4;
            UserPhoneNumber.Text = "Phone Number";
            // 
            // UserEmail
            // 
            UserEmail.AutoSize = true;
            UserEmail.Location = new Point(3, 89);
            UserEmail.Name = "UserEmail";
            UserEmail.Size = new Size(46, 20);
            UserEmail.TabIndex = 3;
            UserEmail.Text = "Email";
            // 
            // UserSurname
            // 
            UserSurname.AutoSize = true;
            UserSurname.Location = new Point(3, 51);
            UserSurname.Name = "UserSurname";
            UserSurname.Size = new Size(67, 20);
            UserSurname.TabIndex = 2;
            UserSurname.Text = "Surname";
            // 
            // UserName
            // 
            UserName.AutoSize = true;
            UserName.Location = new Point(3, 15);
            UserName.Name = "UserName";
            UserName.Size = new Size(49, 20);
            UserName.TabIndex = 1;
            UserName.Text = "Name";
            // 
            // UserNameTextbox
            // 
            UserNameTextbox.Location = new Point(171, 4);
            UserNameTextbox.Margin = new Padding(3, 4, 3, 4);
            UserNameTextbox.Name = "UserNameTextbox";
            UserNameTextbox.Size = new Size(114, 27);
            UserNameTextbox.TabIndex = 0;
            UserNameTextbox.TextChanged += UserNameTextbox_TextChanged;
            // 
            // btnCreateAccount
            // 
            btnCreateAccount.Location = new Point(53, 28);
            btnCreateAccount.Margin = new Padding(3, 4, 3, 4);
            btnCreateAccount.Name = "btnCreateAccount";
            btnCreateAccount.Size = new Size(123, 31);
            btnCreateAccount.TabIndex = 10;
            btnCreateAccount.Text = "Create Account";
            btnCreateAccount.UseVisualStyleBackColor = true;
            btnCreateAccount.Click += btnCreateAccount_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnLoginSubmit);
            panel2.Controls.Add(UserPasswordLoginTextbox);
            panel2.Controls.Add(UserEmailLoginTextbox);
            panel2.Controls.Add(UserPassword1);
            panel2.Controls.Add(UserEmail1);
            panel2.Location = new Point(592, 144);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(289, 279);
            panel2.TabIndex = 3;
            // 
            // btnLoginSubmit
            // 
            btnLoginSubmit.Location = new Point(113, 244);
            btnLoginSubmit.Margin = new Padding(3, 4, 3, 4);
            btnLoginSubmit.Name = "btnLoginSubmit";
            btnLoginSubmit.Size = new Size(86, 31);
            btnLoginSubmit.TabIndex = 13;
            btnLoginSubmit.Text = "Login";
            btnLoginSubmit.UseVisualStyleBackColor = true;
            btnLoginSubmit.Click += btnLoginSubmit_Click;
            // 
            // UserPasswordLoginTextbox
            // 
            UserPasswordLoginTextbox.Location = new Point(171, 175);
            UserPasswordLoginTextbox.Margin = new Padding(3, 4, 3, 4);
            UserPasswordLoginTextbox.Name = "UserPasswordLoginTextbox";
            UserPasswordLoginTextbox.PasswordChar = '*';
            UserPasswordLoginTextbox.Size = new Size(114, 27);
            UserPasswordLoginTextbox.TabIndex = 9;
            // 
            // UserEmailLoginTextbox
            // 
            UserEmailLoginTextbox.Location = new Point(171, 85);
            UserEmailLoginTextbox.Margin = new Padding(3, 4, 3, 4);
            UserEmailLoginTextbox.Name = "UserEmailLoginTextbox";
            UserEmailLoginTextbox.Size = new Size(114, 27);
            UserEmailLoginTextbox.TabIndex = 7;
            // 
            // UserPassword1
            // 
            UserPassword1.AutoSize = true;
            UserPassword1.Location = new Point(3, 179);
            UserPassword1.Name = "UserPassword1";
            UserPassword1.Size = new Size(70, 20);
            UserPassword1.TabIndex = 5;
            UserPassword1.Text = "Password";
            // 
            // UserEmail1
            // 
            UserEmail1.AutoSize = true;
            UserEmail1.Location = new Point(3, 96);
            UserEmail1.Name = "UserEmail1";
            UserEmail1.Size = new Size(46, 20);
            UserEmail1.TabIndex = 3;
            UserEmail1.Text = "Email";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(53, 83);
            btnLogin.Margin = new Padding(3, 4, 3, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(123, 31);
            btnLogin.TabIndex = 11;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnCreateAccount);
            panel3.Controls.Add(btnLogin);
            panel3.Location = new Point(345, 216);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(229, 133);
            panel3.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion



        private Panel panel1;
        private TextBox UserNameTextbox;
        private Label UserName;
        private Label UserSurname;
        private TextBox UserPasswordTextbox;
        private TextBox UserPhoneNumberTextbox;
        private TextBox UserEmailTextbox;
        private TextBox UserSurnameTextbox;
        private Label UserPassword;
        private Label UserPhoneNumber;
        private Label UserEmail;
        private Button CreateAccountSubmit;
        private Panel panel2;
        
        private TextBox UserPasswordLoginTextbox;
        private TextBox UserEmailLoginTextbox;
        private Label UserPassword1;
        private Label UserEmail1;
        private Button btnCreateAccount;
        private Button btnLogin;
        private Button btnCreate;
        private Button btnLoginSubmit;
        private Panel panel3;
    }
}
