using System;
using System.Windows.Forms;
using Recorder;

namespace TimeManagement.WinApp
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                AppController controller = new AppController(new TimeManagementSysTray(), new RecorderServer(), new TimeCardReport());
                Application.Run();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unknown error occurred: " + ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }
    }
}
