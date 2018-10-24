using System;

namespace DEV_1
{
    class Program
    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args">Arguments from command line</param>
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Not enough parametres");
                return;
            }

            if (args.Length > 1)
            {
                Console.WriteLine("Too many parametres");
                return;
            }

            MaxUniqueSequnceFinder finder = new MaxUniqueSequnceFinder();
            int max = finder.MaxSequenceOfUniqueSymbols(args[0]);
            Console.WriteLine(max);
        }
    }
}
