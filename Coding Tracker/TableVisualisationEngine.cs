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

        internal void DisplayTable(List<List<Object>> ListOfTableLines )
        {
            ConsoleTableBuilder
                    .From(ListOfTableLines)
                    .WithColumn("ID", "StartTime", "EndTime", "SessionTime")
                    .WithFormat(ConsoleTableBuilderFormat.Alternative)
                    .ExportAndWriteLine();
        }
    }
}
