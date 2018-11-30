using System;
using System.Collections.Generic;

namespace DEV_7
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string passengerCarsXml = "passengerCars.xml";
                string trucksXml = "trucks.xml";
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