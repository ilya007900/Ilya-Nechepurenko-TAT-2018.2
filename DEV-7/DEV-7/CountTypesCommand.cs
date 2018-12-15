using System;

namespace DEV_7
{
    /// <summary>
    /// Command that outputs count of brands to console
    /// </summary>
    class CountTypesCommand : ICommand
    {
        readonly CarCollection reciver;

        public CountTypesCommand(CarCollection collection)
        {
            reciver = collection;
        }

        // <summary>
        /// Executes command that outputs count of brands to console
        /// </summary>
        public void Execute()
        {
            Console.WriteLine(reciver.CountTypes());
        }
    }
}
