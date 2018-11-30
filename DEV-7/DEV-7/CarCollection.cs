using System.Collections.Generic;
using System.Linq;

namespace DEV_7
{
    /// <summary>
    /// Provides methods to manipulation with collection
    /// </summary>
    abstract class CarCollection
    {
        protected List<Car> Cars { get; set; }

        /// <summary>
        /// Counts average price
        /// </summary>
        /// <returns>Average price</returns>
        public double GetAveragePrice()
        {
            return Cars.Average(x => x.Price);
        }

        /// <summary>
        /// Counts average price of brand
        /// </summary>
        /// <param name="brand">Brand of car</param>
        /// <returns>Average price of brand</returns>
        public double GetAverageTypePrice(string brand)
        {
            brand = brand.ToLower();
            return Cars.Where(x => x.Brand.ToLower() == brand).Average(x => x.Price);
        }

        /// <summary>
        /// Counts number of cars
        /// </summary>
        /// <returns>Number of cars</returns>
        public int CountAll()
        {
            return Cars.Sum(x => x.Count);
        }

        /// <summary>
        /// Counts number of brands
        /// </summary>
        /// <returns>Number of brands</returns>
        public int CountTypes()
        {
            return Cars.GroupBy(x => x.Brand).Count();
        }
    }
}
