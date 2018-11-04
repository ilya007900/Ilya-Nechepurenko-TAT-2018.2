using System;

namespace DEV_5
{
    class CarInputer
    {
        public Car GetCarFromConsole()
        {
            return new Car(GetBrand(), GetModel(), GetCount(), GetPrice());
        }

        private string GetBrand()
        {
            Console.WriteLine("Input brand");
            return Console.ReadLine();
        }

        private string GetModel()
        {
            Console.WriteLine("Input model");
            return Console.ReadLine();
        }

        private string GetCount()
        {
            Console.WriteLine("Input count");
            return Console.ReadLine();
        }

        private string GetPrice()
        {
            Console.WriteLine("Input price");
            return Console.ReadLine();
        }

    }
}
