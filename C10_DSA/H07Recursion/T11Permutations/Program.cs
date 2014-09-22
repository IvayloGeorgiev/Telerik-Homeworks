using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T11Permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {1, 3, 5, 5};
            int[] arr2 = { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            permutationsRep(arr);
            Console.WriteLine("\n----------------------------------------\n");
            permutationsRep(arr2); 
        }

        public static void permutationsRep(int[] arr)
        {
            Array.Sort(arr);
            permute(arr, 0, arr.Length);
        }

        public static void permute(int[] arr, int start, int n)
        {
            Console.WriteLine(string.Join(", ", arr));
            int tmp = 0;

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

                            permute(arr, i + 1, n);
                        }
                    }
                    
                    tmp = arr[i];
                    for (int k = i; k < n - 1; k++ )
                        arr[k] = arr[k + 1];
                    arr[n - 1] = tmp;
                }
            }
        }
    }
}
