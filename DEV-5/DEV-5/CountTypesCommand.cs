using System;

namespace DEV_5
{
    /// <summary>
    /// Command that output count of brands to console
    /// </summary>
    class CountTypesCommand : ICommand
    {
        private Collection Reciver { get; set; }

        public CountTypesCommand(Collection reciver)
        {
            Reciver = reciver;
        }

        /// <summary>
        /// Execute command that output count of brands to console
        /// </summary>
        public void Execute()
        {
            Console.WriteLine(Reciver.CountTypes());
        }
    }
}
