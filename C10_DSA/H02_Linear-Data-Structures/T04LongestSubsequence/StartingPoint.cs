namespace T04LongestSubsequence
{
    using System;

    public class StartingPoint
    {
        public static void Main(string[] args)
        {
            char input;
            do
            {
                GenericIntro();
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();
                IManipulateList operation = null;
                if (input == '1')
                {
                    operation = new LongestSubsequenceSearch();
                }
                else if (input == '2')
                {
                    operation = new RemoveNegaiveNumbers();
                }
                else if (input == '3')
                {
                    operation = new RemovedOddNumbers();
                }                
                else if (input == 'q')
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                Console.WriteLine("\n");
                SubsequenceConsoleUI search = new SubsequenceConsoleUI(operation);
                search.Start();
            }
            while (input != 'q');
        }

        private static void GenericIntro()
        {
            Console.WriteLine("Please select the type of manipulation for the list:");
            Console.WriteLine("1. Longest repeating number subsequence.");
            Console.WriteLine("2. Remove negative numbers.");
            Console.WriteLine("3. Remove numbers with odd occurance.");            
            Console.WriteLine("q. Quit.");
        }
    }
}
