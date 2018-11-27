
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
    }
}
