using System;

namespace LW_List
{
    /// <summary>
    /// This class keeps objects of class Car
    /// </summary>
    class MyList
    {
        /// <summary>
        /// This class keeps object Car and reference on next car and prevoius car
        /// </summary>
        private class Node
        {
            public Car Car { get; set; }
            public Node PrevCar { get; set; }
            public Node NextCar { get; set; }

            public Node(Car car, Node prevCar, Node nextCar)
            {
                Car = car;
                PrevCar = prevCar;
                NextCar = nextCar;
            }
        }

        private Node Head { get; set; }

        /// <summary>
        /// Inserts car in the beginning of MyList
        /// </summary>
        /// <param name="car">The car to inseted in the beginning of list</param>
        public void AddHead(Car car)
        {
            if (Head == null)
            {
                Head = new Node(car, null, null); 
            }
            else
            {
                Node newHead = new Node(car, null, Head);
                Head = newHead;
            }
        }

        /// <summary>
        /// Writes all Cars on console
        /// </summary>
        public void Output()
        {
            if (Head == null)
            {
                Console.WriteLine("List is empty");
            }
            else
            {
                Node tempHead = Head;
                while (tempHead != null)
                {
                    Console.WriteLine($"{tempHead.Car.Model} {tempHead.Car.Brand} {tempHead.Car.Color}");
                    tempHead = tempHead.NextCar;
                }
            }
        }

        /// <summary>
        /// Searchs cars that have one or more same property 
        /// </summary>
        /// <param name="car">Car for find</param>
        /// <returns>Object of MyList that contains cars with same property</returns>
        public MyList Search(Car car)
        {
            MyList searcResult = new MyList();
            if (Head == null)
            {
                throw new Exception("List is empty");
            }
            else
            {
                Node tempHead = Head;
                while (tempHead != null)
                {
                    if(Car.CompareCars(car, tempHead.Car))
                    {
                        searcResult.AddHead(tempHead.Car);
                    }
                    tempHead = tempHead.NextCar;
                }
            }
            return searcResult;
        } 
    }
}
