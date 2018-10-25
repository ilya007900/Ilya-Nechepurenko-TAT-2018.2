using System;
using System.Text;

namespace DEV_3
{
    /// <summary>
    /// Class that provides methods to convert deciaml int in the new number system 
    /// </summary>
    class DecimalIntConverter
    {
        private readonly string symbolsOfSystems = "0123456789ABCDEFGHIJ";
        private readonly int minBase = 2;
        private readonly int maxBase = 20;
        /// <summary>
        /// Converts int to its equivalent string representation in a specified base 
        /// </summary>
        /// <param name="value">the int value to convert</param>
        /// <param name="toBase">the base of the return value</param>
        /// <returns>value as string in the new base</returns>
        public string ConvertToNewSystem(int value, int toBase)
        {
            if (toBase < minBase || toBase > maxBase) 
            {
                throw new Exception("Error number of system");
            }

            bool isPositive = value >= 0;
            if (!isPositive)
            {
                value = Math.Abs(value);
            }
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
