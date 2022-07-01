using Coding_Tracker;

namespace CodingTracker.UnitTests
{
    [TestClass]
    public class UserInputTests
    {
        [TestMethod]
        public void GetUserInputInt_InputIsInt_ReturnsTrue()
        {
            var userInput = new UserInput();

            var result = userInput.GetUserInputInt();



            Assert.IsInstanceOfType(result, typeof(int));
        }
    }
}
