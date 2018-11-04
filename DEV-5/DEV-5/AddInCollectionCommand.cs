
namespace DEV_5
{
    class AddInCollectionCommand : ICommand
    {
        private Collection Reciver { get; set; }
        private Car Car { get; set; }

        public AddInCollectionCommand(Collection reciver, Car car)
        {
            Reciver = reciver;
            Car = car;
        }

        public void Execute()
        {
            Reciver.AddInCollection(Car);
        }
    }
}
