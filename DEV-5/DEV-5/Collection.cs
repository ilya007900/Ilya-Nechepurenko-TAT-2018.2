using System;
using System.Collections.Generic;
using System.Linq;

namespace DEV_5
{
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

        public int CountTypes()
        {
            return Cars.GroupBy(x => x.Brand).Count();
        }

        public int CountAll()
        {
            return Cars.Sum(x => x.Count);
        }

        public double AveragePrice()
        {
            return Cars.Average(x => x.Price);
        }

        public double AveragePiceType(string brand)
        {
            return Cars.Where(x => x.Brand == brand).Average(x => x.Price);
        }

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
