namespace Coding_Tracker
{
    internal class Validation 
    {
        internal bool ValidateIntInput(string userInput)
        {
            if (int.TryParse(userInput, out _))
                return true;
            else
                return false;
        }

        internal bool ValidateDateTimeInput(string userInput)
        {
            if (DateTime.TryParse(userInput, out _))
                return true;
            else
                return false;
        }


    }
}
