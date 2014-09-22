using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T02WordChange
{
    class Program
    {
        private const double DELETE_COST = 0.9;

        private const double INSERT_COST = 0.8;

        private const double REPLACE_COST = 1;

        static void Main(string[] args)
        {
            string input = "eveloper";
            string output = "enveloper";

            double[,] dp = new double[input.Length + 1, output.Length + 1];

            dp[0, 0] = 0;

            for (int i = 1; i <= input.Length; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + DELETE_COST;
            }

            for (int i = 1; i <= output.Length; i++)
            {
                dp[0, i] = dp[0, i - 1] + INSERT_COST;
            }

            for (int i = 1; i <= input.Length; i++)
            {
                for (int j = 1; j <= output.Length; j++)
                {
                    double replaceCost = 0;
                    if (input[i - 1] != output[j - 1])
                    {
                        replaceCost = REPLACE_COST;
                    }

                    replaceCost += dp[i - 1, j - 1];

                    double insertCost = dp[i, j - 1] + INSERT_COST;

                    double deleteCost = dp[i - 1, j] + DELETE_COST;

                    dp[i, j] = GetMinOfThree(replaceCost, insertCost, deleteCost);
                }
            }

            Console.WriteLine("{0} to {1} -> cost {2}", input, output, dp[input.Length, output.Length]);
        }

        private static double GetMinOfThree(double first, double second, double third)
        {
            double minOfTwo = Math.Min(first, second);
            return Math.Min(minOfTwo, third);
        }
    }
}
