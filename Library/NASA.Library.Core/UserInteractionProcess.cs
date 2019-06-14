using System;
using System.Collections.Generic;
using System.Text;

namespace NASA.Library.Core
{
    public static class UserInteractionProcess
    {
        //Parses the entered string value
        public static void ParseUserEnteredInformation(this string input, out int xValue, out int yValue)
        {
            try
            {
                string[] inputs = input.Split(" ");
                if (inputs.Length != 2)
                    throw new Exception();

                xValue = Convert.ToInt32(inputs[0]);
                yValue = Convert.ToInt32(inputs[1]);
            }
            catch
            {
                throw new NasaError { CustomErrorCode = UserInteractionErrors.Parse };
            }


        }

        //Parses the entered string value
        public static void ParseUserEnteredInformation(this string input, out int xValue, out int yValue, out Directions direction)
        {
            try
            {
                string[] inputs = input.Split(" ");
                if (inputs.Length != 3)
                    throw new Exception();

                xValue = Convert.ToInt32(inputs[0]);
                yValue = Convert.ToInt32(inputs[1]);
                direction = Enum.Parse<Directions>(inputs[2].ToUpper());
            }
            catch
            {
                throw new NasaError { CustomErrorCode = UserInteractionErrors.Parse };
            }


        }
    }
}
