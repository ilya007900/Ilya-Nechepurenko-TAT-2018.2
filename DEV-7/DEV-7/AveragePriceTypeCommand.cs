using System;

namespace DEV_7
{
    /// <summary>
    /// Command that outputs average price of brand to console
    /// </summary>
    class AveragePriceTypeCommand : ICommand
    {
        readonly CarCollection reciver;
        readonly string brand;

        public AveragePriceTypeCommand(CarCollection collection, string brand)
        {
            this.brand = brand;
            reciver = collection;
        }

        /// <summary>
        /// Executes command that outputs average price of brand to console
        /// </summary>
        public void Execute()
        {
            Console.WriteLine(reciver.GetAverageTypePrice(brand));
        }
    }
}
