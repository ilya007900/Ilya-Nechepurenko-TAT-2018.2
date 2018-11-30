using System.Collections.Generic;

namespace DEV_7
{
    class TruckCollection : CarCollection
    {
        private TruckCollection(List<Car> cars)
        {
            Cars = cars;
        }

        protected static TruckCollection State { get; set; }

        public static TruckCollection GetTruckCollection(List<Car> cars)
        {
            if (State == null)
            {
                return new TruckCollection(cars);
            }
            return State;
        }
    }
}
