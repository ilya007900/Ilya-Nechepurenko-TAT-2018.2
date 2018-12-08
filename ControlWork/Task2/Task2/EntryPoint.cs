using System;

namespace Task2
{
    /// <summary>
    /// Gets IPs from string
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Gets string to handle from cmd
        /// </summary>
        /// <param name="args">args[0] - string to handle</param>
        static void Main(string[] args)
        {
            try
            {
                if (args.Length != 1)
                {
                    throw new ArgumentException("Incorrect parameters");
                }
                IPGetter iPGetter = new IPGetter(args[0]);

                foreach(string ip in iPGetter.GetIPs())
                {
                    Console.WriteLine(ip);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
