namespace ControlUI
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        
        private System.Windows.Forms.Button btnChangeName;
        private System.Windows.Forms.Button btnChangeSurname;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnChangePhoneNumber;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Button btnSaveName;
        private System.Windows.Forms.Button btnSaveSurname;
        private System.Windows.Forms.Button btnSavePassword;
        private System.Windows.Forms.Button btnSavePhoneNumber;
        private System.Windows.Forms.Button btnBack;
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnChangeName = new Button();
            btnChangeSurname = new Button();
            btnChangePassword = new Button();
            btnChangePhoneNumber = new Button();
            lblName = new Label();
            lblSurname = new Label();
            lblPassword = new Label();
            lblPhoneNumber = new Label();
            txtName = new TextBox();
            txtSurname = new TextBox();
            txtPassword = new TextBox();
            txtPhoneNumber = new TextBox();
            btnSaveName = new Button();
            btnSaveSurname = new Button();
            btnSavePassword = new Button();
            btnSavePhoneNumber = new Button();
            btnBack = new Button();
            SuspendLayout();
            // 
            // btnChangeName
            // 
            btnChangeName.Location = new Point(12, 12);
            btnChangeName.Name = "btnChangeName";
            btnChangeName.Size = new Size(200, 40);
            btnChangeName.TabIndex = 0;
            btnChangeName.Text = "Change Name";
            btnChangeName.UseVisualStyleBackColor = true;
            btnChangeName.Click += btnChangeName_Click;
            // 
            // btnChangeSurname
            // 
            btnChangeSurname.Location = new Point(12, 58);
            btnChangeSurname.Name = "btnChangeSurname";
            btnChangeSurname.Size = new Size(200, 40);
            btnChangeSurname.TabIndex = 1;
            btnChangeSurname.Text = "Change Surname";
            btnChangeSurname.UseVisualStyleBackColor = true;
            btnChangeSurname.Click += btnChangeSurname_Click;
            // 
            // btnChangePassword
            // 
            btnChangePassword.Location = new Point(12, 104);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(200, 40);
            btnChangePassword.TabIndex = 2;
            btnChangePassword.Text = "Change Password";
            btnChangePassword.UseVisualStyleBackColor = true;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // btnChangePhoneNumber
            // 
            btnChangePhoneNumber.Location = new Point(12, 150);
            btnChangePhoneNumber.Name = "btnChangePhoneNumber";
            btnChangePhoneNumber.Size = new Size(200, 40);
            btnChangePhoneNumber.TabIndex = 3;
            btnChangePhoneNumber.Text = "Change Phone Number";
            btnChangePhoneNumber.UseVisualStyleBackColor = true;
            btnChangePhoneNumber.Click += btnChangePhoneNumber_Click;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(230, 25);
            lblName.Name = "lblName";
            lblName.Size = new Size(52, 20);
            lblName.TabIndex = 4;
            lblName.Text = "Name:";
            lblName.Visible = false;
            // 
            // lblSurname
            // 
            lblSurname.AutoSize = true;
            lblSurname.Location = new Point(230, 71);
            lblSurname.Name = "lblSurname";
            lblSurname.Size = new Size(70, 20);
            lblSurname.TabIndex = 5;
            lblSurname.Text = "Surname:";
            lblSurname.Visible = false;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(230, 117);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(73, 20);
            lblPassword.TabIndex = 6;
            lblPassword.Text = "Password:";
            lblPassword.Visible = false;
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Location = new Point(218, 163);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(111, 20);
            lblPhoneNumber.TabIndex = 7;
            lblPhoneNumber.Text = "Phone Number:";
            lblPhoneNumber.Visible = false;
            // 
            // txtName
            // 
            txtName.Location = new Point(330, 22);
            txtName.Name = "txtName";
            txtName.Size = new Size(150, 27);
            txtName.TabIndex = 8;
            txtName.Visible = false;
            // 
            // txtSurname
            // 
            txtSurname.Location = new Point(330, 68);
            txtSurname.Name = "txtSurname";
            txtSurname.Size = new Size(150, 27);
            txtSurname.TabIndex = 9;
            txtSurname.Visible = false;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(330, 114);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(150, 27);
            txtPassword.TabIndex = 10;
            txtPassword.Visible = false;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(330, 160);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(150, 27);
            txtPhoneNumber.TabIndex = 11;
            txtPhoneNumber.Visible = false;
            // 
            // btnSaveName
            // 
            btnSaveName.Location = new Point(500, 20);
            btnSaveName.Name = "btnSaveName";
            btnSaveName.Size = new Size(75, 32);
            btnSaveName.TabIndex = 12;
            btnSaveName.Text = "Save";
            btnSaveName.UseVisualStyleBackColor = true;
            btnSaveName.Visible = false;
            btnSaveName.Click += btnSaveName_Click;
            // 
            // btnSaveSurname
            // 
            btnSaveSurname.Location = new Point(500, 66);
            btnSaveSurname.Name = "btnSaveSurname";
            btnSaveSurname.Size = new Size(75, 32);
            btnSaveSurname.TabIndex = 13;
            btnSaveSurname.Text = "Save";
            btnSaveSurname.UseVisualStyleBackColor = true;
            btnSaveSurname.Visible = false;
            btnSaveSurname.Click += btnSaveSurname_Click;
            // 
            // btnSavePassword
            // 
            btnSavePassword.Location = new Point(500, 112);
            btnSavePassword.Name = "btnSavePassword";
            btnSavePassword.Size = new Size(75, 32);
            btnSavePassword.TabIndex = 14;
            btnSavePassword.Text = "Save";
            btnSavePassword.UseVisualStyleBackColor = true;
            btnSavePassword.Visible = false;
            btnSavePassword.Click += btnSavePassword_Click;
            // 
            // btnSavePhoneNumber
            // 
            btnSavePhoneNumber.Location = new Point(500, 158);
            btnSavePhoneNumber.Name = "btnSavePhoneNumber";
            btnSavePhoneNumber.Size = new Size(75, 32);
            btnSavePhoneNumber.TabIndex = 15;
            btnSavePhoneNumber.Text = "Save";
            btnSavePhoneNumber.UseVisualStyleBackColor = true;
            btnSavePhoneNumber.Visible = false;
            btnSavePhoneNumber.Click += btnSavePhoneNumber_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(12, 200);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 40);
            btnBack.TabIndex = 16;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 260);
            Controls.Add(btnBack);
            Controls.Add(btnSavePhoneNumber);
            Controls.Add(btnSavePassword);
            Controls.Add(btnSaveSurname);
            Controls.Add(btnSaveName);
            Controls.Add(txtPhoneNumber);
            Controls.Add(txtPassword);
            Controls.Add(txtSurname);
            Controls.Add(txtName);
            Controls.Add(lblPhoneNumber);
            Controls.Add(lblPassword);
            Controls.Add(lblSurname);
            Controls.Add(lblName);
            Controls.Add(btnChangePhoneNumber);
            Controls.Add(btnChangePassword);
            Controls.Add(btnChangeSurname);
            Controls.Add(btnChangeName);
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Settings";
            ResumeLayout(false);
            PerformLayout();
        }
    }

        #endregion
    }
