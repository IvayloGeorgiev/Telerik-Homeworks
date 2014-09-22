namespace T09to10PathsWithQueues
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class QueuePathsMain
    {
        /// <summary>
        /// Cant be arsed to split it into UI's again, sorry.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            List<Func<int, int>> operations = new List<Func<int, int>>();
            operations.Add(x => x + 1);
            operations.Add(x => (2 * x) + 1);
            operations.Add(x => x + 2);
            List<int> output = GetFirstMembers(2, operations, 50);
            Console.WriteLine(string.Join(", ", output));

            Console.WriteLine("------------------------------------");

            List<Func<int, int>> operationsForSum = new List<Func<int, int>>();
            operationsForSum.Add(x => x + 1);
            operationsForSum.Add(x => x + 2);
            operationsForSum.Add(x => x * 2);
            List<int> result = FirstToSum(2, operationsForSum, 15000);
            Console.WriteLine(string.Join(", ", result));
        }

        public static List<int> GetFirstMembers(int start, List<Func<int, int>> operations, int count)
        {
            List<int> result = new List<int>();
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            for (int i = 0; i < count; i++)
            {
                int temp = queue.Dequeue();
                result.Add(temp);
                foreach (var operation in operations)
                {
                    queue.Enqueue(operation(temp));
                }
            }

            return result;
        }

        public static List<int> FirstToSum(int start, List<Func<int, int>> operations, int sum)
        {
            List<int> result = new List<int>();
            Queue<List<int>> queue = new Queue<List<int>>();
            HashSet<int> visited = new HashSet<int>();

            result.Add(start);
            queue.Enqueue(result);
            while (queue.Count > 0)
            {
                List<int> currentStack = queue.Dequeue();
                int currentValue = currentStack.Last();                

                if (currentValue == sum)
                {                    
                    result = currentStack;
                    return result;
                }
                else if (currentValue > sum || visited.Contains(currentValue)) 
                {
                    // > sum only works when we dont have division/substractoin as possible operations.
                    continue;
                }

                visited.Add(currentValue);
                foreach (var operation in operations)
                {
                    List<int> temp = new List<int>(currentStack);
                    temp.Add(operation(currentValue));
                    queue.Enqueue(temp);
                }
            }

            throw new ArgumentException("No way to reach the value.");
        }
    }
}
