using NASA.Library.Core;
using NUnit.Framework;

namespace NASA.Tests.Library.Core
{
    public class PositionTests
    {

        [Test]
        public void ToString_Write_0_If_XCoordinate_Is_Null()
        {
            //Arrange
            var position = new Position() { Direction = Directions.E, YCoordinate = 2 };
            
            //Act
            var stringPosition= position.ToString();

            //Assert
            Assert.AreEqual(stringPosition, "0 2 E");
        }

        [Test]
        public void ToString_Write_0_If_YCoordinate_Is_Null()
        {
            //Arrange
            var position = new Position() { Direction = Directions.E, XCoordinate = 2 };

            //Act
            var stringPosition = position.ToString();

            //Assert
            Assert.AreEqual(stringPosition, "2 0 E");
        }

        [Test]
        public void ToString_Write_0_If_Direction_Is_Null()
        {
            //Arrange
            var position = new Position() { XCoordinate = 2, YCoordinate = 2 };

            //Act
            var stringPosition = position.ToString();

            //Assert
            Assert.AreEqual(stringPosition, "2 2 0");
        }


    }
}