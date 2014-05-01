using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Recorder
{
    public interface IRecorderServer
    {
        void Start();
        void Stop();
        bool IsRunning { get; }
        DataSet GetReport();
    }
}
