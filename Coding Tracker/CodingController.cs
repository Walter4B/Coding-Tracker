using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Configuration;
using System.Collections.Specialized;
using ConsoleTableExt;

namespace Coding_Tracker
{
    internal class CodingController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["connectionKey"].ConnectionString;

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
                        //ConsoleTableBuilder
                        //.From(database.db)
                        //"SELECT column1, column2 FROM table1, table2 WHERE column2 = 'value';"


                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine($"{sqlDataReader.GetInt32(0)} - {sqlDataReader.GetString(1)} - {sqlDataReader.GetString(2)} - {sqlDataReader.GetString(3)}");
                        }
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

        internal void NewSession()
        {
            CodingSession session = new CodingSession();
            session.Id = 1; //make dinamic
            session.StartTime = DateTime.Now;
            //session.StartTime = DateTime.Now.ToString("h:mm:ss tt"); //add date && later user choice
            Console.WriteLine(session.StartTime);
            Console.WriteLine("If you wish to end the session please write 'end'");
            while (Console.ReadLine() != "end"){ }
            session.EndTime = DateTime.Now;
            Console.WriteLine(session.EndTime);
            Console.WriteLine(CalculateSessionDuration(session.StartTime, session.EndTime));
            InsertRecord(session.StartTime.ToString(), session.EndTime.ToString(), CalculateSessionDuration(session.StartTime, session.EndTime).ToString());
        }

        internal TimeSpan CalculateSessionDuration(DateTime startTime, DateTime endTime)
        {
            TimeSpan runTime = endTime.Subtract(startTime);
            return runTime;
        }
    }
}
