using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T07AllPathsBetweenCells
{
    class Program
    {
        private static char[,] maze = {
                                         {' ', '#', '#',  ' ', ' ', ' ', ' ', ' ',  ' ', ' '},
                                         {' ', '#', ' ',  ' ', '#', '#', '#', ' ',  '#', ' '},
                                         {' ', '#', ' ',  ' ', ' ', ' ', ' ', '#',  '#', ' '},
                                         {' ', '#', ' ',  '#', '#', '#', '#', ' ',  ' ', ' '},
                                         {' ', '#', ' ',  '#', ' ', '#', '#', ' ',  '#', ' '},
                                         {' ', ' ', ' ',  ' ', ' ', ' ', ' ', ' ',  '#', 'e'},
                                         {' ', '#', '#',  '#', '#', '#', '#', '#',  '#', ' '},
                                         {' ', '#', ' ',  '#', ' ', '#', '#', ' ',  '#', ' '},
                                         {' ', ' ', ' ',  ' ', ' ', ' ', ' ', ' ',  ' ', ' '}
                                     };

        static void Main(string[] args)
        {
            TraverseForPositions(2, 0);
        }

        private static void TraverseForPositions(int y, int x)
        {
            if (y < 0 || y >= maze.GetLength(0) || x < 0 || x >= maze.GetLength(1))
            {
                return;
            }
            else if (maze[y, x] == 'e')
            {
                Console.WriteLine("Exit found. Printing path...");
                PrintMaze();
            }
            
            if (maze[y, x] != ' ')
            {
                return;
            }

            maze[y, x] = 'p';

            TraverseForPositions(y - 1, x);
            TraverseForPositions(y + 1, x);
            TraverseForPositions(y, x - 1);
            TraverseForPositions(y, x + 1);

            maze[y, x] = ' ';
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
