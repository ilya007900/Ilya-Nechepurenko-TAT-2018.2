using System;

namespace DEV_5
{
    /// <summary>
    /// Command that outputs average price of brand to console
    /// </summary>
    class AveragePriceTypeCommand : ICommand
    {
        private Collection Reciver { get; set; }

        private string Brand { get; set; }

        public AveragePriceTypeCommand(Collection reciver, string brand)
        {
            Reciver = reciver;
            Brand = brand;
        }

        /// <summary>
        /// Executes command that outputs average price of brand to console
        /// </summary>
        public void Execute()
        {
            Console.WriteLine(Reciver.AveragePriceType(Brand));
        }
    }
}
