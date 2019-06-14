using NASA.Library.Core;
using NUnit.Framework;

namespace NASA.Tests.Library.Core
{
    public class UserInteractionProcessTests
    {

        [Test]
        public void ParseUserEnteredInformation_Throw_Exception_If_Input_Is_Null()
        {
            //Arrange
            string input = null;

            //Act
            var ex = Assert.Throws<NasaError>(() => input.ParseUserEnteredInformation(out int plateauXValue, out int plateauYValue));

            //Assert
            Assert.That(ex.CustomErrorCode, Is.EqualTo(UserInteractionErrors.Parse));
        }


        [Test]
        public void ParseUserEnteredInformation_Throw_Exception_If_Input_Has_Not_Space()
        {
            //Arrange
            string input = "55";

            //Act
            var ex = Assert.Throws<NasaError>(() => input.ParseUserEnteredInformation(out int plateauXValue, out int plateauYValue));

            //Assert
            Assert.That(ex.CustomErrorCode, Is.EqualTo(UserInteractionErrors.Parse));
        }

        [Test]
        public void ParseUserEnteredInformation_Throw_Exception_If_Input_Has_Many_Character()
        {
            //Arrange
            string input = "5 5 5 5";

            //Act
            var ex = Assert.Throws<NasaError>(() => input.ParseUserEnteredInformation(out int plateauXValue, out int plateauYValue));

            //Assert
            Assert.That(ex.CustomErrorCode, Is.EqualTo(UserInteractionErrors.Parse));
        }

        [Test]
        public void ParseUserEnteredInformation_Throw_Exception_If_Input_Has_Letter()
        {
            //Arrange
            string input = "5 M";

            //Act
            var ex = Assert.Throws<NasaError>(() => input.ParseUserEnteredInformation(out int plateauXValue, out int plateauYValue));

            //Assert
            Assert.That(ex.CustomErrorCode, Is.EqualTo(UserInteractionErrors.Parse));
        }

        [Test]
        public void ParseUserEnteredInformation_Returns_5_If_Input_Is_Correct_And_First_Value_Is_5()
        {
            //Arrange
            string input = "5 5";

            //Act
            input.ParseUserEnteredInformation(out int plateauXValue, out int plateauYValue);

            //Assert
            Assert.AreEqual(5, plateauXValue);
        }

        [Test]
        public void ParseUserEnteredInformation_With_Direction_Throw_Exception_If_Input_Has_Not_Space()
        {
            //Arrange
            string input = "55";

            //Act
            var ex = Assert.Throws<NasaError>(() => input.ParseUserEnteredInformation(out int plateauXValue, out int plateauYValue, out Directions direction));

            //Assert
            Assert.That(ex.CustomErrorCode, Is.EqualTo(UserInteractionErrors.Parse));
        }

        [Test]
        public void ParseUserEnteredInformation_With_Direction_Throw_Exception_If_Input_Coordinate_Value_Is_Letter()
        {
            //Arrange
            string input = "5 K F";

            //Act
            var ex = Assert.Throws<NasaError>(() => input.ParseUserEnteredInformation(out int plateauXValue, out int plateauYValue, out Directions direction));

            //Assert
            Assert.That(ex.CustomErrorCode, Is.EqualTo(UserInteractionErrors.Parse));
        }


        [Test]
        public void ParseUserEnteredInformation_With_Direction_Throw_Exception_If_Input_Direction_Incorrect()
        {
            //Arrange
            string input = "5 5 F";

            //Act
            var ex = Assert.Throws<NasaError>(() => input.ParseUserEnteredInformation(out int plateauXValue, out int plateauYValue, out Directions direction));

            //Assert
            Assert.That(ex.CustomErrorCode, Is.EqualTo(UserInteractionErrors.Parse));
        }

        [Test]
        public void ParseUserEnteredInformation_With_Direction_Returns_E_If_Input_Is_Correct_And_Direction_Is_E()
        {
            //Arrange
            string input = "5 5 E";

            //Act
            input.ParseUserEnteredInformation(out int plateauXValue, out int plateauYValue, out Directions direction);

            //Assert
            Assert.AreEqual(Directions.E, direction);
        }

    }
}