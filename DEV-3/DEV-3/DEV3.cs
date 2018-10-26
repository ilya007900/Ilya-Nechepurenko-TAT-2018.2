using System;

namespace DEV_3
{
    /// <summary>
    /// This programm gets two parameters from the command line 
    /// and converts first parameter to new base from second parameter
    /// </summary>
    class DEV3
    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args">arguments of command line</param>
        static void Main(string[] args)
        {
            try
            {
                if (args.Length < 2)
                {
                    throw new Exception("Not enough parameters");
                }
                if (args.Length > 2)
                {
                    throw new Exception("Too many parameters");
                }
                if (!(int.TryParse(args[0], out int value)))
                {
                    throw new Exception("First parameter is not integer or number");
                }
                if (!(int.TryParse(args[1], out int newBase)))
                {
                    throw new Exception("Second parameter is not integer or number");
                }
                IntToNewBaseConverter converter= new IntToNewBaseConverter(value);
                Console.WriteLine(converter.ConvertToNewSystem(newBase));
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
