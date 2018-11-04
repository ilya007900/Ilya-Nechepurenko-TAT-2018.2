using System;

namespace DEV_5
{
    class CommandGetter
    {
        public string GetCommand()
        {
            Console.WriteLine("Input command");
            return Console.ReadLine();
        }
    }
}
