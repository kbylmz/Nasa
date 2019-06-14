using System;
using System.Collections.Generic;
using System.Text;

namespace NASA.Library.Core.Constants
{
    public class NasaLogKeys
    {
        public static readonly Dictionary<Enum, string> LogLevelMap = new Dictionary<Enum, string>
        {
            { RoverErrors.OutOfArea, "outofarea" },
            { UserInteractionErrors.Parse, "Input is wrong format!" }
        };
    }
}
