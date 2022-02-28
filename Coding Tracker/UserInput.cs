using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Tracker
{
    internal class UserInput
    {
        internal string UserChooseDateFormat(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine
                (
                "\n Please choose date format. (Input a number from 1 to 3)\n" +
                "1) \n" +
                "2) \n" +
                "3) \n"
                );
            string UserInput = Console.ReadLine();
            return UserInput;
        }

    }
}
