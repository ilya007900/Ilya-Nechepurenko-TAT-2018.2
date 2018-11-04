using System;

namespace DEV_5
{
    /// <summary>
    /// Provides methods for getting car from console
    /// </summary>
    class CarInputer
    {
        /// <summary>
        /// Gets car from console
        /// </summary>
        /// <returns>new Car</returns>
        public Car GetCarFromConsole()
        {
            return new Car(GetBrand(), GetModel(), GetCount(), GetPrice());
        }

        /// <summary>
        /// Gets brand from console
        /// </summary>
        /// <returns>brand</returns>
        private string GetBrand()
        {
            Console.WriteLine("Input brand");
            return Console.ReadLine();
        }

        /// <summary>
        /// Gets model from console
        /// </summary>
        /// <returns>model</returns>
        private string GetModel()
        {
            Console.WriteLine("Input model");
            return Console.ReadLine();
        }

        /// <summary>
        /// Gets count from console
        /// </summary>
        /// <returns>count</returns>
        private string GetCount()
        {
            Console.WriteLine("Input count");
            return Console.ReadLine();
        }

        /// <summary>
        /// Gets price from console
        /// </summary>
        /// <returns>price</returns>
        private string GetPrice()
        {
            Console.WriteLine("Input price");
            return Console.ReadLine();
        }

    }
}
