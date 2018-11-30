using System.Collections.Generic;
using System.Linq;

namespace DEV_7
{
    abstract class CarCollection
    {
        protected List<Car> Cars { get; set; }

        public double GetAveragePrice()
        {
            return Cars.Average(x => x.Price);
        }

        public double GetAverageTypePrice(string brand)
        {
            brand = brand.ToLower();
            return Cars.Where(x => x.Brand.ToLower() == brand).Average(x => x.Price);
        }

        public int CountAll()
        {
            return Cars.Sum(x => x.Count);
        }

        public int CountTypes()
        {
            return Cars.GroupBy(x => x.Brand).Count();
        }
    }
}
