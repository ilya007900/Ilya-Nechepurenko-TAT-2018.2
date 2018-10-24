using System;
using System.Text;

namespace DEV_3
{
    /// <summary>
    /// Class that provides methods to convert deciaml int in the new number system 
    /// </summary>
    class DecimalIntConverter
    {
        /// <summary>
        /// Converts deciaml int in the new number system 
        /// </summary>
        /// <param name="number">number for converting</param>
        /// <param name="system">new number system</param>
        /// <returns>number as string in the new number system</returns>
        public string ConvertToNewSystem(int number, int system)
        {
            if (system < 2 || system > 20) 
            {
                throw new Exception("Error number of system");
            }

            bool isPositive = number >= 0;
            if (!isPositive)
            {
                number = Math.Abs(number);
            }
            string symbolsOfSystems = "0123456789ABCDEFGHIJ";
            StringBuilder reverseResult = new StringBuilder();

            do
            {
                reverseResult.Append(symbolsOfSystems[number % system]);
                number /= system;
            }
            while (number != 0);

            if (!isPositive)
            {
                reverseResult.Append('-');
            }

            StringBuilder result = new StringBuilder(reverseResult.Length);

            for (int i = reverseResult.Length - 1; i >= 0; i--) 
            {
                result.Append(reverseResult[i]);
            }

            return result.ToString();
        }
    }
}
