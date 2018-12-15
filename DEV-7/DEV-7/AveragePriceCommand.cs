using System;

namespace DEV_7
{
    /// <summary>
    /// Command that outputs average price to console
    /// </summary>
    class AveragePriceCommand : ICommand
    {
        readonly CarCollection reciver;

        public AveragePriceCommand(CarCollection collection)
        {
            reciver = collection;
        }

        /// <summary>
        /// Executes command that outputs average price to console
        /// </summary>
        public void Execute()
        {
            Console.WriteLine(reciver.GetAveragePrice());
        }
    }
}
