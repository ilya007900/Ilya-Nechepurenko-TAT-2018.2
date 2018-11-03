using System;

namespace DEV_5
{
    delegate void MessageHandler(string message);

    class Client
    {
        static void Main(string[] args)
        {
            try
            {
                Invoker invoker = new Invoker();
                Collection collection = new Collection();
                do
                {
                    Console.WriteLine("Input command");
                    string command = Console.ReadLine();
                    switch (command)
                    {
                        case "count all":
                            invoker.SetCommand(new CountAllCommand(collection));
                            invoker.CountAll();
                            break;
                        case "avg price":
                            invoker.SetCommand(new AveragePriceCommand(collection));
                            invoker.AvgPrice();
                            break;
                        case "exit":
                            invoker.SetCommand(new ExitCommand());
                            break;
                    }
                }
                while (!(invoker.Command is ExitCommand));

                foreach (Car c in collection.Cars)
                {
                    Console.WriteLine($"{c.Brand} {c.Model}");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
