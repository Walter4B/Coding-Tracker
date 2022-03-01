using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Configuration;
using System.Threading.Tasks;

namespace Coding_Tracker
{
    internal class SqlController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["connectionKey"].ConnectionString;
        Coding_Tracker.TableVisualisationEngine tableVisualisationEngine = new TableVisualisationEngine();

        internal void CreateTable()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = @"CREATE TABLE IF NOT EXISTS CodingTable (ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, StartTime TEXT NOT NULL, EndTime TEXT NOT NULL, RunTime TEXT NOT NULL)";
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        internal void ReadRecords()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    string CommandText = $"SELECT * FROM CodingTable";
                    command.CommandText = CommandText;
                    using (SQLiteDataReader sqlDataReader = command.ExecuteReader())
                    {
                        var tableData = new List<List<object>> { };

                        while (sqlDataReader.Read())
                        {
                            tableData.Add(new List<object> { sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2), sqlDataReader.GetString(3) });
                        }
                        tableVisualisationEngine.DisplayTable(tableData);
                    }
                    connection.Close();
                }
            }
        }

        internal void DeleteRecord(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = $"DELETE FROM CodingTable WHERE ID = '{id}';";
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        internal void InsertRecord(string startTime, string endTime, string runTime)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = $"INSERT INTO CodingTable (StartTime, EndTime, RunTime) VALUES('{startTime}','{endTime}','{runTime}');";
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
