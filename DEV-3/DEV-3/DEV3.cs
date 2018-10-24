using System;

namespace DEV_3
{
    class DEV3
    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args">arguments from command line</param>
        static void Main(string[] args)
        {
            try
            {
                if (args.Length < 2)
                {
                    Console.WriteLine("Not enough parameters");
                    return;
                }
                if (args.Length > 2)
                {
                    Console.WriteLine("Too many parameters");
                    return;
                }
                if (!(int.TryParse(args[0], out int number)))
                {
                    Console.WriteLine("First parameter is not integer or number");
                    return;
                }
                if (!(int.TryParse(args[1], out int system)))
                {
                    Console.WriteLine("Second parameter is not integer or number");
                    return;
                }
                DecimalIntConverter intConverter = new DecimalIntConverter();
                Console.WriteLine(intConverter.ConvertToNewSystem(number, system));
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
