using System;
using System.Collections.Generic;

namespace DEV_7
{
    /// <summary>
    /// Creates commands
    /// </summary>
    class CommandsFactory
    {
        private static readonly string[] commands =
        {
            "average price car",
            "average price truck",
            "average price car ",
            "average price truck ",
            "count all car",
            "count all truck",
            "count types car",
            "count types truck",
            "execute"
        };

        /// <summary>
        /// Gets command
        /// </summary>
        /// <param name="commandName">Command name</param>
        /// <param name="collections">Collections to manipulation</param>
        /// <returns>Command</returns>
        public ICommand GetCommand(string commandName, List<CarCollection> collections)
        {
            string command = commandName.ToLower();

            if (command == commands[0])
            {
                return new AveragePriceCommand(collections[0]);
            }
            else if (command == commands[1])
            {
                return new AveragePriceCommand(collections[1]);
            }
            else if (command.StartsWith(commands[2]))
            {
                return new AveragePriceTypeCommand(collections[0], command.Substring(commands[2].Length));
            }
            else if (command.StartsWith(commands[3]))
            {
                return new AveragePriceTypeCommand(collections[1], command.Substring(commands[3].Length));
            }
            else if (command == commands[4])
            {
                return new CountAllCommand(collections[0]);
            }
            else if (command == commands[5])
            {
                return new CountAllCommand(collections[1]);
            }
            else if (command == commands[6])
            {
                return new CountTypesCommand(collections[0]);
            }
            else if (command == commands[7])
            {
                return new CountTypesCommand(collections[1]);
            }
            else if (command == commands[8])
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
