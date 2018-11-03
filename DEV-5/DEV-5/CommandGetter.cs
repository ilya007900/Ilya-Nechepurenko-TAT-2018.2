using System;
using System.Collections.Generic;
using System.Text;

namespace DEV_5
{
    class CommandGetter
    {
        public static string Get()
        {
            Console.WriteLine("Input command");
            return Console.ReadLine();
        }
    }
}
