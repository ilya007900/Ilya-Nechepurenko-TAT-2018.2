using System;
using System.Text;

namespace DEV_3
{
    /// <summary>
    /// Class that provides methods to convert deciaml int in a specified base
    /// </summary>
    class IntToNewBaseConverter
    {
        private static string SymbolsOfNewBase { get; } = "0123456789ABCDEFGHIJ";
        public static int MinBase { get; } = 2;
        public static int MaxBase { get; } = 20;
        public int Value { get; set; }

        /// <summary>
        /// Class constructor
        /// Initialize Value to convert
        /// </summary>
        /// <param name="value">the int value to convert</param>
        public IntToNewBaseConverter(int value)
        {
            Value = value;
        }

        /// <summary>
        /// Converts int to its equivalent string representation in a specified base 
        /// </summary>
        /// <param name="toBase">the base of the return value</param>
        /// <returns>value as string in the new base</returns>
        /// <exception cref="System.ArgumentException">Twrown when param toBase more maxBase and less minBase</exception>
        public string ConvertToNewSystem(int toBase)
        {
            if (toBase < MinBase || toBase > MaxBase) 
            {
                throw new ArgumentException("Error number of new base", "toBase");
            }

            int tempValue = Math.Abs(Value);
            StringBuilder reverseValueInNewBase = new StringBuilder();

            do
            {
                reverseValueInNewBase.Append(SymbolsOfNewBase[tempValue % toBase]);
                tempValue /= toBase;
            }
            while (tempValue != 0);

            if (Value < 0)
            {
                reverseValueInNewBase.Append('-');
            }

            StringBuilder valueInNewBase = new StringBuilder(reverseValueInNewBase.Length);

            for (int i = reverseValueInNewBase.Length - 1; i >= 0; i--) 
            {
                valueInNewBase.Append(reverseValueInNewBase[i]);
            }

            return valueInNewBase.ToString();
        }
    }
}
