namespace T01_List_Sequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartingPoint
    {
        public static void Main(string[] args)
        {
            // Fill filler = ConsoleFill;
            PositiveSequence sequence = new PositiveSequence(ConsoleFill);              
            sequence.Fill();
            Console.WriteLine("Sequence Average: {0}", sequence.Average());
            Console.WriteLine("Sequence Sum: {0}", sequence.Sum());
        }        
         
        public static List<int> ConsoleFill()
        {
            List<int> result = new List<int>();
            Console.WriteLine("Enter your desired numerical sequence (enter an empty line to stop):");
            string input = Console.ReadLine();
            while (input != string.Empty)
            {
                string[] split = input.Split(' ');
                string[] clean = (from number in split
                                  where !string.IsNullOrWhiteSpace(number)
                                  select number).ToArray();
                for (int i = 0; i < clean.Length; i++)
                {
                    int num = 0;
                    if (int.TryParse(clean[i], out num))
                    {
                        result.Add(num);
                    }
                }

                input = Console.ReadLine();
            }

            return result;
        }
    }
}
