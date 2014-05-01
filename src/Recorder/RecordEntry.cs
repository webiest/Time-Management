using System;
using System.Collections.Generic;
using System.Text;

namespace Recorder
{
    public struct RecordEntry
    {
        public DateTime dateTime;
        public string procName;
        public string title;
        public TimeSpan timeSpan;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(dateTime.ToString("MM/dd/yyyy"));
            sb.Append(",");
            sb.Append(dateTime.ToString("HH:mm:ss"));
            sb.Append(",");
            sb.Append(procName);
            sb.Append(",");
            sb.Append(title);
            sb.Append(",");
            sb.Append(timeSpan.TotalMinutes);
            return sb.ToString();
        }
    }
}
