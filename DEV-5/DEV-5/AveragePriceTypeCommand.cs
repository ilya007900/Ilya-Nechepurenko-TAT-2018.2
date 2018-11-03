
namespace DEV_5
{
    class AveragePriceTypeCommand : ICommand
    {
        private Collection Reciver { get; set; }

        public AveragePriceTypeCommand(Collection reciver)
        {
            Reciver = reciver;
        }

        public void Execute()
        {
            Reciver.AvaragePrice();
        }
    }
}
