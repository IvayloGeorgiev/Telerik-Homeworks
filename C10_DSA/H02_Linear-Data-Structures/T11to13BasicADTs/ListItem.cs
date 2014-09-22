namespace T11to13BasicADTs
{
    using System;

    public class ListItem<T>
    {
        private T field;
        private ListItem<T> nextField;

        public ListItem(T field)
        {
            this.Field = field;
            this.NextField = null;
        }

        public ListItem(T field, ListItem<T> nextField)
        {
            this.Field = field;
            this.NextField = nextField;
        }

        public T Field
        {
            get
            {
                return this.field;
            }

            set
            {
                this.field = value;
            }
        }

        public ListItem<T> NextField
        {
            get
            {
                return this.nextField;
            }

            set
            {
                this.nextField = value;
            }
        }

        public override string ToString()
        {
            return this.Field.ToString();
        }
    }
}
