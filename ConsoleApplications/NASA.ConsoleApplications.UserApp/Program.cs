using System;
using NASA.Library.Core;
using NASA.Library.Core.Constants;
using NASA.Library.Core.Interfaces;
using Serilog;
using Serilog.Events;

namespace NASA.ConsoleApplications.UserApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.Console().MinimumLevel.Verbose().CreateLogger();
            try
            {
                Console.Write("Please write the size of the plateau: ");
                Console.ReadLine().ParseUserEnteredInformation(out int plateauXValue, out int plateauYValue);

                IPlateau plateau = new Plateau(plateauXValue, plateauYValue);

                string again;
                do
                {
                    #region | ROVER PROCESS | 
                    try
                    {
                       
                        Console.Write("Please set new rover's position(X Y Direction): ");
                        Console.ReadLine().ParseUserEnteredInformation(out int roverXValue, out int roverYValue, out Directions direction);

                        IRover rover = new Rover(plateau);
                        rover.SetInitializePosition(new Position() { Direction = direction, XCoordinate = roverXValue, YCoordinate = roverYValue });

                        Console.Write("Please set rover's instructions(LMR): ");
                        string commands = Console.ReadLine();

                        foreach (var command in commands.ToCharArray())
                        {
                            rover.RunCommand(command);
                        }

                        Console.WriteLine(rover.GetPosition().ToString());
                       

                    }
                    catch (NasaError ex)
                    {
                        Log.Error(NasaLogKeys.LogLevelMap[ex.CustomErrorCode]);
                    }
                    #endregion

                    Console.Write("Do you want to continue(Y/N)?: ");
                    again = Console.ReadLine();

                } while (again.ToLower() == "y");

            }
            catch (NasaError ex)
            {
                Log.Error(NasaLogKeys.LogLevelMap[ex.CustomErrorCode]);
            }
        }
    }
}