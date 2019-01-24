using System;
namespace LW_List
{
    /// <summary>
    /// This programm finds cars in MyList class and diaplays in console cars that have one or more same properties
    /// </summary>
    class MyListSearcher
    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args">arguments of command line</param>
        static void Main(string[] args)
        {
            try
            {
                Car firstCar = new Car("bmw", "x5", "black");
                Car secondCar = new Car("mercedes", "e-class", "silver");
                Car thirdCar = new Car("audi", "a4", "white");
                Car audiCar = new Car("audi", "a5", "white");
                MyList myList = new MyList();
                myList.AddHead(firstCar);
                myList.AddHead(secondCar);
                myList.AddHead(thirdCar);
                myList.AddHead(audiCar);
                Console.WriteLine("Cars in list");
                myList.Output();
                Car searchCar = new Car("bmw", "x6", "white");
                MyList searchResult = myList.Search(searchCar);
                Console.WriteLine($"Search Car: {searchCar.Model} {searchCar.Brand} {searchCar.Color}");
                Console.WriteLine("Search result:");
                searchResult.Output();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
