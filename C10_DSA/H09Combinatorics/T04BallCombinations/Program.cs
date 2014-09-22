using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace T04BallCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            BigInteger num = Factorial(line.Length);
            Dictionary<char, int> occurances = new Dictionary<char, int>();
            foreach (var item in line)
            {
                if (!occurances.ContainsKey(item))
                {
                    occurances.Add(item, 0);
                }

                occurances[item]++;
            }

            foreach (var item in occurances)
            {
                BigInteger divisor = Factorial(item.Value);
                num /= divisor;
            }

            Console.WriteLine(num);
        }

        public static BigInteger Factorial(int n)
        {
            BigInteger num = 1;
            for (int i = 2; i <= n; i++)
            {
                num *= i;
            }

            return num;
        }
    }
}
