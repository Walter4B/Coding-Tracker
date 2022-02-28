using Coding_Tracker;

class CodingTracker
{
    public static void Main()
    {
        Coding_Tracker.CodingController codingController = new CodingController();
        Coding_Tracker.SqlController sqlController = new SqlController();
        sqlController.CreateTable();
        codingController.SwitchCommandPrompt();
    }

}