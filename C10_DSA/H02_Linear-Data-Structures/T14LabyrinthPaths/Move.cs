namespace T14LabyrinthPaths
{
    public class Move
    {
        private Position pos;
        private int count;

        public Move(Position pos, int count)
        {
            this.pos = pos;
            this.count = count;
        }

        public Move(Move move)
        {
            this.pos = new Position(move.pos);
            this.count = move.count;
        }

        public Position Pos
        {
            get
            {
                return this.pos;
            }

            set
            {
                this.pos = value;
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }

            set
            {
                this.count = value;
            }
        }
    }
}
