using System;

namespace DEV_5
{
    class AveragePriceCommand : ICommand
    {
        private Collection Reciver { get; set; }

        public AveragePriceCommand(Collection reciver)
        {
            Reciver = reciver;
        }

        public void Execute()
        {
            Console.WriteLine(Reciver.AveragePrice());
        }
    }
}
