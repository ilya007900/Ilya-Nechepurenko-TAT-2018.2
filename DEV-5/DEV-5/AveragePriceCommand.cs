using System;

namespace DEV_5
{
    /// <summary>
    /// Command that output average price to console
    /// </summary>
    class AveragePriceCommand : ICommand
    {
        private Collection Reciver { get; set; }

        public AveragePriceCommand(Collection reciver)
        {
            Reciver = reciver;
        }

        /// <summary>
        /// Execute command that output average price to console
        /// </summary>
        public void Execute()
        {
            Console.WriteLine(Reciver.AveragePrice());
        }
    }
}
