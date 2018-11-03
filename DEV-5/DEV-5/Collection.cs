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
                new Car("bmw","m6",1,90000),
                new Car("bmw","m4",1,50000),
                new Car("bmw","x5",1,70000),
                new Car("bmw","x6",1,80000)
            };
        }

        public void CountTypes()
        {
            Console.WriteLine(Cars.GroupBy(x => x.Brand).Count());
        }

        public void CountAll()
        {
            Console.WriteLine(Cars.Sum(x => x.Count));
        }

        public void AvaragePrice()
        {
            Console.WriteLine(Cars.Sum(x => x.Price) / Cars.Sum(x => x.Count));
        }

        public void AvaragePiceType(string brand)
        {
            Console.WriteLine(Cars.Where(x => x.Brand == brand).Sum(x => x.Price) / Cars.Where(x => x.Brand == brand).Count());
        }

        public void AddInCollection(Car car)
        {
            Cars.Add(car);
        }
    }
}
