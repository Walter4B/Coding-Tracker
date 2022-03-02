namespace Coding_Tracker
{
    internal class UserInput
    {
        Coding_Tracker.Validation Validatior = new Validation();
        Coding_Tracker.StringOutputClass stringOutputClass = new StringOutputClass();

        internal int GetUserInputInt()
        {
            string userInput = Console.ReadLine();
            while (!Validatior.ValidateIntInput(userInput))
            {
                stringOutputClass.OutputString("InvalidInput");
                userInput = Console.ReadLine();
            }
            int userInputInt = Convert.ToInt32(userInput);
            return userInputInt;
        }

        internal string GetUserInputString()
        { 
            return Console.ReadLine();
        }

        internal string GetUserInputDateTime()
        { 
            string userInputDateTime = Console.ReadLine();
            while (!Validatior.ValidateDateTimeInput(userInputDateTime))
            {
                stringOutputClass.OutputString("InvalidDateInput");
                userInputDateTime = Console.ReadLine();
            }
            return userInputDateTime;
        }


    }
}
