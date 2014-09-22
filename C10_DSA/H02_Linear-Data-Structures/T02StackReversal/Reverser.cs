namespace T02StackReversal
{
    using System;
    using System.Collections.Generic;    

    public class Reverser
    {
        private readonly Stack<int> stack;

        public Reverser()
        {            
            this.stack = new Stack<int>();
        }

        public IEnumerable<int> Reverse()
        {
            List<int> result = new List<int>();
            while (this.stack.Count > 0)
            {
                int currentNum = this.stack.Pop();
                Console.WriteLine(currentNum);
                result.Add(currentNum);
            }

            return result;
        }

        public void Fill(int n)
        {
            for (int i = 0; i < n; i++)
            {
                int num = 0;
                if (int.TryParse(Console.ReadLine(), out num))
                {
                    this.stack.Push(num);
                }
                else
                {
                    i--;
                    Console.WriteLine("Only enter integers.");
                }
            }
        }
    }
}
