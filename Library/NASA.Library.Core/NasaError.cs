using System;
using System.Collections.Generic;
using System.Text;

namespace NASA.Library.Core
{
    public class NasaError : Exception
    {
        public Enum CustomErrorCode { get; set; }
    }
}
