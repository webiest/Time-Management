using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Data;

namespace Recorder
{
    /// <summary>
    /// RecorderServer polls the active window for any changes.  If any changes
    /// have occured, they're entered into the database file.
    /// 
    /// A lot of the original code by Dana Hanna resides here.
    /// </summary>
    public class RecorderServer : IRecorderServer
    {
        private Thread recorderThread;
        private string dbFilename;
        private IntPtr desktopWin;
        private IntPtr lastWin = IntPtr.Zero;
        private RecordEntry lastEntry;
        private IManagementDB tmDb;
        private const uint GA_PARENT = 1;
        private const uint GA_ROOT = 2;
        private const uint GA_ROOTOWNER = 3;
        private int pollRate;
        private bool RUN = true;

        public RecorderServer() : this("TimeManagement.db") { }
        public RecorderServer(string dbFilename) : this(dbFilename, 5000) { }
        public RecorderServer(string dbFilename, int pollRate)
        {
            this.dbFilename = dbFilename;
            this.pollRate = pollRate;
            tmDb = new ManagementDB(this.dbFilename);
        }


        public void Start()
        {
            recorderThread = new Thread(RecorderThread);
            recorderThread.IsBackground = true;
            recorderThread.Name = "Recorder";
            recorderThread.Start();
        }

        protected void RecorderThread()
        {
            while (RUN)
            {
                try
                {
                    //get the process window name and exe name
                    desktopWin = WinOps.GetDesktopWindow();
                    IntPtr tempWin = WinOps.GetForegroundWindow();
                    IntPtr win = tempWin;
                    while (tempWin != IntPtr.Zero && tempWin != desktopWin)
                    {
                        win = tempWin;
                        tempWin = WinOps.GetAncestor(tempWin, GA_PARENT);
                    }
                    StringBuilder sb = new StringBuilder();
                    WinOps.GetWindowText(win, sb, 150);
                    string title = sb.ToString();
                    if (win != lastWin || title != lastEntry.title)
                    {
                        lastWin = win;
                        if (lastEntry.procName != null)
                        {
                            lastEntry.timeSpan = DateTime.Now - lastEntry.dateTime;
                            tmDb.InsertRecordEntry(lastEntry);
                        }
                        uint procId;
                        WinOps.GetWindowThreadProcessId(win, out procId);
                        Process p = Process.GetProcessById((int)procId);
                        string procName = p.ProcessName;
                        //now title is the win title and procName is the EXE
                        lastEntry.dateTime = DateTime.Now;
                        lastEntry.procName = procName;
                        lastEntry.title = title;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message + Environment.NewLine + "The application will retry..." + Environment.NewLine + ex.StackTrace + Environment.NewLine);
                }
                finally
                {
                    Thread.Sleep(pollRate);
                }
            }
        }

        public void Stop()
        {
            this.RUN = false;
            Thread.Sleep(this.pollRate + 1000);
        }


        public bool IsRunning { get { return this.RUN; } }


        public DataSet GetReport()
        {
            return tmDb.GetTodaysReport();
        }
    }
}
