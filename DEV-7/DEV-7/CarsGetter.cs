using System.Collections.Generic;
using System.Xml;

namespace DEV_7
{
    static class CarsGetter
    {
        public static List<Car> GetCarsFromXml(string filePath)
        {
            List<Car> cars = new List<Car>();
            XmlDocument xml = new XmlDocument();
            xml.Load(filePath);

            XmlElement root = xml.DocumentElement;

            foreach (XmlNode car in root)
            {
                List<string> values = new List<string>(4);

                foreach (XmlNode property in car)
                {
                    values.Add(property.InnerText);
                }
                cars.Add(new Car(values[0], values[1], int.Parse(values[2]), int.Parse(values[3])));
            }
            return cars;
        }
    }
}
