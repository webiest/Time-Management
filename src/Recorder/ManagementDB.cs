using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace Recorder
{
    public class ManagementDB : IManagementDB, IDisposable
    {
        private string RecordTableName = "RecordEntryData";
        private string ConnectionString;
        private SQLiteConnection Connection;

        public ManagementDB(string dbFilename)
        {
            OpenDB(dbFilename);
            InitDB();
        }

        #region Initialization

        private void OpenDB(string dbFilename)
        {
            ConnectionString = string.Format("Data Source={0}", dbFilename);
            Connection = new SQLiteConnection(ConnectionString);
            Connection.Open();
        }

        private void InitDB()
        {
            if (TableExists(RecordTableName) == false)
                CreateRecordEntryDataTable();
        }

        private bool TableExists(string tableName)
        {
            bool result = false;
            using (SQLiteCommand cmd = Connection.CreateCommand())
            {
                cmd.CommandText = "SELECT Name FROM sqlite_master WHERE Type='table' AND Name=@TableName";
                cmd.Parameters.Add(new SQLiteParameter("TableName", tableName));

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "TableName");
                    if (ds.Tables["TableName"].Rows.Count == 1)
                        result = true;
                }
            }
            return result;
        }

        private void CreateRecordEntryDataTable()
        {
            using (SQLiteCommand cmd = Connection.CreateCommand())
            {
                try
                {
                    cmd.CommandText = string.Format("CREATE TABLE {0} (RecordID INTEGER, RecordDate DATETIME, ProcName VARCHAR, Title VARCHAR, Duration DOUBLE)", RecordTableName);
                    int result = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error on database initialization" + e.StackTrace);
                }
            }
        }

        #endregion

        #region IManagementDB Members

        public void InsertRecordEntry(RecordEntry item)
        {
            SQLiteCommand command = CreateCommand();
            command.Parameters.Add(new SQLiteParameter("@RecordDate", item.dateTime));
            command.Parameters.Add(new SQLiteParameter("@ProcName", item.procName));
            command.Parameters.Add(new SQLiteParameter("@Title", item.title));
            command.Parameters.Add(new SQLiteParameter("@Duration", item.timeSpan.TotalMinutes));
            command.ExecuteNonQuery();
        }

        private SQLiteCommand CreateCommand()
        {
            string commandText = string.Format("INSERT INTO {0} (RecordID, RecordDate, ProcName, Title, Duration) VALUES ((SELECT MAX(RecordID) FROM {0})+1, @RecordDate, @ProcName, @Title, @Duration)", RecordTableName);
            return new SQLiteCommand(commandText, this.Connection);
        }


        public DataSet GetTodaysReport()
        {
            DataSet dataSet = new DataSet();
            string commandText = string.Format("SELECT ProcName||Title AS Program, SUM(Duration) AS 'Total Time' FROM {0} WHERE RecordDate >= @TodaysDate GROUP BY Program ORDER BY 'Total Time';", RecordTableName);
            SQLiteCommand command = new SQLiteCommand(commandText, this.Connection);
            Console.WriteLine("date being sent {0}", DateTime.Today.Date);
            command.Parameters.Add(new SQLiteParameter("@TodaysDate", DateTime.Today.Date));
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            adapter.Fill(dataSet, "RecordEntries");
            return dataSet;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Connection.Close();
        }

        #endregion
    }
}
