
namespace DEV_5
{
    class CollectionManipulator
    {
        private ICommand Command { get; set; }

        public CollectionManipulator() { }

        public void SetCommand(ICommand command)
        {
            Command = command;
        }

        public void ExecuteCommand()
        {
            Command.Execute();
        }
    }
}
