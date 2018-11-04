using System;

namespace DEV_5
{
    class AveragePriceTypeCommand : ICommand
    {
        private Collection Reciver { get; set; }

        private string Brand { get; set; }

        public AveragePriceTypeCommand(Collection reciver, string brand)
        {
            Reciver = reciver;
            Brand = brand;
        }

        public void Execute()
        {
            Console.WriteLine(Reciver.AveragePiceType(Brand));
        }
    }
}
