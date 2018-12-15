using System;
using System.Collections.Generic;

namespace DEV_7
{
    /// <summary>
    /// Entry point of programm
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry point of programm
        /// </summary>
        /// <param name="args">pathes to files</param>
        static void Main(string[] args)
        {
            try
            {
                if (args.Length != 2)
                {
                    throw new Exception("Incorrect parameters");
                }
                string passengerCarsXml = args[0];
                string trucksXml = args[1];
                List<ICommand> commands = new List<ICommand>();
                List<CarCollection> collections = new List<CarCollection>
                {
                    PassengerCarCollection.GetPassengerCarCollection(CarsGetter.GetCarsFromXml(passengerCarsXml)),
                    TruckCollection.GetTruckCollection(CarsGetter.GetCarsFromXml(trucksXml))
                };
                CommandsFactory commandsFactory = new CommandsFactory();

                do
                {
                    Console.WriteLine("Input command");
                    ICommand command = commandsFactory.GetCommand(Console.ReadLine(), collections);
                    if (command == null)
                    {
                        break;
                    }
                    commands.Add(command);
                } while (true);

                foreach (ICommand command in commands)
                {
                    command.Execute();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}