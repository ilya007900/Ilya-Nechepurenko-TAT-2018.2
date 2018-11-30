using System.Collections.Generic;

namespace DEV_7
{
    class PassengerCarCollection : CarCollection
    {
        private PassengerCarCollection(List<Car> cars)
        {
            Cars = cars;
        }

        protected static PassengerCarCollection State { get; set; }

        public static CarCollection GetPassengerCarCollection(List<Car> cars)
        {
            if (State == null)
            {
                return new PassengerCarCollection(cars);
            }
            return State;
        }
    }
}
