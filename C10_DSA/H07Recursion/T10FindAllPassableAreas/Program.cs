using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T10FindAllPassableAreas
{
    class LargestArea
    {
        private const char DefaultChar = 'A';
        private static char[,] maze = {
                                         {' ', '#', '#',  ' ', ' ', ' ', ' ', ' ',  ' ', ' '},
                                         {' ', '#', ' ',  ' ', '#', '#', '#', ' ',  '#', ' '},
                                         {' ', '#', '#',  ' ', ' ', ' ', ' ', '#',  '#', ' '},
                                         {' ', '#', ' ',  '#', '#', '#', '#', ' ',  ' ', ' '},
                                         {' ', '#', ' ',  '#', ' ', '#', '#', '#',  '#', ' '},
                                         {' ', ' ', ' ',  '#', ' ', ' ', ' ', ' ',  '#', ' '}
                                     };

        static void Main(string[] args)
        {
            Console.WriteLine("Non traversed: \n");
            PrintMaze();
            Console.WriteLine("-------------------------");
            Console.WriteLine("\nTraversed\n");
            IList<int> sizes = FindAllAreas();
            PrintMaze();
            for (int i = 0; i < sizes.Count; i++)
            {                
                Console.WriteLine("Area {0} is of size {1}", (char) (DefaultChar + i), sizes[i]);
            }
        }

        private static List<int> FindAllAreas()
        {
            List<int> sizes = new List<int>();
            char traversed = DefaultChar;
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    int curSize = 0;
                    TraverseForPosition(i, j, traversed, ref curSize);
                    if (curSize > 0)
                    {
                        traversed++;
                        sizes.Add(curSize);
                    }
                }
            }
            
            return sizes;
        }

        private static void TraverseForPosition(int y, int x, char traversed, ref int size)
        {
            if (!PositionIsEmpty(y, x, ' ')) return;

            size++;
            maze[y, x] = traversed;

            TraverseForPosition(y - 1, x, traversed, ref size);
            TraverseForPosition(y + 1, x, traversed, ref size);
            TraverseForPosition(y, x - 1, traversed, ref size);
            TraverseForPosition(y, x + 1, traversed, ref size);
        }       

        public static void PrintMaze()
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    Console.Write("{0} ", maze[i, j]);
                }
                Console.WriteLine("\n");
            }
        }

        private static bool PositionIsEmpty(int y, int x, char empty)
        {
            if (y < 0 || y >= maze.GetLength(0) || x < 0 || x >= maze.GetLength(1))
            {
                return false;
            }
            if (maze[y, x] != empty)
            {
                return false;
            }

            return true;
        }
    }
}
