using System;

namespace DEV_5
{
    /// <summary>
    /// Entry point of programm
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Initializes collection
        /// </summary>
        static void Main()
        {
            try
            {
                Collection collection = new Collection();
                CommandFactory commandFactory = new CommandFactory();

                while (Console.ReadLine().ToLower() != "n")
                {
                    ICommand command = new AddInCollectionCommand(collection, CarGetter.GetCarFromConsole());
                    command.Execute();
                    Console.WriteLine("Continue adding? (y/n)");
                }

                while (true)
                {
                    Console.WriteLine("Input command");
                    ICommand command = commandFactory.GetCommand(Console.ReadLine(), collection);

                    if (command == null)
                    {
                        break;
                    }

                    command.Execute();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
