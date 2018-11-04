using System;

namespace DEV_5
{
    /// <summary>
    /// Provides methods to manipulate with collection
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Initializes collection, collection manipulator and client classes.
        /// </summary>
        static void Main()
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
