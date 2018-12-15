using System;

namespace DEV_5
{
    /// <summary>
    /// Creates commands
    /// </summary>
    class CommandFactory
    {
        static readonly string[] Commands =
        {
            "average price",
            "average price ",
            "count all",
            "count types",
            "exit"
        };

        /// <summary>
        /// Gets command
        /// </summary>
        /// <param name="commandName">Command name</param>
        /// <param name="collection">Collection to manipulation</param>
        /// <returns>Command</returns>
        public ICommand GetCommand(string commandName, Collection collection)
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

            throw new Exception("Incorrect command");
        }
    }
}