using System;

namespace DEV_7
{
    class CommandsFactory
    {
        private static readonly string[] Commands =
        {
            "average price",
            "average price ",
            "count all",
            "count types",
            "execute"
        };

        public ICommand GetCommand(string commandName, ICollectionInfo collection)
        {
            string command = commandName.ToLower();

            if (command == Commands[0])
            {
                return new AveragePriceCommand(collection);
            }
            else if (command.StartsWith(Commands[1]))
            {
                return new AveragePriceTypeCommand(collection, command.Substring(Commands[1].Length));
            }
            else if (command == Commands[2])
            {
                return new CountAllCommand(collection);
            }
            else if (command == Commands[3])
            {
                return new CountTypesCommand(collection);
            }
            else if (command == Commands[4])
            {
                return null;
            }
            else
            {
                throw new Exception("Incorrect command");
            }
        }
    }
}
