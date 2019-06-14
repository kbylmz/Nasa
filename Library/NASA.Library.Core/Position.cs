using System;
using System.Collections.Generic;
using System.Text;

namespace NASA.Library.Core
{
    public class Position
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public Directions Direction { get; set; }

        public override string ToString()
        {
            return $"{this.XCoordinate} {this.YCoordinate} {this.Direction}";
        }
    }
}
