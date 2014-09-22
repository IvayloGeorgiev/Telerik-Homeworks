using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T08TestIfPathExists
{
    class Program
    {
        private static char[,] maze = {
                                         {' ', '#', '#',  ' ', ' ', ' ', ' ', ' ',  ' ', ' '},
                                         {' ', '#', ' ',  ' ', '#', '#', '#', ' ',  '#', ' '},
                                         {' ', '#', ' ',  ' ', ' ', ' ', ' ', '#',  '#', ' '},
                                         {' ', '#', ' ',  '#', '#', '#', '#', ' ',  ' ', ' '},
                                         {' ', '#', ' ',  '#', ' ', '#', '#', ' ',  '#', ' '},
                                         {' ', ' ', ' ',  ' ', ' ', ' ', ' ', ' ',  '#', ' '}
                                     };
        static void Main(string[] args)
        {
            SetExit(maze.GetLength(0) - 1, maze.GetLength(1) - 1);
            bool result = false;
            PathExists(0, 0, ref result);
            Console.WriteLine(result);            
            EmptyMaze(100);
            SetExit(maze.GetLength(0) / 2, maze.GetLength(1) / 2);
            result = false;
            PathExists(0, 0, ref result);
            Console.WriteLine(result);                        
        }

        private static void PathExists(int y, int x, ref bool result)
        {
            if (y < 0 || y >= maze.GetLength(0) || x < 0 || x >= maze.GetLength(1) || result)
            {
                return;
            }
            else if (maze[y, x] == 'e')
            {
                result = true;                                
                return;
            }

            if (maze[y, x] != ' ')
            {
                return;
            }

            maze[y, x] = 'p';

            PathExists(y - 1, x, ref result);
            PathExists(y, x + 1, ref result);
            PathExists(y + 1, x, ref result);
            PathExists(y, x - 1, ref result);                        

            maze[y, x] = ' ';
        }

        private static bool ValidPosition(int y, int x)
        {
            if (y < 0 || y >= maze.GetLength(0) || x < 0 || x >= maze.GetLength(1))
            {
                return false;
            }
            else if (maze[y, x] == 'e' || maze[y, x] == ' ')
            {
                return true;
            }

            return false;
        }

        private static void EmptyMaze(int size)
        {
            maze = new char[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    maze[i, j] = ' ';
                }
            }
        }

        private static void SetExit(int y, int x)
        {
            maze[y, x] = 'e';
        }

        public static void PrintMaze()
        {
            for (int i = 0; i < maze.GetLength(0); i++)
			{
			    for (int j = 0; j < maze.GetLength(1); j++)
			    {
			        Console.Write("{0} ", maze[i,j]);
			    }
                Console.WriteLine("\n");
			}
        }
    }
}
