using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T02BunnyColors
{
    class Program
    {
        static void Main(string[] args)
        {
            //Bag would also work but there is no need to import the library just for the task.
            Dictionary<int, int> bunnies = new Dictionary<int, int>();
            int lines = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < lines; i++)
            {
                int curBunny = int.Parse(Console.ReadLine());
                if (!bunnies.ContainsKey(curBunny))
                {
                    bunnies.Add(curBunny, 0);
                }

                bunnies[curBunny]++;
            }

            int result = 0;
            foreach (var item in bunnies)
            {
                int val = item.Value;
                int buns = item.Key + 1;                
                while (val > 0)
                {
                    result += buns;
                    val -= buns;
                }
            }

            Console.WriteLine(result);
        }
    }
}
