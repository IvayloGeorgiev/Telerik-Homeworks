namespace T05AllAvailableSubsets
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            string[] set = { "hi", "a", "b" };
            int k = 2;
            string[] result = new string[k];
            Subsets(set, result, 0);
        }

        private static void Subsets(string[] set, string[] result, int currentDepth)
        {
            if (currentDepth == result.Length)
            {
                Console.WriteLine(string.Join(", ", result));
                return;
            }

            for (int i = 0; i < set.Length; i++)
            {
                result[currentDepth] = set[i];
                Subsets(set, result, currentDepth + 1);
            }
        }
    }
}
