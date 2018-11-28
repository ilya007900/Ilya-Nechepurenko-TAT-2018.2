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
                List<ICommand> commands = new List<ICommand>();
                ICollectionInfo collection = new CarCollection();
                CommandsFactory commandsFactory = new CommandsFactory();
                do
                {
                    Console.WriteLine("Input command");
                    ICommand command = commandsFactory.GetCommand(Console.ReadLine(), collection);
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