namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private static Random random = new Random();

        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (var i in this.items)
            {
                if (i.CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            int low = 0;
            int high = this.items.Count;
            while (low < high)
            {
                int mid = ((high - low) / 2) + low;
                if (this.items[mid].CompareTo(item) == 0)
                {
                    return true;
                }
                else if (this.items[mid].CompareTo(item) < 0)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return false;
        }

        public void Shuffle()
        {
            int n = this.items.Count;
            for (int i = 0; i < n; i++)
            {
                int newIndex = random.Next(0, n);
                Swap(i, newIndex);
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }

        private void Swap(int first, int second)
        {
            T temp = this.items[first];
            this.items[first] = this.items[second];
            this.items[second] = temp;
        }
    }
}
