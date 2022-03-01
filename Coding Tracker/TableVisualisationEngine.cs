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
        

        internal void AddLine(int id, string startTime, string endTime, string sessionTime)
        {
            var tableDataLine = new List<object> { id, startTime, endTime, sessionTime };
        }

        internal void DisplayTable()
        {
            //ConsoleTableBuilder
                    //.From(tableDataLine)
                    //.WithColumn("ID", "Start Time", "End Time", "Session Time")
                    //.WithFormat(ConsoleTableBuilderFormat.Minimal)
                    //.ExportAndWriteLine();
        }
    }
}
