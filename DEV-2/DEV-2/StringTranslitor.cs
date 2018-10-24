using System;
using System.Collections.Generic;
using System.Text;

namespace DEV_2
{
    /// <summary>
    /// Class that translits string. Works with russian ang english languages
    /// </summary>
    class StringTranslitor
    {
        /// <summary>
        /// enum with codes of Russian letters 
        /// </summary>
        private enum RussianLettersCodes { firstLetter = 1072, lastLetter = 1103, oneMore = 1105 }

        /// <summary>
        /// enum with codes of English letters
        /// </summary>
        private enum EnglishLettersCodes { firstLetter = 97, lastLetter = 122 }

        /// <summary>
        /// Dictionary for translit strings
        /// </summary>
        private readonly Dictionary<string, string> translitor = new Dictionary<string, string>
        {
            ["щ"] = "sch",
            ["ш"] = "sh",
            ["ё"] = "yo",
            ["ю"] = "yu",
            ["я"] = "ya",
            ["х"] = "kh",
            ["ц"] = "ts",
            ["ч"] = "ch",
            ["ж"] = "zh",
            ["а"] = "a",
            ["б"] = "b",
            ["в"] = "v",
            ["г"] = "g",
            ["д"] = "d",
            ["е"] = "e",
            ["з"] = "z",
            ["и"] = "i",
            ["й"] = "y",
            ["к"] = "k",
            ["л"] = "l",
            ["м"] = "m",
            ["н"] = "n",
            ["о"] = "o",
            ["п"] = "p",
            ["р"] = "r",
            ["с"] = "s",
            ["т"] = "t",
            ["у"] = "u",
            ["ф"] = "f",
            ["ы"] = "y",
            ["э"] = "e",
            ["ъ"] = string.Empty,
            ["ь"] = string.Empty
        };
    
        /// <summary>
        /// Translit string if string is in Russian or English
        /// </summary>
        /// <param name="stringForTranslit">string to translit</param>
        /// <returns>translited string</returns>
        public string TranslitString(string stringForTranslit)
        {
            if (string.IsNullOrEmpty(stringForTranslit))
            {
                throw new Exception("String is Empty");
            }

            if (IsStringInEnglish(stringForTranslit))
            {
                string translitedStringInLowerCase = stringForTranslit.ToLower();
                StringBuilder translitedString = new StringBuilder(translitedStringInLowerCase);

                foreach (string key in translitor.Keys)
                {
                    if (!string.IsNullOrEmpty(translitor[key]))
                    {
                        translitedString.Replace(translitor[key], key);
                    }
                }
                return translitedString.ToString();
            }
            else if (IsStringInRussian(stringForTranslit))
            {
                string translitedStringInLowerCase = stringForTranslit.ToLower();
                StringBuilder translitedString = new StringBuilder(translitedStringInLowerCase);
                foreach (string key in translitor.Keys)
                {
                    translitedString.Replace(key, translitor[key]);
                }
                return translitedString.ToString();
            }
            else
            {
                throw new Exception("String is not in Russian or English");
            }
        }

        /// <summary>
        /// Checks is string in English
        /// </summary>
        /// <param name="stringForCheck">string for check</param>
        /// <returns>
        /// True if string is in English.
        /// False if string is not in English
        /// </returns>
        public bool IsStringInEnglish(string stringForCheck)
        {
            string baseStringInLowerCase = stringForCheck.ToLower();
            foreach (char symbol in baseStringInLowerCase)
            {
                int intCode = Convert.ToInt32(symbol);
                if (!((intCode >= (int)EnglishLettersCodes.firstLetter &&
                    intCode <= (int)EnglishLettersCodes.lastLetter) &&
                    char.IsLetter(symbol))) 
                {
                    return false;
                }
                break;
            }
            return true;
        }

        /// <summary>
        /// Checks is string in Russian
        /// </summary>
        /// <param name="stringForCheck">string for check</param>
        /// <returns>
        /// True if string is in Russian.
        /// False if string is not in Russian
        /// </returns>
        public bool IsStringInRussian(string stringForCheck)
        {
            string tempstr = stringForCheck.ToLower();
            foreach (char symbol in tempstr)
            {
                int intCode = Convert.ToInt32(symbol);
                if (!((intCode >= (int)RussianLettersCodes.firstLetter && 
                    intCode <= (int)RussianLettersCodes.lastLetter || 
                    intCode == (int)RussianLettersCodes.oneMore) && 
                    (char.IsLetter(symbol))))
                {
                    return false;
                }
                break;
            }
            return true;
        }
    }
}
