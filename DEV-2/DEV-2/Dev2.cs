using System;

namespace DEV_2
{
    class Dev2
    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args">Arguments from command line</param>
        static void Main(string[] args)
        {
            try
            {
                if (args.Length < 1)
                {
                    Console.WriteLine("Not enough params");
                    return;
                }

                if (args.Length > 1)
                {
                    Console.WriteLine("Too many params");
                    return;
                }

                StringTranslitor translitor = new StringTranslitor();
                Console.WriteLine(translitor.TranslitString(args[0]));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
