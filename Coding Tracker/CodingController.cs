using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Configuration;
using System.Collections.Specialized;
using ConsoleTableExt;
using System.Globalization;

namespace Coding_Tracker
{
    internal class CodingController
    {
        Coding_Tracker.SqlController sqlController = new SqlController();
        Coding_Tracker.UserInput userInputIntake = new UserInput();

        internal void NewSession()
        {
            CodingSession session = new CodingSession();
            session.StartTime = DateTime.Now;
            Console.WriteLine("session started at: " + session.StartTime);
            Console.WriteLine("If you wish to end the session please write 'end'");
            while (userInputIntake.GetUserInputString() != "end"){ }
            session.EndTime = DateTime.Now;
            Console.WriteLine("Session ended at: " + session.EndTime);
            sqlController.InsertRecord(session.StartTime.ToString(), session.EndTime.ToString(), CalculateSessionDuration(session.StartTime, session.EndTime).ToString());
        }

        internal TimeSpan CalculateSessionDuration(DateTime startTime, DateTime endTime)
        {
            TimeSpan runTime = endTime.Subtract(startTime);
            return runTime;
        }

        internal void SwitchCommandPrompt()
        {
            bool programRunning = true;
            while (programRunning)
            {
            Console.WriteLine
                ("\n       MAIN MENU       \n\n" +
                "What would you like to do?\n" +
                "Type 0 to Close Application.\n" +
                "Type 1 to View All Records.\n" +
                "Type 2 to Start New Session.\n" +
                "Type 3 to Delete Record.\n" +
                "Type 4 to Update Record.\n");
            //Console.WriteLine(System.Configuration.ConfigurationManager.AppSettings["Key0"]);

            string userInput = userInputIntake.GetUserInputString();
            
            if(string.IsNullOrEmpty(userInput) || !int.TryParse(userInput, out _))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

            int commandNumber = Convert.ToInt32(userInput);

                switch (commandNumber)
                {
                    case 0:
                        programRunning = false; 
                        break;
                    case 1:
                        sqlController.ReadRecords();
                        break;
                    case 2:
                        NewSession();
                        break;
                    case 3:
                        Console.WriteLine("Chose ID of entry you want to delete");
                        sqlController.DeleteRecord(userInputIntake.GetUserInputInt());
                        break;
                    case 4:
                        UpdateSession();
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }

        internal void UpdateSession()
        {
            CodingSession session = new CodingSession();
            Console.WriteLine("Chose ID of entry you want to update");
            int updateId = userInputIntake.GetUserInputInt();
            Console.WriteLine("Input start date and time. Please use format (dd/mm/yyyy hh:mm:ss)");
            string startDateTime = userInputIntake.GetUserInputDateTime();
            Console.WriteLine("Input end date and time. Please use format (dd/mm/yyyy hh:mm:ss)");
            string endDateTime = userInputIntake.GetUserInputDateTime();
            var cultureInfo = new CultureInfo("de-DE");
            session.StartTime = DateTime.Parse(startDateTime );
            session.EndTime = DateTime.Parse(endDateTime);

            sqlController.UpdateRecordSQL(updateId, startDateTime, endDateTime, CalculateSessionDuration(session.StartTime, session.EndTime).ToString());
        }

    }
}
