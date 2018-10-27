
namespace LW_List
{
    class Car
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }

        public Car(string model, string brand, string color)
        {
            Model = model;
            Brand = brand;
            Color = color;
        }

        public static bool CompareCars(Car car1, Car car2)
        {
            if (string.Compare(car1.Model, car2.Model) == 0)
            {
                return true;
            }
            if (string.Compare(car1.Brand, car2.Brand) == 0)
            {
                return true;
            }
            if (string.Compare(car1.Color, car2.Color) == 0)
            {
                return true;
            }
            return false;
        }
    }
}
