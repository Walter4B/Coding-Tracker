﻿using System.Data.SQLite;
using System.Globalization;
using System.Configuration;
using System.Collections.Specialized;
using Coding_Tracker;

class CodingTracker
{
    public static void Main()
    {
        Coding_Tracker.CodingController codingController = new CodingController();
        codingController.CreateTable();
        codingController.NewSession();
        codingController.ReadRecords();
        Console.ReadLine();

    }

}