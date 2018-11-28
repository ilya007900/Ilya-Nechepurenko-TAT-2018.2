using System;

namespace DEV_7
{
    class CountTypesCommand : ICommand
    {
        readonly ICollectionInfo reciver;

        public CountTypesCommand(ICollectionInfo collection)
        {
            reciver = collection;
        }

        public void Execute()
        {
            Console.WriteLine(reciver.CountTypes());
        }
    }
}
