
namespace LW_Convertors
{
    abstract class Convertor
    {
        protected static Convertor State { get; set; }
        protected abstract double ToSystemSi(double value, string measure);
        public abstract double Convert(double value, string ConvertFrom, string ConvertTo);
    }
}