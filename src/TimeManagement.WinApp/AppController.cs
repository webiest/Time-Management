using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Recorder;

namespace TimeManagement.WinApp
{
    public class AppController
    {
        TimeCardReport report;
        ITimeManageSysTray sysTray;
        IRecorderServer recorder;
        public AppController(ITimeManageSysTray sysTray, IRecorderServer recorder, TimeCardReport report)
        {
            this.sysTray = sysTray;
            this.recorder = recorder;
            this.report = report;
            WireItems();
            BindItems();
            ControlsOnServerOff();
        }

        private void WireItems()
        {
            this.sysTray.ReportEvent += new EventHandler(sysTray_ReportEvent);
            this.sysTray.ExitEvent += new EventHandler(sysTray_ExitEvent);
            this.sysTray.StartEvent += new EventHandler(sysTray_StartEvent);
            this.sysTray.StopEvent += new EventHandler(sysTray_StopEvent);
            this.report.RefreshEventClick += new EventHandler(report_RefreshEventClick);   
        }

        private void BindItems()
        {
            DataSet ds = this.recorder.GetReport();
            this.report.TimeCardChart.DataSource = ds;
            this.report.TimeCardChart.DataBind();
            this.report.TimeCardChart.Series[0].XValueMember = "Program";
            this.report.TimeCardChart.Series[0].YValueMembers = "Total Time";
            this.report.TimeCardDataGrid.DataSource = ds;
            this.report.TimeCardDataGrid.DataMember = "RecordEntries";
        }

        private void report_RefreshEventClick(object sender, EventArgs e)
        {
            this.BindItems();
        }

        private void sysTray_ReportEvent(object sender, EventArgs e)
        {
            this.report.Visible = !this.report.Visible;
        }

        private void sysTray_StopEvent(object sender, EventArgs e)
        {
            this.recorder.Stop();
            this.ControlsOnServerOff();
        }

        private void sysTray_StartEvent(object sender, EventArgs e)
        {
            this.recorder.Start();
            this.ControlsOnServerRunning();
        }

        private void sysTray_ExitEvent(object sender, EventArgs e)
        {
            this.recorder.Stop();
            this.AllControlsOff();
            this.report.ExitApp();
        }


        private void AllControlsOff()
        {
            this.sysTray.StartEnabled = false;
            this.sysTray.StopEnabled = false;
        }

        private void ControlsOnServerRunning()
        {
            this.sysTray.StartEnabled = false;
            this.sysTray.StopEnabled = true;
        }

        private void ControlsOnServerOff()
        {
            this.sysTray.StartEnabled = true;
            this.sysTray.StopEnabled = false;
        }
    }
}
