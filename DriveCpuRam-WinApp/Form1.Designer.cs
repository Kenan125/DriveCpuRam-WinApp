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
            panel1.Location = new Point(33, 108);
            panel1.Name = "panel1";
            panel1.Size = new Size(253, 209);
            panel1.TabIndex = 2;
            
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(71, 183);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(103, 23);
            btnCreate.TabIndex = 12;
            btnCreate.Text = "Create Account";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // UserPasswordTextbox
            // 
            UserPasswordTextbox.Location = new Point(150, 131);
            UserPasswordTextbox.Name = "UserPasswordTextbox";
            UserPasswordTextbox.PasswordChar = '*';
            UserPasswordTextbox.Size = new Size(100, 23);
            UserPasswordTextbox.TabIndex = 9;
            UserPasswordTextbox.TextChanged += UserPasswordTextbox_TextChanged;
            // 
            // UserPhoneNumberTextbox
            // 
            UserPhoneNumberTextbox.Location = new Point(150, 98);
            UserPhoneNumberTextbox.Name = "UserPhoneNumberTextbox";
            UserPhoneNumberTextbox.Size = new Size(100, 23);
            UserPhoneNumberTextbox.TabIndex = 8;
            UserPhoneNumberTextbox.TextChanged += UserPhoneNumberTextbox_TextChanged;
            // 
            // UserEmailTextbox
            // 
            UserEmailTextbox.Location = new Point(150, 64);
            UserEmailTextbox.Name = "UserEmailTextbox";
            UserEmailTextbox.Size = new Size(100, 23);
            UserEmailTextbox.TabIndex = 7;
            UserEmailTextbox.TextChanged += UserEmailTextbox_TextChanged;
            // 
            // UserSurnameTextbox
            // 
            UserSurnameTextbox.Location = new Point(150, 35);
            UserSurnameTextbox.Name = "UserSurnameTextbox";
            UserSurnameTextbox.Size = new Size(100, 23);
            UserSurnameTextbox.TabIndex = 6;
            UserSurnameTextbox.TextChanged += UserSurnameTextbox_TextChanged;
            // 
            // UserPassword
            // 
            UserPassword.AutoSize = true;
            UserPassword.Location = new Point(3, 134);
            UserPassword.Name = "UserPassword";
            UserPassword.Size = new Size(57, 15);
            UserPassword.TabIndex = 5;
            UserPassword.Text = "Password";
            // 
            // UserPhoneNumber
            // 
            UserPhoneNumber.AutoSize = true;
            UserPhoneNumber.Location = new Point(3, 106);
            UserPhoneNumber.Name = "UserPhoneNumber";
            UserPhoneNumber.Size = new Size(88, 15);
            UserPhoneNumber.TabIndex = 4;
            UserPhoneNumber.Text = "Phone Number";
            // 
            // UserEmail
            // 
            UserEmail.AutoSize = true;
            UserEmail.Location = new Point(3, 67);
            UserEmail.Name = "UserEmail";
            UserEmail.Size = new Size(36, 15);
            UserEmail.TabIndex = 3;
            UserEmail.Text = "Email";
            // 
            // UserSurname
            // 
            UserSurname.AutoSize = true;
            UserSurname.Location = new Point(3, 38);
            UserSurname.Name = "UserSurname";
            UserSurname.Size = new Size(54, 15);
            UserSurname.TabIndex = 2;
            UserSurname.Text = "Surname";
            
            // 
            // UserName
            // 
            UserName.AutoSize = true;
            UserName.Location = new Point(3, 11);
            UserName.Name = "UserName";
            UserName.Size = new Size(39, 15);
            UserName.TabIndex = 1;
            UserName.Text = "Name";
            
            // 
            // UserNameTextbox
            // 
            UserNameTextbox.Location = new Point(150, 3);
            UserNameTextbox.Name = "UserNameTextbox";
            UserNameTextbox.Size = new Size(100, 23);
            UserNameTextbox.TabIndex = 0;
            UserNameTextbox.TextChanged += UserNameTextbox_TextChanged;
            // 
            // btnCreateAccount
            // 
            btnCreateAccount.Location = new Point(46, 21);
            btnCreateAccount.Name = "btnCreateAccount";
            btnCreateAccount.Size = new Size(108, 23);
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
            panel2.Location = new Point(518, 108);
            panel2.Name = "panel2";
            panel2.Size = new Size(253, 209);
            panel2.TabIndex = 3;
            // 
            // btnLoginSubmit
            // 
            btnLoginSubmit.Location = new Point(99, 183);
            btnLoginSubmit.Name = "btnLoginSubmit";
            btnLoginSubmit.Size = new Size(75, 23);
            btnLoginSubmit.TabIndex = 13;
            btnLoginSubmit.Text = "Login";
            btnLoginSubmit.UseVisualStyleBackColor = true;
            btnLoginSubmit.Click += btnLoginSubmit_Click;
            // 
            // UserPasswordLoginTextbox
            // 
            UserPasswordLoginTextbox.Location = new Point(150, 131);
            UserPasswordLoginTextbox.Name = "UserPasswordLoginTextbox";
            UserPasswordLoginTextbox.PasswordChar = '*';
            UserPasswordLoginTextbox.Size = new Size(100, 23);
            UserPasswordLoginTextbox.TabIndex = 9;
            // 
            // UserEmailLoginTextbox
            // 
            UserEmailLoginTextbox.Location = new Point(150, 64);
            UserEmailLoginTextbox.Name = "UserEmailLoginTextbox";
            UserEmailLoginTextbox.Size = new Size(100, 23);
            UserEmailLoginTextbox.TabIndex = 7;
            // 
            // UserPassword1
            // 
            UserPassword1.AutoSize = true;
            UserPassword1.Location = new Point(3, 134);
            UserPassword1.Name = "UserPassword1";
            UserPassword1.Size = new Size(57, 15);
            UserPassword1.TabIndex = 5;
            UserPassword1.Text = "Password";
            // 
            // UserEmail1
            // 
            UserEmail1.AutoSize = true;
            UserEmail1.Location = new Point(3, 72);
            UserEmail1.Name = "UserEmail1";
            UserEmail1.Size = new Size(36, 15);
            UserEmail1.TabIndex = 3;
            UserEmail1.Text = "Email";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(46, 62);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(108, 23);
            btnLogin.TabIndex = 11;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnCreateAccount);
            panel3.Controls.Add(btnLogin);
            panel3.Location = new Point(302, 162);
            panel3.Name = "panel3";
            panel3.Size = new Size(200, 100);
            panel3.TabIndex = 13;
            
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
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
