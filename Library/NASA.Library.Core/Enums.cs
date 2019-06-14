using System;

namespace NASA.Library.Core
{
    public enum Directions
    {
        E = 1,
        S,
        W,
        N
    }

    public enum RoverErrors
    {
        OutOfArea = 1000
    }

    public enum UserInteractionErrors
    {
        Parse = 2000
    }
}
