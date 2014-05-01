using System;
using System.Collections.Generic;
using System.Text;

namespace TimeManagement.WinApp
{
    public interface ITimeManageSysTray
    {
        bool StartEnabled { set; }
        bool StopEnabled { set; }

        event EventHandler ReportEvent;
        event EventHandler StopEvent;
        event EventHandler StartEvent;
        event EventHandler ExitEvent;
    }
}
