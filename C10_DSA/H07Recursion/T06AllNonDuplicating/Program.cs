namespace T06AllNonDuplicating
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            string[] set = { "test", "rock", "fun" };
            int k = 2;
            string[] result = new string[k];
            Subsets(set, result, 0);
        }

        private static void Subsets(string[] set, string[] result, int currentDepth, int start = 0)
        {
            if (currentDepth == result.Length)
            {
                Console.WriteLine(string.Join(", ", result));
                return;
            }

            for (int i = start; i < set.Length; i++)
            {
                result[currentDepth] = set[i];
                Subsets(set, result, currentDepth + 1, i + 1);
            }
        }
    }
}
