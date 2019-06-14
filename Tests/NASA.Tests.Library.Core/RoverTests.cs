using NASA.Library.Core;
using NUnit.Framework;

namespace NASA.Tests.Library.Core
{
    public class RoverTests
    {
        private Plateau _plateau;

        [SetUp]
        public void Setup()
        {
            _plateau = new Plateau(5,5);
        }

        [Test]
        public void SetInitializePosition_Throws_Error_If_Initialized_Rover_Position_Is_Out_Of_Plateau()
        {
            //Arrange
            var position = new Position() {Direction = Directions.E, XCoordinate = 10, YCoordinate = 10};

            //Act
            var rover = new Rover(_plateau);
            var ex = Assert.Throws<NasaError>(() => rover.SetInitializePosition(position));

            //Assert
            Assert.That(ex.CustomErrorCode, Is.EqualTo(RoverErrors.OutOfArea));

        }

        [Test]
        public void North_Positioned_Rover_Turned_West_If_L_Command_Received()
        {
            //Arrange
            var position = new Position() { Direction = Directions.N, XCoordinate = 2, YCoordinate = 2 };
            var rover = new Rover(_plateau);
            rover.SetInitializePosition(position);

            //Act
            rover.RunCommand('L');
            var currentRoverPosition = rover.GetPosition();

            //Assert
            Assert.AreEqual(Directions.W, currentRoverPosition.Direction);
        }

        [Test]
        public void North_Positioned_Rover_Turned_East_If_R_Command_Received()
        {
            //Arrange
            var position = new Position() { Direction = Directions.N, XCoordinate = 2, YCoordinate = 2 };
            var rover = new Rover(_plateau);
            rover.SetInitializePosition(position);

            //Act
            rover.RunCommand('R');
            var currentRoverPosition = rover.GetPosition();

            //Assert
            Assert.AreEqual(Directions.E, currentRoverPosition.Direction);
        }

        [Test]
        public void North_Positioned_Rover_Y_Coordinate_Increase_If_M_Command_Received()
        {
            //Arrange
            var position = new Position() { Direction = Directions.N, XCoordinate = 2, YCoordinate = 2 };
            var rover = new Rover(_plateau);
            rover.SetInitializePosition(position);

            //Act
            rover.RunCommand('M');
            var currentRoverPosition = rover.GetPosition();

            //Assert
            Assert.AreEqual(3, currentRoverPosition.YCoordinate);
        }

        [Test]
        public void South_Positioned_Rover_Y_Coordinate_Decrease_If_M_Command_Received()
        {
            //Arrange
            var position = new Position() { Direction = Directions.S, XCoordinate = 2, YCoordinate = 2 };
            var rover = new Rover(_plateau);
            rover.SetInitializePosition(position);

            //Act
            rover.RunCommand('M');
            var currentRoverPosition = rover.GetPosition();

            //Assert
            Assert.AreEqual(1, currentRoverPosition.YCoordinate);
        }

        [Test]
        public void East_Positioned_Rover_X_Coordinate_Increase_If_M_Command_Received()
        {
            //Arrange
            var position = new Position() { Direction = Directions.E, XCoordinate = 2, YCoordinate = 2 };
            var rover = new Rover(_plateau);
            rover.SetInitializePosition(position);

            //Act
            rover.RunCommand('M');
            var currentRoverPosition = rover.GetPosition();

            //Assert
            Assert.AreEqual(3, currentRoverPosition.XCoordinate);
        }

        [Test]
        public void West_Positioned_Rover_X_Coordinate_Decrease_If_M_Command_Received()
        {
            //Arrange
            var position = new Position() { Direction = Directions.W, XCoordinate = 2, YCoordinate = 2 };
            var rover = new Rover(_plateau);
            rover.SetInitializePosition(position);

            //Act
            rover.RunCommand('M');
            var currentRoverPosition = rover.GetPosition();

            //Assert
            Assert.AreEqual(1, currentRoverPosition.XCoordinate);
        }

        [Test]
        public void RunCommand_Throws_Error_If_Calculated_Rover_Position_Is_Out_Of_Plateau()
        {
            //Arrange
            var position = new Position() { Direction = Directions.E, XCoordinate = 5, YCoordinate = 5 };
            var rover = new Rover(_plateau);
            rover.SetInitializePosition(position);

            //Act
            var ex = Assert.Throws<NasaError>(() => rover.RunCommand('M'));

            //Assert
            Assert.That(ex.CustomErrorCode, Is.EqualTo(RoverErrors.OutOfArea));

        }

        [Test]
        public void RunCommand_Throws_Error_If_Command_Character_Is_Undefined()
        {
            //Arrange
            var position = new Position() { Direction = Directions.E, XCoordinate = 5, YCoordinate = 5 };
            var rover = new Rover(_plateau);
            rover.SetInitializePosition(position);

            //Act
            var ex = Assert.Throws<NasaError>(() => rover.RunCommand('K'));

            //Assert
            Assert.That(ex.CustomErrorCode, Is.EqualTo(UserInteractionErrors.Parse));

        }
    }
}