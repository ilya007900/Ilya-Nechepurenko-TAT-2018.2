namespace LW_List
{
    /// <summary>
    /// Keeps properties Model, Brand, Color and method that compares cars
    /// </summary>
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

        /// <summary>
        /// Compare two cars
        /// </summary>
        /// <param name="car1">The first parameter to compare</param>
        /// <param name="car2">The second parameter to compare</param>
        /// <returns>true if all properties are same</returns>
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
