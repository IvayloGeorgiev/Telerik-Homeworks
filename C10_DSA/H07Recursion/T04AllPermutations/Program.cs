namespace T04AllPermutations
{
    using System;

    class Program
    {
        private static bool[] passed;

        static void Main(string[] args)
        {
            int n = 3;
            int[] result = new int[n];
            passed = new bool[n + 1];

            Loop(result, 0);
        }

        private static void Loop(int[] result, int curDepth, int start = 1)
        {
            if (curDepth == result.Length)
            {
                Console.WriteLine(string.Join(", ", result));
                return;
            }

            for (int i = start; i <= result.Length; i++)
            {
                if (!passed[i])
                {
                    passed[i] = true;
                    result[curDepth] = i;
                    Loop(result, curDepth + 1, start);
                    passed[i] = false;
                }
            }
        }
    }
}
