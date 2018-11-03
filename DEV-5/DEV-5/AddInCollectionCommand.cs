
namespace DEV_5
{
    class AddInCollectionCommand : ICommand
    {
        private Collection Reciver { get; set; }

        public AddInCollectionCommand(Collection reciver)
        {
            Reciver = reciver;
        }

        public void Execute()
        {
            Reciver.AddInCollection(CarInputer.Get());
        }
    }
}
