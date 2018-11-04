using System;

namespace DEV_5
{
    /// <summary>
    /// Provides methods that gets command
    /// </summary>
    class CommandGetter
    {
        /// <summary>
        /// Gets command from console
        /// </summary>
        /// <returns></returns>
        public string GetCommand()
        {
            Console.WriteLine("Input command");
            return Console.ReadLine();
        }
    }
}
