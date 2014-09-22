namespace T11to13BasicADTs
{
    using System;

    public class MainEntry
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Linked list:");
            LinkedList<string> list = new LinkedList<string>();
            list.AddFirst("First");
            list.AddLast("Last");
            list.AddAfter(list.First(), "After First");
            list.AddBefore(list.Last(), "Before Last");
            Console.WriteLine(list.Print()); // Result: First, After First, Before Last, Last

            Console.WriteLine("\n-----------------------------------\n");

            Console.WriteLine("Stack with array:");
            StackArray<string> stack = new StackArray<string>();
            stack.Push("1. Ivan");
            stack.Push("2. Nikolay");
            stack.Push("3. Maria");
            stack.Push("4. George");
            Console.WriteLine("Top = {0}", stack.Peek());
            while (stack.Count > 0)
            {
                string personName = stack.Pop();
                Console.WriteLine(personName);
            }

            Console.WriteLine("\n-----------------------------------\n");

            Console.WriteLine("Queue with linked list:");
            LinkedQueue<string> queue = new LinkedQueue<string>();
            queue.Enqueue("Message One");
            queue.Enqueue("Message Two");
            queue.Enqueue("Message Three");
            queue.Enqueue("Message Four");
            while (queue.Count > 0)
            {
                string message = queue.Dequeue();
                Console.WriteLine(message);
            }
        }
    }
}
