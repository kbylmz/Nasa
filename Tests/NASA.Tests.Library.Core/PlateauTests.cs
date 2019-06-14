using NASA.Library.Core;
using NUnit.Framework;

namespace NASA.Tests.Library.Core
{
    public class PlateauTests
    {
        private Plateau _plateau;

        [SetUp]
        public void Setup()
        {
            _plateau = new Plateau(5,5);
        }

        [Test]
        public void IsOutOfArea_Returns_True_If_X_Position_Is_Out_Of_Area()
        {
            Assert.True(_plateau.IsOutOfArea(6,3));
        }

        [Test]
        public void IsOutOfArea_Returns_True_If_Y_Position_Is_Out_Of_Area()
        {
            Assert.True(_plateau.IsOutOfArea(3, 6));
        }

        [Test]
        public void IsOutOfArea_Returns_False_If_Position_Is_In_Area()
        {
            Assert.False(_plateau.IsOutOfArea(3, 3));
        }

        [Test]
        public void IsOutOfArea_Returns_True_If_Y_Position_Smaller_Than_0()
        {
            Assert.True(_plateau.IsOutOfArea(3, -1));
        }
    }
}