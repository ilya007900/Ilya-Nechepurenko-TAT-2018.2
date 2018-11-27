using System.Collections.Generic;

namespace DEV_5
{
    class TrucksCollection : Collection
    {
        public TrucksCollection()
        {
            Cars = new List<Car>
            {
                new Car("Volvo", "FH", 2, 160000),
                new Car("Volvo", "FL", 2, 140000),
                new Car("Renault", "Master", 2, 80000),
                new Car("Renault", "Magnum", 2, 130000)
            };
        }
    }
}
