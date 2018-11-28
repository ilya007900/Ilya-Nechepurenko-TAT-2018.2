using System;

namespace DEV_7
{
    class AveragePriceCommand : ICommand
    {
        readonly ICollectionInfo reciver;

        public AveragePriceCommand(ICollectionInfo collection)
        {
            reciver = collection;
        }

        public void Execute()
        {
            Console.WriteLine(reciver.GetAveragePrice());
        }
    }
}
