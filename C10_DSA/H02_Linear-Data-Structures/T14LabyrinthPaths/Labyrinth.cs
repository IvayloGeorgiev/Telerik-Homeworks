namespace T14LabyrinthPaths
{
    using System;
    using System.Collections.Generic;

    public class Labyrinth
    {
        private int[,] labyrinth;
        private int size;

        public Labyrinth(int n)
        {
            this.labyrinth = new int[n, n];
            this.size = n;
        }

        public int Size
        {
            get
            {
                return this.size;
            }
        }

        public bool AddForbidenSquare(Position pos)
        {
            if (!this.PositionIsValid(pos))
            {
                throw new ArgumentException("x and y must be within the size of the labyrinth.");
            }

            if (this.labyrinth[pos.Y, pos.X] == -1)
            {
                return false;
            }

            this.labyrinth[pos.Y, pos.X] = -1;
            return true;
        }

        public void AnalyzePaths(Position start)
        {
            if (!this.PositionIsValid(start))
            {
                throw new ArgumentException("Starting positions must be within the size of the labyrinth.");
            }
            else if (this.labyrinth[start.X, start.Y] == -1)
            {
                throw new ArgumentException("Starting position must not be a forbidden square.");
            }

            this.Reset();
            this.Traverse(start);
            this.Print(start);
        }

        public void Reset()
        {
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    if (this.labyrinth[i, j] != -1)
                    {
                        this.labyrinth[i, j] = 0;
                    }
                }
            }
        }

        public void Clear()
        {
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    this.labyrinth[i, j] = 0;
                }
            }
        }

        private void Traverse(Position start)
        {
            Queue<Move> traverser = new Queue<Move>();
            traverser.Enqueue(new Move(start, 0));
            List<Position> possibleMoves = new List<Position>() { new Position(0, 1), new Position(0, -1), new Position(1, 0), new Position(-1, 0) };
            while (traverser.Count > 0)
            {                                
                Move curMove = traverser.Dequeue();                
                if ((this.GetPositionValue(curMove.Pos) <= curMove.Count && this.GetPositionValue(curMove.Pos) > 0) || (curMove.Pos == start && curMove.Count > 0))
                {
                    continue;
                }
                
                this.SetPositionValue(curMove.Pos, curMove.Count);
                foreach (var offset in possibleMoves)
                {
                    Position newPos = curMove.Pos + offset;                    
                    if (this.PositionIsValid(newPos) && this.PositionIsPossible(newPos) && this.PositionIsBetter(newPos, curMove.Count + 1))
                    {
                        traverser.Enqueue(new Move(newPos, curMove.Count + 1));
                    }
                }
            }            
        }

        private void Print(Position start)
        {
            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    int val = this.labyrinth[i, j];
                    if (val > 0)
                    {
                        Console.Write("{0} ", val);
                    }
                    else if (val == 0)
                    {
                        if (new Position(j, i) == start)
                        {
                            Console.Write("* ");
                        }
                        else
                        {
                            Console.Write("u ");
                        }
                    }
                    else if (val == -1)
                    {
                        Console.Write("x ");
                    }
                }

                Console.WriteLine();
            }
        }

        private bool PositionIsValid(Position check)
        {
            if (check.X < 0 || check.X >= this.size || check.Y < 0 || check.Y >= this.size)
            {
                return false;
            }

            return true;
        }

        private int GetPositionValue(Position pos)
        {
            return this.labyrinth[pos.Y, pos.X];
        }

        private void SetPositionValue(Position pos, int value)
        {
            this.labyrinth[pos.Y, pos.X] = value;
        }

        private bool PositionIsPossible(Position check)
        {
            bool result = this.labyrinth[check.Y, check.X] >= 0;
            return result;
        }

        private bool PositionIsBetter(Position pos, int value)
        {
            int oldValue = this.GetPositionValue(pos);
            return (oldValue == 0) || (oldValue > value && oldValue > 0);
        }
    }
}
