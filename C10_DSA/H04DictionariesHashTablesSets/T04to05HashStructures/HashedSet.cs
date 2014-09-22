namespace T04to05HashStructures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class HashedSet<T> : IEnumerable<T>
    {
        private HashTable<T, T> set;

        public HashedSet()
        {
            set = new HashTable<T, T>();
        }

        public int Count
        {
            get
            {
                return this.set.Count;
            }
        }

        public bool Add(T value)
        {
            return set.Add(value, value);
        }

        public T Find(T value)
        {
            return set.Find(value);
        }

        public bool Remove(T value)
        {
            return set.Remove(value);
        }

        public void Clear()
        {
            this.set.Clear();
        }

        public HashedSet<T> Intersect(HashedSet<T> other)
        {
            var result = new HashedSet<T>();
            foreach (var item in this.set)
            {
                if (other.set.Contains(item.Key))
                {
                    result.Add(item.Value);
                }
            }
            return result;
        }

        public HashedSet<T> Union(HashedSet<T> other)
        {
            var result = new HashedSet<T>();
            foreach (var item in this.set)
            {
                result.Add(item.Key);
            }

            foreach (var item in other.set)
            {
                if (!this.set.Contains(item.Key))
                {
                    result.Add(item.Key);
                }
            }

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.set)
            {
                yield return item.Key;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
