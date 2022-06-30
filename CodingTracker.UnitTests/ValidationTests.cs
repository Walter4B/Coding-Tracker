using Coding_Tracker;

namespace CodingTracker.UnitTests
{
    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void ValidateIntInput_InputIsInt_ReturnsTrue()
        {
            //Arrange

            var Validation = new Validation();

            //Act

            var result = Validation.ValidateIntInput("1"); // reservation.CanBeCancelledBy(new User {IsAdmin = true});

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateIntInput_InputIsNotInt_ReturnsFalse()
        {

            var Validation = new Validation();

            var result = Validation.ValidateIntInput("a1");

            Assert.IsFalse(result);

        }

        [TestMethod]
        public void ValidateDateTimeInput_InputIsDateTime_ReturnsTrue()
        {

            var Validation = new Validation();

            var result = Validation.ValidateDateTimeInput("10.10.2022 12:12:12");

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void ValidateDateTimeInput_InputIsNotDateTime_ReturnsFalse()
        {

            var Validation = new Validation();

            var result = Validation.ValidateDateTimeInput("AA.10.2022 12:12:12");

            Assert.IsFalse(result);

        }
    }
}