using System;

namespace DEV_5
{
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }

        public Car(string brand, string model, int count, int price)
        {
            Brand = brand;
            Model = model;
            Count = count;
            Price = price;
        }

        public Car(string brand, string model, string count, string price)
        {
            Brand = brand;
            Model = model;
            if(!int.TryParse(count, out int tempCount))
            {
                throw new ArgumentException("Can't parse string count to int");
            }
            Count = tempCount;
            if (!int.TryParse(price, out int tempPrice))
            {
                throw new ArgumentException("Can't parse string price to int");
            }
            Price = tempPrice;
        }
    }
}
