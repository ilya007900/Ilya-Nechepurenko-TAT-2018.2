using System;
using System.Linq;
using System.Collections.Generic;

namespace DEV_5
{
    /// <summary>
    /// Provides methods to manipulation with collection
    /// </summary>
    class Collection
    {
        private List<Car> Cars { get; set; }
        /// <summary>
        /// Adds new car in collection
        /// </summary>
        /// <param name="car">Car for add</param>
        public void AddInCollection(Car car)
        {
            Car tempCar = Cars.Find(x => x.Brand == car.Brand && x.Model == car.Model);

            if (tempCar != null)
            {
                if (tempCar.Price == car.Price)
                {
                    tempCar.Count += car.Count;
                }
                else
                {
                    throw new Exception("Incorrect car input");
                }
            }
            else
            {
                Cars.Add(car);
            }
        }

        /// <summary>
        /// Counts average price
        /// </summary>
        /// <returns>Average price</returns>
        public double AveragePrice()
        {
            return Cars.Average(x => x.Price);
        }

        /// <summary>
        /// Counts average price of brand
        /// </summary>
        /// <param name="brand">Car brand</param>
        /// <returns>Average price of brand</returns>
        public double AveragePriceType(string brand)
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

        public Collection()
        {
            Cars = new List<Car>();
        }
    }
}
