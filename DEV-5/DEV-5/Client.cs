using System;
using System.Text;

namespace DEV_5
{
    /// <summary>
    /// Class that interacts with client
    /// </summary>
    class Client
    {
        /// <summary>
        /// Runs interact with client
        /// </summary>
        /// <param name="collection">collection for manipulation</param>
        /// <param name="manipulator">methods to manipulate</param>
        public void Run(Collection collection, CollectionManipulator manipulator)
        {
            CommandGetter commandGetter = new CommandGetter();
            CarInputer carInputer = new CarInputer();

            do
            {
                manipulator.SetCommand(new AddInCollectionCommand(collection, carInputer.GetCarFromConsole()));
                manipulator.ExecuteCommand();
                Console.WriteLine("Stop input? yes/no");
            } while (commandGetter.GetCommand() != "yes");

            while (true)
            {
                string command = commandGetter.GetCommand();

                if (command == "average price")
                {
                    manipulator.SetCommand(new AveragePriceCommand(collection));
                }
                else if (command.StartsWith("average price ") && command.Length > 10)
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
