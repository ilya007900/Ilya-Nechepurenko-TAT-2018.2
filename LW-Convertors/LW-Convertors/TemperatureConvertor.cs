using System;

namespace LW_Convertors
{
    /// <summary>
    /// Converts temperature measures
    /// </summary>
    class TemperatureConvertor : Convertor
    {
        /// <summary>
        /// Converts value to system si
        /// </summary>
        /// <param name="value">Value to converting</param>
        /// <param name="measure">measure of value</param>
        /// <returns>value in celsius</returns>
        protected override double ToSystemSi(double value, string measure)
        {
            switch (measure)
            {
                case "c":
                    return value;
                case "k":
                    return value - 273.15;
                case "fn":
                    return (value - 32) * 5 / 9;
                default:
                    throw new Exception("Error in temperature convertor");
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

            if (ValueInSystemSi < -273.15 || ValueInSystemSi > 6000000)
            {
                throw new Exception("Incorrect temperature");
            }

            switch (ConvertTo)
            {
                case "c":
                    return ValueInSystemSi;
                case "k":
                    return ValueInSystemSi + 273.15;
                case "fn":
                    return (ValueInSystemSi * 9 / 5) + 32;
                default:
                    throw new Exception("Error in temperature convertor");
            }
        }

        /// <summary>
        /// Realizes pattern singelton
        /// </summary>
        /// <returns>New Temperature Convertor</returns>
        public static Convertor GetConvertor()
        {
            if (State == null)
            {
                State = new TemperatureConvertor();
            }
            return State;
        }
    }
}
