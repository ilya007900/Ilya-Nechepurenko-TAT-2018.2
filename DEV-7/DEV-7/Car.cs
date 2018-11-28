
namespace DEV_7
{
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }

        public Car(string brand, string model, int price, int count)
        {
            Brand = brand;
            Model = model;
            Price = price;
            Count = count;
        }
    }
}
