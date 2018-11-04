
namespace DEV_5
{
    /// <summary>
    /// Command that adds car in collection
    /// </summary>
    class AddInCollectionCommand : ICommand
    {
        private Collection Reciver { get; set; }
        private Car Car { get; set; }

        public AddInCollectionCommand(Collection reciver, Car car)
        {
            Reciver = reciver;
            Car = car;
        }

        /// <summary>
        /// Execute command that adds car in collection
        /// </summary>
        public void Execute()
        {
            Reciver.AddInCollection(Car);
        }
    }
}
