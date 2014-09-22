namespace T11to13BasicADTs
{
    using System;

    public class StackArray<T>
    {
        private T[] array;
        private int count;

        public StackArray()
            : this(100)
        {            
        }

        public StackArray(int capacity)
        {
            this.array = new T[capacity];
            this.count = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Clear()
        {
            this.count = 0;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.array[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public T[] ToArray()
        {
            T[] result = new T[this.count];
            Array.Copy(this.array, result, this.count);
            return result;
        }

        public void TrimExcess()
        {
            this.array = this.ToArray();
        }

        public void Push(T element)
        {
            if (this.count == this.array.Length)
            {
                this.Grow();
            }

            this.array[this.count] = element;
            this.count++;
        }

        public T Peek()
        {
            return this.array[this.count - 1];
        }

        public T Pop()
        {
            T result = this.array[this.count - 1];
            this.count--;
            return result;
        }

        private void Grow() 
        {
            int newSize = this.array.Length * 2;
            T[] newArray = new T[newSize];
            Array.Copy(this.array, newArray, this.count);
            this.array = newArray;
        }
    }
}
