using System;
using System.Collections.Generic;
using System.Text;
using NASA.Library.Core.Interfaces;

namespace NASA.Library.Core
{
    /// <summary>
    /// This plateau has lower-left coordinates and upper-right coordinates 
    /// </summary>
    public class Plateau : IPlateau
    {
        private readonly int _maxXCoordinateValue;
        private readonly int _maxYCoordinateValue;

        public Plateau(int maxXCoordinateValue, int maxYCoordinateValue)
        {
            _maxXCoordinateValue = maxXCoordinateValue;
            _maxYCoordinateValue = maxYCoordinateValue;
        }

        /// <summary>
        /// Check if values are between 0 and maximum coordinate values.
        /// </summary>
        /// <param name="xCoordinate">X coordinate value</param>
        /// <param name="yCoordinate">Y coordinate value</param>
        /// <returns>true if the values are not in area; otherwise,false.</returns>
        public bool IsOutOfArea(int xCoordinate, int yCoordinate)
        {
            if (xCoordinate < 0 || yCoordinate < 0)
                return true;

        
            if (xCoordinate > _maxXCoordinateValue || yCoordinate > _maxYCoordinateValue)
                return true;


            return false;

        }
    }
}
