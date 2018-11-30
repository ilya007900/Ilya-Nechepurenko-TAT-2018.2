using System;

namespace DEV_5
{
    /// <summary>
    /// Command that outputs average price to console
    /// </summary>
    class AveragePriceCommand : ICommand
    {
        private Collection Reciver { get; set; }

        public AveragePriceCommand(Collection reciver)
        {
            Reciver = reciver;
        }

        /// <summary>
        /// Executes command that outputs average price to console
        /// </summary>
        public void Execute()
        {
            Console.WriteLine(Reciver.AveragePrice());
        }
    }
}
