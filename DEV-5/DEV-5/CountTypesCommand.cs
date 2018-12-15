using System;

namespace DEV_5
{
    /// <summary>
    /// Command that outputs count of brands to console
    /// </summary>
    class CountTypesCommand : ICommand
    {
        private Collection Reciver { get; set; }

        public CountTypesCommand(Collection reciver)
        {
            Reciver = reciver;
        }

        /// <summary>
        /// Executes command that outputs count of brands to console
        /// </summary>
        public void Execute()
        {
            Console.WriteLine(Reciver.CountTypes());
        }
    }
}
