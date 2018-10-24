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
        /// <param name="value">value for converting</param>
        /// <param name="toBase">new number system</param>
        /// <returns>value as string in the new number system</returns>
        public string ConvertToNewSystem(int value, int toBase)
        {
            if (toBase < 2 || toBase > 20) 
            {
                throw new Exception("Error number of system");
            }

            bool isPositive = value >= 0;
            if (!isPositive)
            {
                value = Math.Abs(value);
            }
            string symbolsOfSystems = "0123456789ABCDEFGHIJ";
            StringBuilder reverseResult = new StringBuilder();

            do
            {
                reverseResult.Append(symbolsOfSystems[value % toBase]);
                value /= toBase;
            }
            while (value != 0);

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
