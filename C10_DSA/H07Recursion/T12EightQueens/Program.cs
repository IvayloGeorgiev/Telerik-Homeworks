using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T12EightQueens
{
    class Program
    {
        private static bool[,] field;

        static void Main(string[] args)
        {
            int result = 0;
            int size = 8;
            field = new bool[size, size];
            SolveRecursive(0, size, ref result);
            Console.WriteLine(result);
        }

        private static void SolveRecursive(int row, int size, ref int result)
        {
            for (int i = 0; i < size; i++)
            {
                if (CheckFields(row, i, size))
                {
                    if (row == size - 1)
                    {
                        result++;
                    }
                    else
                    {
                        field[row, i] = true;
                        SolveRecursive(row + 1, size, ref result);
                    }

                    field[row, i] = false;
                }
            }
        }

        private static bool CheckFields(int row, int col, int size)
        {
            for (int i = 0; i < size; i++)
            {
                if (field[i, col])
                {
                    return false;
                }
                else if (row - i >= 0 && col - i >= 0 && field[row - i, col - i])
                {
                    return false;
                }
                else if (row - i >= 0 && col + i < size && field[row - i, col + i])
                {
                    return false;
                }
                else if (row + i < size && col - i >= 0 && field[row + i, col - i])
                {
                    return false;
                }
                else if (row + i < size && col + i < size && field[row + i, col + i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
