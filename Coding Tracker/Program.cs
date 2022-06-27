using Coding_Tracker;

class CodingTracker
{
    public static void Main()
    {
        CodingController codingController = new CodingController();
        SqlController sqlController = new SqlController();
        sqlController.CreateTable();
        codingController.SwitchCommandPrompt();
    }

}