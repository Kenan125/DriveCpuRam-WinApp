namespace DriveCpuRam_WinApp
{
    partial class UserInfoDisplay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            components = new System.ComponentModel.Container();
            sqlDataSenderBindingSource = new BindingSource(components);
            ramInfoBindingSource = new BindingSource(components);
            sqlDataSenderBindingSource1 = new BindingSource(components);
            timer1 = new System.Windows.Forms.Timer(components);
            timer2 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)sqlDataSenderBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ramInfoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sqlDataSenderBindingSource1).BeginInit();
            SuspendLayout();
            // 
            // sqlDataSenderBindingSource
            // 
            sqlDataSenderBindingSource.DataSource = typeof(SqlDataSender);
            // 
            // ramInfoBindingSource
            // 
            ramInfoBindingSource.DataSource = typeof(PcInfo.RamInfo);
            // 
            // sqlDataSenderBindingSource1
            // 
            sqlDataSenderBindingSource1.DataSource = typeof(SqlDataSender);
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // UserInfoDisplay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 558);
            Name = "UserInfoDisplay";
            Text = "UserInfoDisplay";
            ((System.ComponentModel.ISupportInitialize)sqlDataSenderBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)ramInfoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)sqlDataSenderBindingSource1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private BindingSource ramInfoBindingSource;
        private BindingSource sqlDataSenderBindingSource;
        private BindingSource sqlDataSenderBindingSource1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}