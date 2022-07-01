using Coding_Tracker;

namespace CodingTracker.UnitTests
{
    [TestClass]
    public class ValidationTests
    {
        //ValidateIntInput

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
        public void ValidateIntInput_InputIsIntNegativ_ReturnsTrue()
        {
            var Validation = new Validation();

            var result = Validation.ValidateIntInput("-1");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateIntInput_InputIsDecimal_ReturnsFalse()
        {

            var Validation = new Validation();

            var result = Validation.ValidateIntInput("4.6");

            Assert.IsFalse(result);

        }

        [TestMethod]
        public void ValidateIntInput_InputIsString_ReturnsFalse()
        {

            var Validation = new Validation();

            var result = Validation.ValidateIntInput("afds1");

            Assert.IsFalse(result);

        }

        [TestMethod]
        public void ValidateIntInput_InputIsEmpty_ReturnsTrue()
        {
            var Validation = new Validation();

            var result = Validation.ValidateIntInput(""); 

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateIntInput_InputIsVeryLongNumber_ReturnsTrue()
        {
            var Validation = new Validation();

            var result = Validation.ValidateIntInput("9942349042945058594367257092257368572057245674385720527525624082752856248574203894586786976042500647574704236406006456456457590646089070006460000056857574757474786874598957464729586476034563409573093753056023846084730583405252056204827568375075205623846352805347258260346508740573240572405734086534057237423082350624");

            Assert.IsFalse(result);
        }



        //ValidateDateTimeInput

        [TestMethod]
        public void ValidateDateTimeInput_InputIsDateTime_ReturnsTrue()
        {

            var Validation = new Validation();

            var result = Validation.ValidateDateTimeInput("10.10.2022 12:12:12");

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void ValidateDateTimeInput_InputIsCorruptedDateTime_ReturnsFalse()
        {

            var Validation = new Validation();

            var result = Validation.ValidateDateTimeInput("AA.10.2022 12:12:12");

            Assert.IsFalse(result);

        }

        [TestMethod]
        public void ValidateDateTimeInput_InputIsDate_ReturnsFalse()
        {

            var Validation = new Validation();

            var result = Validation.ValidateDateTimeInput("12.10.2022");

            Assert.IsTrue(result);

        }
    }
}