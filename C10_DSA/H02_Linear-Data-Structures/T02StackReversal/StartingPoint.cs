namespace T02StackReversal
{
    using System;

    public class StartingPoint
    {
        public static void Main(string[] args)
        {
            Reverser reverser = new Reverser();
            Console.WriteLine("Enter the number of integers you want to reverse: ");
            int n = 0;
            while (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Only enter integers for n.");
            }

            Console.WriteLine("\nEnter your sequence:");
            reverser.Fill(n);
            Console.WriteLine("Your reversed sequence is: ");
            reverser.Reverse();
        }        
    }
}
