using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace TimeManagement.WinApp
{
    public partial class TimeManagementSysTray : Component, ITimeManageSysTray
    {
        public TimeManagementSysTray()
        {
            InitializeComponent();
        }

        public TimeManagementSysTray(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void About_Click(object sender, EventArgs e)
        {
            MessageBox.Show("http://wiki.github.com/iyo/Time-Management");
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (StartEvent != null)
            {
                StartEvent(sender, e);
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            if (StopEvent != null)
            {
                StopEvent(sender, e);
            }
        }

        private void Report_Click(object sender, EventArgs e)
        {
            if (ReportEvent != null)
            {
                this.reportMonitor.Checked = !this.reportMonitor.Checked;
                ReportEvent(sender, e);
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            if (ExitEvent != null)
            {
                ExitEvent(sender, e);
                this.timeManagementIcon.Visible = false;
            }
        }

        #region ITimeManageSysTray Members

        public bool StartEnabled
        {
            set
            {
                if (this.startMonitoring.Enabled != value)
                    this.startMonitoring.Enabled = value;
            }
        }

        public bool StopEnabled
        {
            set
            {
                if (this.stopMonitoring.Enabled != value)
                    this.stopMonitoring.Enabled = value;
            }
        }

        public event EventHandler StopEvent;

        public event EventHandler StartEvent;

        public event EventHandler ReportEvent;

        public event EventHandler ExitEvent;

        #endregion
    }
}
