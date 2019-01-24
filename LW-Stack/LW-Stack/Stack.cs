using System;

namespace Stack
{    
    class Stack<T>
    {
        private class Node
        {
            public Node(T data, Node NextNode)
            {
                this.data = data;
                this.NextNode = NextNode;
            }
            public T data;
            public Node NextNode;
        }
        private int capacity;
        private Node Head;

        public int Size { get; private set; }

        public Stack(int capacity)
        {
            this.capacity = capacity;
        }

        public Stack()
        {
        }

        public T Pop()
        {
            if (Size == 0)
            {
                throw new Exception("Stack is empty");
            }
            Size--;
            T result = Head.data;
            Head = Head.NextNode;
            return result;
        }

        public void Push(T value)
        {
            if (Size == capacity && Size != 0) 
            {
                return;
            }
            Head = new Node(value, Head);
            Size++;
        }

        public T GetHead()
        {
            if (Head == null)
            {
                throw new Exception("Stack is empty");
            }
            return Head.data;
        }

        public void Resize(int newCapacity)
        {
            capacity = newCapacity;
            if (Size > capacity)
            {
                for (int i = Size - capacity; i > 0; i--) 
                {
                    Pop();
                }
            }
        }
    }
}
