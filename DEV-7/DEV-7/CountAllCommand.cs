using System;

namespace DEV_7
{
    class CountAllCommand : ICommand
    {
        readonly CarCollection reciver;

        public CountAllCommand(CarCollection collection)
        {
            reciver = collection;
        }

        public void Execute()
        {
            Console.WriteLine(reciver.CountAll());
        }
    }
}
