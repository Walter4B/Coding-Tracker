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
                    command.CommandText = @"CREATE TABLE IF NOT EXISTS CodingTable (ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, Date TEXT NOT NULL, Time TEXT NOT NULL)";
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
                        ConsoleTableBuilder
                            .From(database.db)
                            


                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine($"{sqlDataReader.GetInt32(0)} - {sqlDataReader.GetString(1)} - {sqlDataReader.GetString(2)}");
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

        internal void InsertRecordTesting(int x, int y)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = $"INSERT INTO CodingTable (Date, Time) VALUES('{x}','{y}');";
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

    }
}
