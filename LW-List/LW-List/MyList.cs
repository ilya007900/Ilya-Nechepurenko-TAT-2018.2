using System;

namespace LW_List
{
    class MyList
    {
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
