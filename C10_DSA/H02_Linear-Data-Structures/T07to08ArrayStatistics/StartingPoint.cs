namespace T07to08ArrayStatistics
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
                IArrayOperation operation = null;
                if (input == '1')
                {
                    operation = new OccuranceCount();
                }
                else if (input == '2')
                {
                    operation = new MajorantUsingSort();
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
                var ui = new ArrayStatsUI(operation);
                ui.Start();
            }
            while (input != 'q');            
        }

        private static void GenericIntro()
        {
            Console.WriteLine("Please select the type of manipulation for the list:");
            Console.WriteLine("1. Find number occurance.");
            Console.WriteLine("2. Find majorant.");            
            Console.WriteLine("q. Quit.");
        }
    }
}
