using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Tracker
{
    internal class Validation 
    {
        internal bool ValidateIntInput(string userInput)
        {
            int validUserInput;
            if (int.TryParse(userInput, out validUserInput))
                return true;
            else
                return false;
        }

        internal bool ValidateInput(string userInput)
        {
            if (true)
                return true;
            else
                return false;
        }
    }
}
