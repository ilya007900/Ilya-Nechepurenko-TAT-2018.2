using System;
using System.Collections.Generic;
using System.Linq;

namespace DEV_5
{
    /// <summary>
    /// Provides methods to manipulation with collection
    /// </summary>
    abstract class Collection
    {
        protected List<Car> Cars { get; set; }

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
        /// <returns>average price</returns>
        public double AveragePrice()
        {
            return Cars.Average(x => x.Price);
        }

        /// <summary>
        /// Counts average price of brand
        /// </summary>
        /// <param name="brand"></param>
        /// <returns>average price of brand</returns>
        public double AveragePriceType(string brand)
        {
            brand = brand.ToLower();
            return Cars.Where(x => x.Brand.ToLower() == brand).Average(x => x.Price);
        }

        /// <summary>
        /// Counts number of cars
        /// </summary>
        /// <returns>number of cars</returns>
        public int CountAll()
        {
            return Cars.Sum(x => x.Count);
        }

        /// <summary>
        /// Counts number of brands
        /// </summary>
        /// <returns>number of brands</returns>
        public int CountTypes()
        {
            return Cars.GroupBy(x => x.Brand).Count();
        }
    }
}