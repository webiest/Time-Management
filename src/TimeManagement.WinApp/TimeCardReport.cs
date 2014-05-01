using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TimeManagement.WinApp
{
    public partial class TimeCardReport : Form
    {
        public TimeCardReport()
        {
            InitializeComponent();
            InitChart();
            this.Hide();
        }

        private void InitChart()
        {
            this.timeReportChart.Series[0].ChartType = SeriesChartType.Bar;
            this.timeReportChart.ChartAreas[0].Area3DStyle.Enable3D = true;
            this.timeReportChart.ChartAreas[0].Area3DStyle.Rotation = 30;
            this.timeReportChart.ChartAreas[0].Area3DStyle.Inclination = 10;
            this.timeReportChart.ChartAreas[0].Area3DStyle.IsRightAngleAxes = true;

        }


        public DataGridView TimeCardDataGrid
        {
            get { return this.timeCardDataGrid; }
            set
            {
                if (this.timeCardDataGrid != value)
                    this.timeCardDataGrid = value;
            }
        }


        public Chart TimeCardChart
        {
            get { return this.timeReportChart; }
            set
            {
                if (this.timeReportChart != value)
                    this.timeReportChart = value;
            }
        }

        public void PopulateData(DataSet data)
        {
            //DataView view = new DataView(data.Tables[0]);
            //this.timeReportChart.Series[0].Points.DataBindXY(view, "Title", view, "Duration");
        }

        public void ExitApp()
        {
            Application.Exit();
        }

        public event EventHandler RefreshEventClick;

        private void refreshButton_Click(object sender, EventArgs e)
        {
            if (RefreshEventClick != null)
            {
                RefreshEventClick(sender, e);
            }
        }
    }
}
