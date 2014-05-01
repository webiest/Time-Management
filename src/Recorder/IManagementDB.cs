using System;
using System.Data;

namespace Recorder
{
    public interface IManagementDB
    {
        void InsertRecordEntry(RecordEntry item);
        DataSet GetTodaysReport();
    }
}
