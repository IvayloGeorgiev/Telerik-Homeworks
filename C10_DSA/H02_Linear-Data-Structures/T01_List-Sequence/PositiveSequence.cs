namespace T01_List_Sequence
{
    using System;
    using System.Collections.Generic;

    public class PositiveSequence
    {
        private readonly Fill fill;
        private IList<int> sequence;        

        public PositiveSequence(Fill filler)
        {
            this.sequence = new List<int>();
            this.fill = new Fill(filler);
        }

        protected IList<int> Sequence
        {
            get
            {
                return this.sequence;
            }

            set
            {
                this.sequence = value;
            }
        }

        public void Fill()
        {
            this.Sequence = this.fill();            
        }

        public double Average()
        {
            double result = this.Sum();
            if (this.Sequence.Count > 0) 
            {
                return result / this.Sequence.Count;
            }
            else
            {
                return 0;
            }
        }

        public long Sum()
        {
            long result = 0;
            foreach (var number in this.Sequence)
            {
                result += number;
            }

            return result;
        }
    }
}
