using System;

namespace DEV_5
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            try
            {
                Collection collection = new Collection();
                CollectionManipulator manipulator = new CollectionManipulator();
                Client client = new Client();
                client.Run(collection, manipulator);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
