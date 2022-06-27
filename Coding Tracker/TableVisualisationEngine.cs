using ConsoleTableExt;

namespace Coding_Tracker
{
    internal class TableVisualisationEngine
    {
        internal void DisplayTable(List<List<Object>> ListOfTableLines )
        {
            ConsoleTableBuilder
                    .From(ListOfTableLines)
                    .WithFormat(ConsoleTableBuilderFormat.Alternative)
                    .ExportAndWriteLine();
        }
    }
}
