using System.Collections.Generic;
using System.Linq;

namespace DEV_7
{
    class CarCollection : ICollectionInfo
    {
        List<Car> Cars { get; set; }

        public CarCollection()
        {
            Cars = new List<Car>
            {
                new Car("BMW", "M5", 180000, 1),
                new Car("BMW", "X6", 80000, 1)
            };
        }

        public int CountAll()
        {
            return Cars.Count;
        }

        public int CountTypes()
        {
            return Cars.GroupBy(x => x.Brand).Count();
        }

        public double GetAveragePrice()
        {
            return Cars.Average(x => x.Price);
        }

        public double GetAverageTypePrice(string brand)
        {
            return Cars.Where(x => x.Brand == brand).Average(x => x.Price);
        }
    }
}
