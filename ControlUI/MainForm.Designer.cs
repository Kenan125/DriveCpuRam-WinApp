namespace ControlUI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewCpu;
        private System.Windows.Forms.DataGridView dataGridViewRam;
        private System.Windows.Forms.DataGridView dataGridViewDrive;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnPauseResume;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel buttonLayoutPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "MainForm";

            this.dataGridViewCpu = new System.Windows.Forms.DataGridView();
            this.dataGridViewRam = new System.Windows.Forms.DataGridView();
            this.dataGridViewDrive = new System.Windows.Forms.DataGridView();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnPauseResume = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.buttonLayoutPanel = new System.Windows.Forms.TableLayoutPanel();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCpu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDrive)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.buttonLayoutPanel.SuspendLayout();
            this.SuspendLayout();

            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.dataGridViewCpu, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.dataGridViewRam, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.dataGridViewDrive, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.buttonLayoutPanel, 0, 3);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(784, 561);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // buttonLayoutPanel
            // 
            this.buttonLayoutPanel.ColumnCount = 4;
            this.buttonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.buttonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.buttonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.buttonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.buttonLayoutPanel.Controls.Add(this.btnSendEmail, 0, 0);
            this.buttonLayoutPanel.Controls.Add(this.btnSettings, 1, 0);
            this.buttonLayoutPanel.Controls.Add(this.btnLogout, 2, 0);
            this.buttonLayoutPanel.Controls.Add(this.btnPauseResume, 3, 0);
            this.buttonLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLayoutPanel.Location = new System.Drawing.Point(3, 522);
            this.buttonLayoutPanel.Name = "buttonLayoutPanel";
            this.buttonLayoutPanel.RowCount = 1;
            this.buttonLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonLayoutPanel.Size = new System.Drawing.Size(778, 36);
            this.buttonLayoutPanel.TabIndex = 1;
            // 
            // dataGridViewCpu
            // 
            this.dataGridViewCpu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCpu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCpu.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewCpu.Name = "dataGridViewCpu";
            this.dataGridViewCpu.Size = new System.Drawing.Size(778, 167);
            this.dataGridViewCpu.TabIndex = 0;
            this.dataGridViewCpu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            // 
            // dataGridViewRam
            // 
            this.dataGridViewRam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRam.Location = new System.Drawing.Point(3, 176);
            this.dataGridViewRam.Name = "dataGridViewRam";
            this.dataGridViewRam.Size = new System.Drawing.Size(778, 167);
            this.dataGridViewRam.TabIndex = 1;
            this.dataGridViewRam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            // 
            // dataGridViewDrive
            // 
            this.dataGridViewDrive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDrive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDrive.Location = new System.Drawing.Point(3, 349);
            this.dataGridViewDrive.Name = "dataGridViewDrive";
            this.dataGridViewDrive.Size = new System.Drawing.Size(778, 167);
            this.dataGridViewDrive.TabIndex = 2;
            this.dataGridViewDrive.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSendEmail.Location = new System.Drawing.Point(3, 3);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(188, 30);
            this.btnSendEmail.TabIndex = 0;
            this.btnSendEmail.Text = "Send to Email";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSettings.Location = new System.Drawing.Point(197, 3);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(188, 30);
            this.btnSettings.TabIndex = 1;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogout.Location = new System.Drawing.Point(391, 3);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(188, 30);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnPauseResume
            // 
            this.btnPauseResume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPauseResume.Location = new System.Drawing.Point(585, 3);
            this.btnPauseResume.Name = "btnPauseResume";
            this.btnPauseResume.Size = new System.Drawing.Size(190, 30);
            this.btnPauseResume.TabIndex = 3;
            this.btnPauseResume.Text = "Pause";
            this.btnPauseResume.UseVisualStyleBackColor = true;
            this.btnPauseResume.Click += new System.EventHandler(this.btnPauseResume_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "MainForm";
            this.Text = "PC Information";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCpu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDrive)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.buttonLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
