using System;

namespace LW_Convertors
{
    /// <summary>
    /// Converts volume measures
    /// </summary>
    class VolumeConvertor : Convertor
    {
        private const double GallonToM_3 = 0.00378541;
        private const double PintToM_3 = 0.000473176;

        /// <summary>
        /// Converts value to system si
        /// </summary>
        /// <param name="value">Value to converting</param>
        /// <param name="measure">measure of value</param>
        /// <returns>value in meteres^3</returns>
        protected override double ToSystemSi(double value, string measure)
        {
            switch (measure)
            {
                case "m_3":
                    return value;
                case "gal":
                    return value * GallonToM_3;
                case "pints":
                    return value * PintToM_3;
                default:
                    throw new Exception("Error in Volume convertor");
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
                throw new Exception("Inccorect volume");
            }

            switch (ConvertTo)
            {
                case "m_3":
                    return ValueInSystemSi;
                case "gal":
                    return ValueInSystemSi / GallonToM_3;
                case "pints":
                    return ValueInSystemSi / PintToM_3;
                default:
                    throw new Exception("Error in Volume convertor");
            }
        }

        /// <summary>
        /// Realizes pattern singelton
        /// </summary>
        /// <returns>New Volume Convertor</returns>
        public static Convertor GetConvertor()
        {
            if (State == null)
            {
                State = new VolumeConvertor();
            }
            return State;
        }
    }
}
