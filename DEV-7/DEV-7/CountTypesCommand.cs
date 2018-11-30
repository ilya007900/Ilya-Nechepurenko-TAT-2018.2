using System;

namespace DEV_7
{
    class CountTypesCommand : ICommand
    {
        readonly CarCollection reciver;

        public CountTypesCommand(CarCollection collection)
        {
            reciver = collection;
        }

        public void Execute()
        {
            Console.WriteLine(reciver.CountTypes());
        }
    }
}
