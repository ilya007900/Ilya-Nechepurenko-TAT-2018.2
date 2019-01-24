using System.Collections.Generic;

namespace Task1
{
    /// <summary>
    /// Provides method to count symbols in string
    /// </summary>
    static class CharsCounter
    {
        /// <summary>
        /// Counts chars in string
        /// </summary>
        /// <param name="str">String to handle</param>
        /// <returns>Symbol and quantity</returns>
        public static Dictionary<char, int> GetQuantityOfChars(string str)
        {
            Dictionary<char, int> CharsCount = new Dictionary<char, int>();
            foreach (char symbol in str)
            {
                if (CharsCount.ContainsKey(symbol))
                {
                    CharsCount[symbol]++;
                }
                else
                {
                    CharsCount.Add(symbol, 1);
                }
            }
            return CharsCount;
        }
    }
}
