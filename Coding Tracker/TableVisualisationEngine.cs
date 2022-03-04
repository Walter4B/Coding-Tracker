using ConsoleTableExt;

namespace Coding_Tracker
{
    internal class TableVisualisationEngine
    {
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
