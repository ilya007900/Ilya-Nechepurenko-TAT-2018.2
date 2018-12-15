using System.Collections.Generic;

namespace DEV_7
{
    /// <summary>
    /// Single collection that keeps trucks
    /// </summary>
    class TruckCollection : CarCollection
    {
        private TruckCollection(List<Car> cars)
        {
            Cars = cars;
        }

        protected static TruckCollection State { get; set; }

        /// <summary>
        /// Gets single trucks collection
        /// </summary>
        /// <param name="cars">Trucks for collection</param>
        /// <returns>Single trucks collection</returns>
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
