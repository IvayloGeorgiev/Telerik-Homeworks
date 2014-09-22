using System;
using System.Collections.Generic;

namespace KnapsackProblem
{
    public class Product
    {
        public Product(string name, int weigth, int cost)
        {
            this.Name = name;
            this.Weight = weigth;
            this.Cost = cost;
        }

        public string Name { get; set; }

        public int Weight { get; set; }

        public int Cost { get; set; }
        
        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }
    }
    internal class Program
    {
        private static Product[] products;

        private static int[,] valueTable;

        private static bool[,] keptTable;

        private static int capacity;

        private static void Main(string[] args)
        {
            products = new Product[]
            {
                new Product("Beer",3,2),
                new Product("Vodka",8,12),
                new Product("Cheese",4,5),
                new Product("Nuts",1,4),
                new Product("Ham",2,3),
                new Product("Whiskey",8,13)
            };

            Console.WriteLine("Enter sack capacity: ");
            capacity = int.Parse(Console.ReadLine());
            valueTable = new int[products.Length + 1, capacity + 1];
            keptTable = new bool[products.Length + 1, capacity + 1];

            //Dynamic programming
            GetValues();

            var solution = GetSolution();

            PrintSolution(solution);
        }

        private static void GetValues()
        {
            for (int i = 1; i <= products.Length; i++)
            {
                for (int j = 1; j <= capacity; j++)
                {
                    if (products[i - 1].Weight <= j)
                    {
                        if (products[i - 1].Cost + valueTable[i - 1, j - products[i - 1].Weight] > valueTable[i - 1, j])
                        {
                            valueTable[i, j] = products[i - 1].Cost + valueTable[i - 1, j - products[i - 1].Weight];
                            keptTable[i, j] = true;
                        }
                        else
                        {
                            valueTable[i, j] = valueTable[i - 1, j];
                        }
                    }
                    else valueTable[i, j] = valueTable[i - 1, j];
                }
            }

            for (int i = 0; i <= products.Length; i++)
            {
                for (int j = 0; j <= capacity; j++)
                {
                    Console.Write("{0} ", valueTable[i, j]);
                }
                Console.WriteLine("\n");
            }
        }

        private static List<Product> GetSolution()
        {
            var itemsCount = products.Length;
            var capacityLeft = capacity;
            var solution = new List<Product>();

            while (itemsCount > 0)
            {
                if (keptTable[itemsCount, capacityLeft])
                {
                    solution.Add(products[itemsCount - 1]);
                    capacityLeft -= products[itemsCount - 1].Weight;
                }

                itemsCount--;
            }

            return solution;
        }

        private static void PrintSolution(List<Product> solution)
        {
            Console.WriteLine(string.Format("Best value: {0}", valueTable[products.Length, capacity]));
            Console.WriteLine("Products used: {0}", string.Join(", ",solution));            
        }
    }
}