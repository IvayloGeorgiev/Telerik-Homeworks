using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T03Divisors
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[] nums = new char[n];
            for (int i = 0; i < n; i++)
            {
                nums[i] = Console.ReadLine()[0];
            }

            List<string> results = new List<string>();
            permutationsRep(nums, results);
            int bestNum = int.MaxValue;
            int bestDivisors = int.MaxValue;
            foreach (var item in results)
            {
                int num = int.Parse(item);
                int curDivisors = 0;
                for (int i = 1; i <= num / 2; i++)
                {
                    if (num % i == 0) curDivisors++;
                }
                
                if (curDivisors < bestDivisors)
                {                    
                    bestDivisors = curDivisors;
                    bestNum = num;
                }
                else if (curDivisors == bestNum && num < bestNum)
                {
                    bestDivisors = curDivisors;
                    bestNum = num;
                }
            }

            Console.WriteLine(bestNum);
        }

        public static void permutationsRep(char[] arr, List<string> results)
        {
            Array.Sort(arr);
            permute(arr, 0, arr.Length, results);
        }

        public static void permute(char[] arr, int start, int n, List<string> results)
        {
            results.Add(string.Join(string.Empty, arr));
            char tmp;

            if (start < n)
            {
                for (int i = n - 2; i >= start; i--)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (arr[i] != arr[j])
                        {
                            // swap ps[i] <--> ps[j]
                            tmp = arr[i];
                            arr[i] = arr[j];
                            arr[j] = tmp;

                            permute(arr, i + 1, n, results);
                        }
                    }

                    tmp = arr[i];
                    for (int k = i; k < n - 1; k++)
                        arr[k] = arr[k + 1];
                    arr[n - 1] = tmp;
                }
            }
        }
    }
}
