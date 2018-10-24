using System.Collections.Generic;

namespace DEV_1
{
    /// <summary>
    /// Class that works with unique characters in string
    /// </summary>
    class MaxUniqueSequnceFinder
    {
        /// <summary>
        /// This method counts number of unique consecutive characters in string 
        /// </summary>
        /// <param name="str">string to count</param>
        /// <returns>Count of max sequence of unique characters</returns>
        public int MaxSequenceOfUniqueSymbols(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            if (str.Length == 1)
            {
                return 1;
            }

            List<char> symbols = new List<char>(str.Length);

            int maxSession = 0;

            for (int i = 0; i < str.Length; i++)
            {
                for (int j = i; j < str.Length; j++)
                {
                    if (symbols.Contains(str[j]))
                    {
                        if (symbols.Count > maxSession)
                        {
                            maxSession = symbols.Count;
                        }
                        symbols.Clear();
                        break;
                    }
                    else
                    {
                        symbols.Add(str[j]);
                    }
                }
            }
            return maxSession;
        }
    }
}
