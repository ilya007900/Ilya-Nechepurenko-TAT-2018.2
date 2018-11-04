using System;
using System.Collections.Generic;
using System.Linq;

namespace DEV_5
{
    /// <summary>
    /// Keeps cars and methods to manipulation
    /// </summary>
    class Collection
    {
        public List<Car> Cars { get; set; }

        public Collection()
        {
            Cars = new List<Car>
            {
                new Car("bmw","m5",1,100000),
                new Car("bmw","m6",1,90000)
            };
        }

        /// <summary>
        /// Counts number of brands
        /// </summary>
        /// <returns>number of brands</returns>
        public int CountTypes()
        {
            return Cars.GroupBy(x => x.Brand).Count();
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
        public double AveragePiceType(string brand)
        {
            return Cars.Where(x => x.Brand == brand).Average(x => x.Price);
        }

        /// <summary>
        /// Adds new car in collection
        /// </summary>
        /// <param name="car">Car for add</param>
        public void AddInCollection(Car car)
        {
            Car tempCar = Cars.Find(x => x.Brand == car.Brand && x.Model == car.Model);

            if (tempCar!=null)
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
    }
}
