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
                Collection collection = new TrucksCollection();
                CommandFactory commandFactory = new CommandFactory();
                Console.WriteLine("Do you want to add cars in collection? (y/n)");

                while (Console.ReadLine().ToLower() != "n")
                {
                    ICommand command = new AddInCollectionCommand(collection, new Car("Man", "M550", 1, 80000));
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
