using System.Data.SQLite;
using System.Globalization;
using Coding_Tracker;

class CodingTracker
{
    public static void Main()
    {
        Coding_Tracker.CodingController codingController = new CodingController();
        codingController.CreateTable();
        codingController.InsertRecordTesting(1, 20);
        codingController.ReadRecords();
        Console.ReadLine();

    }

}