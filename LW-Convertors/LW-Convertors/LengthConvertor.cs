using System;

namespace LW_Convertors
{
    /// <summary>
    /// Converts length measures
    /// </summary>
    class LengthConvertor : Convertor
    {
        private const double FootToMetre = 0.3048;
        private const double MileToMetre = 1609.34;

        private LengthConvertor() { }

        /// <summary>
        /// Converts value to system si
        /// </summary>
        /// <param name="value">Value to converting</param>
        /// <param name="measure">measure of value</param>
        /// <returns>value in meters</returns>
        protected override double ToSystemSi(double value, string measure)
        {
            switch (measure)
            {
                case "m":
                    return value;
                case "feet":
                    return value * FootToMetre;
                case "miles":
                    return value * MileToMetre;
                default:
                    throw new Exception("Error in length convertor");
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
                throw new Exception("Incoorrect length");
            }

            switch (ConvertTo)
            {
                case "m":
                    return ValueInSystemSi;
                case "feet":
                    return ValueInSystemSi / FootToMetre;
                case "miles":
                    return ValueInSystemSi / MileToMetre;
                default:
                    throw new Exception("Error in Length convertor");
            }
        }

        /// <summary>
        /// Realizes pattern singelton
        /// </summary>
        /// <returns>New Length Convertor</returns>
        public static Convertor GetConvertor()
        {
            if (State == null)
            {
                State = new LengthConvertor();
            }
            return State;
        }
    }
}
