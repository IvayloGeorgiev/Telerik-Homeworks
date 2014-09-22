namespace T14LabyrinthPaths
{
    public class Position
    {
        private int x;
        private int y;

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Position(Position pos)
        {
            this.X = pos.X;
            this.Y = pos.Y;
        }

        public int X
        {
            get
            {
                return this.x;
            }

            set
            {
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }

            set
            {
                this.y = value;
            }
        }

        public static bool operator ==(Position a, Position b)
        {
            bool result = (a.X == b.X) && (a.Y == b.Y);
            return result;
        }

        public static bool operator !=(Position a, Position b)
        {
            bool result = (a.X != b.X) || (a.Y != b.Y);
            return result;
        }

        public static Position operator +(Position a, Position b)
        {
            Position result = new Position(a.X + b.X, a.Y + b.Y);
            return result;
        }

        public override bool Equals(object obj)
        {
            Position pos = obj as Position;
            if (pos == null)
            {
                return false;            
            }            
            else if (pos.X != this.X || pos.Y != this.Y)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return this.x.GetHashCode() ^ this.y.GetHashCode();
        }
    }
}
