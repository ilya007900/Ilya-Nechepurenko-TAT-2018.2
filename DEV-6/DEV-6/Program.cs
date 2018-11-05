using System;

namespace DEV_6
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                throw new ArgumentException("Incorrect parameters");
            }
        }
    }
}
