using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTableExt;

namespace Coding_Tracker
{
    internal class TableVisualisationEngine
    {
        //ConsoleTableBuilder
        //.From(database.db)
        //"SELECT column1, column2 FROM table1, table2 WHERE column2 = 'value';"
        internal void DisplayTable(int id, string startTime, string endTime, string sessionTime)
        {
            Console.WriteLine($"{id} - {startTime} - {endTime} - {sessionTime}");
        }

    }
}
