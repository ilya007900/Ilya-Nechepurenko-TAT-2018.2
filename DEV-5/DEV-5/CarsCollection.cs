using System.Collections.Generic;

namespace DEV_5
{
    class CarsCollection : Collection
    {
        public CarsCollection()
        {
            Cars = new List<Car>
            {
                new Car("BMW", "M5", 1, 120000),
                new Car("BMW", "5 series", 1, 60000),
                new Car("AUDI", "A4", 1, 40000),
                new Car("AUDI", "A6", 1, 60000),
                new Car("PORSCHE", "PANAMERA", 1, 140000),
                new Car("PORSCHE", "CAYENNE", 1, 90000)
            };
        }
    }
}
