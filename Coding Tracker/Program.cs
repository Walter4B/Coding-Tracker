using Coding_Tracker;

class CodingTracker
{
    public static void Main()
    {
        Coding_Tracker.CodingController codingController = new CodingController();
        codingController.CreateTable();
        codingController.SwitchCommandPrompt();
    }

}