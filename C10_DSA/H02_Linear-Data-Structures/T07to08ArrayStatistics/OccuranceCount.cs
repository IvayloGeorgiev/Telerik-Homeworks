namespace T07to08ArrayStatistics
{
    using System;
    using System.Collections.Generic;

    public class OccuranceCount : IArrayOperation
    {
        public void Execute(int[] sequence)
        {                       
            SortedDictionary<int, int> occurances = new SortedDictionary<int, int>();

            if (sequence.Length < 1)
            {
                throw new ArgumentException("Sequence has no values.");
            }

            foreach (var item in sequence)
            {
                if (occurances.ContainsKey(item))
                {
                    occurances[item]++;
                }
                else
                {
                    occurances.Add(item, 1);
                }                
            }

            Console.WriteLine("Original sequence:");
            Console.WriteLine(string.Join(", ", sequence));
            Console.WriteLine("Number occurances:");
            foreach (var key in occurances.Keys)
            {
                Console.WriteLine("{0} -> {1}", key, occurances[key]);
            }

            Console.WriteLine("\n------------------\n");
        }
    }
}
