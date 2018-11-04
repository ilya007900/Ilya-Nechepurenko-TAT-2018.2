using System;

namespace DEV_5
{
    class CountTypesCommand : ICommand
    {
        private Collection Reciver { get; set; }

        public CountTypesCommand(Collection reciver)
        {
            Reciver = reciver;
        }

        public void Execute()
        {
            Console.WriteLine(Reciver.CountTypes());
        }
    }
}
