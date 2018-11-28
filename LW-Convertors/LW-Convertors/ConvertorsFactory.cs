using System;
using System.Collections.Generic;

namespace LW_Convertors
{
    /// <summary>
    /// Factory of convertors
    /// </summary>
    class ConvertorsFactory
    {
        static readonly List<List<string>> Measures = new List<List<string>>
        {
            new List<string>{ "g", "fn", "pd" },
            new List<string>{ "m", "feet", "miles" },
            new List<string>{ "m_3", "gal", "pints" },
            new List<string>{ "c", "k", "fn" }
        };

        /// <summary>
        /// Gets convertor
        /// </summary>
        /// <param name="ConvertFrom">base measure</param>
        /// <param name="ConvertTo">new measure</param>
        /// <returns>Convertor</returns>
        public Convertor GetConvertor(string ConvertFrom, string ConvertTo)
        {
            if (Measures[0].Contains(ConvertFrom) && Measures[0].Contains(ConvertTo))
            {
                return MassConvertor.GetConvertor();
            }
            if (Measures[1].Contains(ConvertFrom) && Measures[1].Contains(ConvertTo))
            {
                return LengthConvertor.GetConvertor();
            }
            if (Measures[2].Contains(ConvertFrom) && Measures[2].Contains(ConvertTo))
            {
                return VolumeConvertor.GetConvertor();
            }
            if (Measures[3].Contains(ConvertFrom) && Measures[3].Contains(ConvertTo))
            {
                return TemperatureConvertor.GetConvertor();
            }
            throw new Exception("Incorrect parameters in Factory");
        }
    }
}
