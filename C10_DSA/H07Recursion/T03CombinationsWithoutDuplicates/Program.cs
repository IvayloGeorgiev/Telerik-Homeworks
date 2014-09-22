namespace T03CombinationsWithoutDuplicates
{
    using System;

    class Program
    {
        private static int[] result;

        static void Main(string[] args)
        {
            int n = 4;
            int k = 2;
            result = new int[k];
            Loop(n, 0);
        }

        private static void Loop(int n, int curDepth, int start = 1)
        {
            if (curDepth == result.Length)
            {
                Console.WriteLine(string.Join(", ", result));
                return;
            }

            for (int i = start; i <= n; i++)
            {
                result[curDepth] = i;
                Loop(n, curDepth + 1, i + 1);
            }
        }
    }
}
