using System;

namespace Task1
{
    /// <summary>
    /// This program finds quantity of same symbols in string
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args">First argument is string to handle</param>
        static void Main(string[] args)
        {
            try
            {
                if (args.Length != 1)
                {
                    throw new ArgumentException("Incorrect parameters");
                }
                foreach (var keyValue in CharsCounter.GetQuantityOfChars(args[0]))
                {
                    Console.WriteLine($"{keyValue.Key} - {keyValue.Value}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
