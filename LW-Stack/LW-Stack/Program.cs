using System;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Stack<int> stack = new Stack<int>();
                for (int i = 0; i < 10; i++)
                {
                    stack.Push(i);
                }
                for (int i = stack.Size; i != 0; i--)
                {
                    Console.WriteLine(stack.Pop());
                }
                Console.WriteLine(stack.Pop());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
