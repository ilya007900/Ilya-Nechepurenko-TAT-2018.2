using System;

namespace DEV_7
{
    class AveragePriceTypeCommand : ICommand
    {
        readonly ICollectionInfo reciver;
        readonly string brand;

        public AveragePriceTypeCommand(ICollectionInfo collection, string brand)
        {
            this.brand = brand;
            reciver = collection;
        }

        public void Execute()
        {
            Console.WriteLine(reciver.GetAverageTypePrice(brand));
        }
    }
}
