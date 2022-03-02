using System.Globalization;

namespace Coding_Tracker
{
    internal class CodingController
    {
        Coding_Tracker.SqlController sqlController = new SqlController();
        Coding_Tracker.UserInput userInputIntake = new UserInput();
        Coding_Tracker.StringOutputClass stringOutputClass = new StringOutputClass();

        internal void NewSession()
        {
            CodingSession session = new CodingSession();
            session.StartTime = DateTime.Now;
            stringOutputClass.OutputString("SessionStart", session.StartTime);
            stringOutputClass.OutputString("SessionEndInstruction");
            while (userInputIntake.GetUserInputString() != "end"){ }
            session.EndTime = DateTime.Now;
            stringOutputClass.OutputString("SessionEnd", session.EndTime);
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
                stringOutputClass.OutputString("MainMenu");

                string userInput = userInputIntake.GetUserInputString();

                if (string.IsNullOrEmpty(userInput) || !int.TryParse(userInput, out _))
                {
                    stringOutputClass.OutputString("InvalidInput");
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
                        stringOutputClass.OutputString("DeleteEntryInstruction");
                        sqlController.DeleteRecord(userInputIntake.GetUserInputInt());
                        break;
                    case 4:
                        UpdateSession();
                        break;
                    default:
                        stringOutputClass.OutputString("InvalidInput");
                        break;
                }
            }
        }

        internal void UpdateSession()
        {
            CodingSession session = new CodingSession();
            stringOutputClass.OutputString("UpdateChoseID");
            int updateId = userInputIntake.GetUserInputInt();
            stringOutputClass.OutputString("UpdateDateTimeStartDate");
            string startDateTime = userInputIntake.GetUserInputDateTime();
            stringOutputClass.OutputString("UpdateDateTimeEndDate");
            string endDateTime = userInputIntake.GetUserInputDateTime();
            var cultureInfo = new CultureInfo("de-DE");
            session.StartTime = DateTime.Parse(startDateTime );
            session.EndTime = DateTime.Parse(endDateTime);

            sqlController.UpdateRecordSQL(updateId, startDateTime, endDateTime, CalculateSessionDuration(session.StartTime, session.EndTime).ToString());
        }
    }
}
