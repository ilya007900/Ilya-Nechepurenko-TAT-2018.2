using System;

namespace DEV_5
{
    class CarInputer
    {
        public static Car Get()
        {
            Console.WriteLine("Input brand");
            string brand = Console.ReadLine();

            Console.WriteLine("Input model");
            string model = Console.ReadLine();

            Console.WriteLine("Input count");
            string count = Console.ReadLine();

            Console.WriteLine("Input price");
            string price = Console.ReadLine();

            return new Car(brand, model, count, price);
        }
    }
}
