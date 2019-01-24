using System;

namespace LW_Convertors
{
    /// <summary>
    /// Converts mass measures
    /// </summary>
    class MassConvertor : Convertor
    {
        private const double PoundToGramKoef = 453.59237;
        private const double PoodToGramKoef = 16380.7;

        private MassConvertor() { }

        /// <summary>
        /// Converts value to system si
        /// </summary>
        /// <param name="value">Value to converting</param>
        /// <param name="measure">measure of value</param>
        /// <returns>value in grams</returns>
        protected override double ToSystemSi(double value, string measure)
        {
            switch (measure)
            {
                case "g":
                    return value;
                case "fn":
                    return value * PoundToGramKoef;
                case "pd":
                    return value * PoodToGramKoef;
                default:
                    throw new Exception("Error in Mass convertor");
            }
        }

        /// <summary>
        /// Converts value in one measure to other measure
        /// </summary>
        /// <param name="value">Value to converting</param>
        /// <param name="ConvertFrom">base measure</param>
        /// <param name="ConvertTo">new measure</param>
        /// <returns>Value in new measure</returns>
        public override double Convert(double value, string ConvertFrom, string ConvertTo)
        {
            double ValueInSystemSi = ToSystemSi(value, ConvertFrom);

            if (ValueInSystemSi < 0)
            {
                throw new Exception("Inccorect mass");
            }

            switch (ConvertTo)
            {
                case "g":
                    return ValueInSystemSi;
                case "fn":
                    return ValueInSystemSi / PoundToGramKoef;
                case "pd":
                    return ValueInSystemSi / PoodToGramKoef;
                default:
                    throw new Exception("Error in Mass convertor");
            }
        }

        /// <summary>
        /// Realizes pattern singelton
        /// </summary>
        /// <returns>New Mass Convertor</returns>
        public static Convertor GetConvertor()
        {
            if (State == null)
            {
                State = new MassConvertor();
            }
            return State;
        }
    }
}
