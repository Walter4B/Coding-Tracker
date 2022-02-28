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
        Coding_Tracker.SqlController sqlController = new SqlController();
        internal void NewSession()
        {
            CodingSession session = new CodingSession();
            session.StartTime = DateTime.Now;
            //session.StartTime = DateTime.Now.ToString("h:mm:ss tt"); //add date && later user choice
            Console.WriteLine(session.StartTime);
            Console.WriteLine("If you wish to end the session please write 'end'");
            while (Console.ReadLine() != "end"){ }
            session.EndTime = DateTime.Now;
            Console.WriteLine(session.EndTime);
            Console.WriteLine(CalculateSessionDuration(session.StartTime, session.EndTime));
            sqlController.InsertRecord(session.StartTime.ToString(), session.EndTime.ToString(), CalculateSessionDuration(session.StartTime, session.EndTime).ToString());
        }

        internal TimeSpan CalculateSessionDuration(DateTime startTime, DateTime endTime)
        {
            TimeSpan runTime = endTime.Subtract(startTime);
            return runTime;
        }

        internal void SwitchCommandPrompt()
        {
            Console.WriteLine
                ("\n       MAIN MENU       \n\n" +
                "What would you like to do?\n" +
                "Type 0 to Close Application.\n" +
                "Type 1 to View All Records.\n" +
                "Type 2 to Start New Session.\n" +
                "Type 3 to Delete Record.\n");

            string userInput = Console.ReadLine();
            int commandNumber;

            if (int.TryParse(userInput, out commandNumber))
            {
                switch (commandNumber)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        sqlController.ReadRecords();
                        break;
                    case 2:
                        NewSession();
                        break;
                    case 3:
                        Console.WriteLine("Chose ID of entry you want to delete");
                        sqlController.DeleteRecord(Convert.ToInt32(Console.ReadLine()));
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        SwitchCommandPrompt();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
                SwitchCommandPrompt();
            }
            SwitchCommandPrompt();
        }

    }
}
