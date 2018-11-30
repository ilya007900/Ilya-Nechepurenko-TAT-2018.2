using System;

namespace DEV_7
{
    class AveragePriceTypeCommand : ICommand
    {
        readonly CarCollection reciver;
        readonly string brand;

        public AveragePriceTypeCommand(CarCollection collection, string brand)
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
