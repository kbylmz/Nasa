using System;
using System.Collections.Generic;
using System.Text;
using NASA.Library.Core.Interfaces;

namespace NASA.Library.Core
{
    public class Rover : IRover
    {
        private readonly IPlateau _plateau;
        private Position _position;
        private readonly Dictionary<char, Action> _actions;

        public Rover(IPlateau plateau)
        {
            _plateau = plateau;

            _actions = new Dictionary<char, Action>
            {
                {'L', TurnLeft}, {'R', TurnRight}, {'M', MoveForward}
            };
        }

        /// <summary>
        /// Set rover's initial position
        /// </summary>
        /// <param name="position">rover's position</param>
        public void SetInitializePosition(Position position)
        {
            if (_plateau.IsOutOfArea(position.XCoordinate, position.YCoordinate))
                throw new NasaError { CustomErrorCode = RoverErrors.OutOfArea };

            _position = position;
        }

        /// <summary>
        /// Returns rover's position
        /// </summary>
        /// <returns>rover's position</returns>
        public Position GetPosition()
        {
            return _position;
        }

        /// <summary>
        /// Rover moves according to the sent character
        /// L turns left
        /// R turns right
        /// M forward
        /// </summary>
        /// <param name="command"></param>
        public void RunCommand(char command)
        {
            if (!_actions.ContainsKey(command))
                throw new NasaError { CustomErrorCode = UserInteractionErrors.Parse };

            _actions[command].Invoke();
        }

        /// <summary>
        /// Changes direction by turning left
        /// </summary>
        private void TurnLeft()
        {
            _position.Direction = _position.Direction != Directions.E ? _position.Direction - 1 : Directions.N;
        }

        /// <summary>
        /// Changes direction by turning right
        /// </summary>
        private void TurnRight()
        {
            _position.Direction = _position.Direction != Directions.N ? _position.Direction + 1 : Directions.E;
        }

        /// <summary>
        /// checks if it can go
        /// if it can go, go forward
        /// </summary>
        private void MoveForward()
        {
            var calculatedX = _position.XCoordinate;
            var calculatedY = _position.YCoordinate;

            switch (_position.Direction)
            {
                case Directions.E:
                    calculatedX++;
                    break;
                case Directions.S:
                    calculatedY--;
                    break;
                case Directions.W:
                    calculatedX--;
                    break;
                case Directions.N:
                    calculatedY++;
                    break;
            }

            if (_plateau.IsOutOfArea(calculatedX, calculatedY))
                throw new NasaError { CustomErrorCode = RoverErrors.OutOfArea };


            _position.XCoordinate = calculatedX;
            _position.YCoordinate = calculatedY;

        }
    }
}
