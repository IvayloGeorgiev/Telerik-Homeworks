namespace T11to13BasicADTs
{
    using System;    

    public class LinkedQueue<T>
    {
        private LinkedList<T> queue;

        public LinkedQueue()
        {
            this.queue = new LinkedList<T>();
        }

        public int Count
        {
            get
            {
                return this.queue.Count();
            }
        }

        public void Enqueue(T element)
        {
            this.queue.AddLast(element);
        }

        public T Dequeue()
        {
            return this.queue.RemoveFirst();
        }

        public T Peek()
        {
            return this.queue.First();
        }

        public void Clear()
        {
            this.queue.Clear();
        }

        public bool Contains(T element)
        {
            ListItem<T> search = this.queue.FirstElement;
            while (search != null)
            {
                if (search.Field.Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public T[] ToArray()
        {
            return this.queue.ToArray();
        }

        // TrimExcess is not necessary.
    }
}
