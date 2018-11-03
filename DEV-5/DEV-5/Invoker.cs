using System;
using System.Collections.Generic;
using System.Text;

namespace DEV_5
{
    class Invoker
    {
        public ICommand Command { get; private set; }

        public Invoker() { }

        public void SetCommand(ICommand command)
        {
            Command = command;
        }

        public void AvgPrice()
        {
            Command.Execute();
        }

        public void AvgTypePrice()
        {
            Command.Execute();
        }

        public void CountAll()
        {
            Command.Execute();
        }

        public void CountTypes()
        {
            Command.Execute();
        }
    }
}
