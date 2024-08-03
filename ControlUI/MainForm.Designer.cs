namespace ControlUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewCpu;
        private System.Windows.Forms.DataGridView dataGridViewRam;
        private System.Windows.Forms.DataGridView dataGridViewDrive;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCpu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDrive)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.dataGridViewCpu, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.dataGridViewRam, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.dataGridViewDrive, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.btnSendEmail, 0, 3);
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
            this.btnSendEmail.Location = new System.Drawing.Point(3, 522);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(778, 36);
            this.btnSendEmail.TabIndex = 3;
            this.btnSendEmail.Text = "Send to Email";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
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
            this.ResumeLayout(false);
        }

        #endregion
    }
}