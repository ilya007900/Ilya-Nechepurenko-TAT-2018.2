
namespace DEV_5
{
    /// <summary>
    /// Provides abstract method for manipulating with collection
    /// </summary>
    class CollectionManipulator
    {
        private ICommand Command { get; set; }

        public CollectionManipulator() { }

        /// <summary>
        /// Sets command for manipulating with collection
        /// </summary>
        /// <param name="command">command for manipulating with collection</param>
        public void SetCommand(ICommand command)
        {
            Command = command;
        }

        /// <summary>
        /// Executes command
        /// </summary>
        public void ExecuteCommand()
        {
            Command.Execute();
        }
    }
}
