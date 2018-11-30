using System.Collections.Generic;

namespace DEV_7
{
    /// <summary>
    /// Single collection that keeps passenger cars
    /// </summary>
    class PassengerCarCollection : CarCollection
    {
        private PassengerCarCollection(List<Car> cars)
        {
            Cars = cars;
        }

        protected static PassengerCarCollection State { get; set; }

        /// <summary>
        /// Gets single passenger cars collection
        /// </summary>
        /// <param name="cars">Passenger cars for collection</param>
        /// <returns>Single passenger cars collection</returns>
        public static PassengerCarCollection GetPassengerCarCollection(List<Car> cars)
        {
            if (State == null)
            {
                return new PassengerCarCollection(cars);
            }
            return State;
        }
    }
}
