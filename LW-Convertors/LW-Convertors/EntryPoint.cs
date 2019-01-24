using System;

namespace LW_Convertors
{
    /// <summary>
    /// Entry point of programm
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Gets parameters from command line
        /// </summary>
        /// <param name="args">args[0] is value, args[1] is base measure, args[2] is new measure</param>
        static void Main(string[] args)
        {
            try
            {
                if (args.Length != 3)
                {
                    throw new Exception("Incorrect number of parameters");
                }

                if (!double.TryParse(args[0], out double value))
                {
                    throw new Exception("Incorrect value for convert");
                }

                string convertFrom = args[1].ToLower();
                string convertTo = args[2].ToLower();

                ConvertorsFactory factory = new ConvertorsFactory();
                Convertor convertor = factory.GetConvertor(convertFrom, convertTo);
                Console.WriteLine(convertor.Convert(value, convertFrom, convertTo));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
