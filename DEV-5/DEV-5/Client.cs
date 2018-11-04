using System;
using System.Text;

namespace DEV_5
{
    class Client
    {
        public void Run(Collection collection, CollectionManipulator manipulator)
        {
            CommandGetter commandGetter = new CommandGetter();
            CarInputer carInputer = new CarInputer();

            do
            {
                manipulator.SetCommand(new AddInCollectionCommand(collection, carInputer.GetCarFromConsole()));
                manipulator.ExecuteCommand();
                Console.WriteLine("Stop? y/n");
            } while (commandGetter.GetCommand() != "y");

            while (true)
            {
                string command = commandGetter.GetCommand();

                if (command == "avg price")
                {
                    manipulator.SetCommand(new AveragePriceCommand(collection));
                }
                else if (command.StartsWith("avg price ") && command.Length > 10)
                {
                    StringBuilder brand = new StringBuilder(command, 10, command.Length - 10, command.Length);
                    manipulator.SetCommand(new AveragePriceTypeCommand(collection, brand.ToString()));
                }
                else if (command == "count all")
                {
                    manipulator.SetCommand(new CountAllCommand(collection));
                }
                else if (command == "count types")
                {
                    manipulator.SetCommand(new CountTypesCommand(collection));
                }
                else if (command == "exit")
                {
                    return;
                }
                else
                {
                    continue;
                }
                manipulator.ExecuteCommand();
            }
        }
    }
}
