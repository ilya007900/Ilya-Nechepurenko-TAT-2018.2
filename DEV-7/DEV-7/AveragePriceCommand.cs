using System;

namespace DEV_7
{
    class AveragePriceCommand : ICommand
    {
        readonly CarCollection reciver;

        public AveragePriceCommand(CarCollection collection)
        {
            reciver = collection;
        }

        public void Execute()
        {
            Console.WriteLine(reciver.GetAveragePrice());
        }
    }
}
