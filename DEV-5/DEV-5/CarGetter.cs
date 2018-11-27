using System;

namespace DEV_5
{
    static class CarGetter
    {
        public static Car GetCarFromConsole()
        {
            Console.WriteLine("Input car brand");
            string brand = Console.ReadLine();

            Console.WriteLine("Input car model");
            string model = Console.ReadLine();

            Console.WriteLine("Input car price");
            int price = int.Parse(Console.ReadLine());

            Console.WriteLine("Input car count");
            int count = int.Parse(Console.ReadLine());

            return new Car(brand, model, count, price);
        }
    }
}
