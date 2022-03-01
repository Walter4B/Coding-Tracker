using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Tracker
{
    internal class UserInput
    {
        Coding_Tracker.Validation Validatior = new Validation();

        internal int GetUserInputInt()
        {
            string userInput = Console.ReadLine();
            while (!Validatior.ValidateIntInput(userInput))
            {
                Console.WriteLine("Please insert a valid input");
                userInput = Console.ReadLine();
            }
            int userInputInt = Convert.ToInt32(userInput);
            return userInputInt;
        }

        internal string GetUserInputString()
        { 
            return Console.ReadLine();
        }




    }
}
