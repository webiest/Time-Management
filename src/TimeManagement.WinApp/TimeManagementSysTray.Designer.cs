namespace TimeManagement.WinApp
{
    partial class TimeManagementSysTray
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeManagementSysTray));
            this.timeManagementIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.reportMonitor = new System.Windows.Forms.ToolStripMenuItem();
            this.startMonitoring = new System.Windows.Forms.ToolStripMenuItem();
            this.stopMonitoring = new System.Windows.Forms.ToolStripMenuItem();
            this.exitApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            // 
            // timeManagementIcon
            // 
            this.timeManagementIcon.ContextMenuStrip = this.contextMenuStrip;
            this.timeManagementIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("timeManagementIcon.Icon")));
            this.timeManagementIcon.Text = "TimeManagement";
            this.timeManagementIcon.Visible = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportMonitor,
            this.startMonitoring,
            this.stopMonitoring,
            this.aboutItem,
            this.exitApplication});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(162, 92);
            // 
            // reportMonitor
            // 
            this.reportMonitor.Name = "reportMonitor";
            this.reportMonitor.Size = new System.Drawing.Size(161, 22);
            this.reportMonitor.Text = "Report";
            this.reportMonitor.Click+=new System.EventHandler(Report_Click);
            // 
            // startMonitoring
            // 
            this.startMonitoring.Name = "startMonitoring";
            this.startMonitoring.Size = new System.Drawing.Size(161, 22);
            this.startMonitoring.Text = "Start Monitoring";
            this.startMonitoring.Click += new System.EventHandler(this.Start_Click);
            // 
            // stopMonitoring
            // 
            this.stopMonitoring.Name = "stopMonitoring";
            this.stopMonitoring.Size = new System.Drawing.Size(161, 22);
            this.stopMonitoring.Text = "Stop Monitoring";
            this.stopMonitoring.Click += new System.EventHandler(this.Stop_Click);
            // 
            // exitApplication
            // 
            this.exitApplication.Name = "exitApplication";
            this.exitApplication.Size = new System.Drawing.Size(161, 22);
            this.exitApplication.Text = "Exit";
            this.exitApplication.Click += new System.EventHandler(this.Exit_Click);
            // 
            // aboutItem
            // 
            this.aboutItem.Name = "aboutItem";
            this.aboutItem.Size = new System.Drawing.Size(161, 22);
            this.aboutItem.Text = "About...";
            this.aboutItem.Click += new System.EventHandler(this.About_Click);
            this.contextMenuStrip.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon timeManagementIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem reportMonitor;
        private System.Windows.Forms.ToolStripMenuItem startMonitoring;
        private System.Windows.Forms.ToolStripMenuItem stopMonitoring;
        private System.Windows.Forms.ToolStripMenuItem exitApplication;
        private System.Windows.Forms.ToolStripMenuItem aboutItem;
    }
}
