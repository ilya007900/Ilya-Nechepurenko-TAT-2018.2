using System;

namespace DEV_5
{
    /// <summary>
    /// Command that outputs count of cars to console
    /// </summary>
    class CountAllCommand : ICommand
    {
        private Collection Reciver { get; set; }

        public CountAllCommand(Collection reciver)
        {
            Reciver = reciver;
        }

        /// <summary>
        /// Executes command that outputs count of cars to console
        /// </summary>
        public void Execute()
        {
            Console.WriteLine(Reciver.CountAll());
        }
    }
}
