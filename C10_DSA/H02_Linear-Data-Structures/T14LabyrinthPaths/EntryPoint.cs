namespace T14LabyrinthPaths
{
    using System;
    using System.Collections.Generic;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            Labyrinth lab = new Labyrinth(6);
            List<Position> forbidden = new List<Position>()
            {
                new Position(3, 0),
                new Position(5, 0),
                new Position(1, 1),
                new Position(3, 1),
                new Position(5, 1),
                new Position(2, 2),
                new Position(4, 2),
                new Position(1, 3),
                new Position(3, 4),
                new Position(4, 4),
                new Position(3, 5),
                new Position(5, 5),
            };
            foreach (var item in forbidden)
            {
                lab.AddForbidenSquare(item);
            }

            lab.AnalyzePaths(new Position(1, 2));
            lab.Clear();
            Console.WriteLine("\n--------------------------------------\n");
            lab.AnalyzePaths(new Position(1, 2));
            Console.WriteLine("\n--------------------------------------\n");
            foreach (var item in forbidden)
            {
                lab.AddForbidenSquare(item);
            }

            lab.AnalyzePaths(new Position(1, 2));
        }
    }
}
