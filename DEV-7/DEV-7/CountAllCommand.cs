using System;

namespace DEV_7
{
    class CountAllCommand : ICommand
    {
        readonly ICollectionInfo reciver;

        public CountAllCommand(ICollectionInfo collection)
        {
            reciver = collection;
        }

        public void Execute()
        {
            Console.WriteLine(reciver.CountAll());
        }
    }
}
