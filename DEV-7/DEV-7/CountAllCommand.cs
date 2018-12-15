using System;

namespace DEV_7
{
    /// <summary>
    /// Command that outputs count of cars to console
    /// </summary>
    class CountAllCommand : ICommand
    {
        readonly CarCollection reciver;

        public CountAllCommand(CarCollection collection)
        {
            reciver = collection;
        }

        /// <summary>
        /// Executes command that outputs count of cars to console
        /// </summary>
        public void Execute()
        {
            Console.WriteLine(reciver.CountAll());
        }
    }
}
