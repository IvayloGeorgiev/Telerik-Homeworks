using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T01BinaryPasswords
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int wildcards = 0;
            foreach (var symbol in input)
            {
                if (symbol == '*')
                {
                    wildcards++;
                }
            }

            Console.WriteLine(PowerOfTwo(wildcards));            
        }

        private static ulong PowerOfTwo(int power)
        {
            ulong result = 1;
            for (int i = 0; i < power; i++)
            {
                result *= 2;
            }

            return result;
        }
    }
}
