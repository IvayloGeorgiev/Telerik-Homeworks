namespace T04to05HashStructures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;


    public class HashTable<K, T> : IEnumerable<KeyValuePair<K, T>>
    {
        private const int InitialCapacity = 16;

        private LinkedList<KeyValuePair<K, T>>[] table;
        private int capacity;
        private int count;
        private List<K> keys;

        public HashTable()
            : this(InitialCapacity)
        {
        }

        public HashTable(int capacity)
        {
            this.capacity = capacity;
            this.count = 0;
            this.table = new LinkedList<KeyValuePair<K,T>>[capacity];
            this.keys = new List<K>();
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public K[] Keys
        {
            get
            {
                return this.keys.ToArray();
            }
        }

        public bool Add(K key, T value)
        {
            if (this.count / (double)this.capacity > 0.75)
            {
                this.Resize();
            }

            int hash = Math.Abs(key.GetHashCode() % capacity);
            var keyPair = new KeyValuePair<K, T>(key, value);            
            if (this.table[hash] == null)
            {
                this.table[hash] = new LinkedList<KeyValuePair<K, T>>();                                
            }

            if (this.Contains(key))
            {
                return false;
            }

            this.table[hash].AddFirst(keyPair);
            this.keys.Add(key);
            this.count++;
            return true;
        }

        public T Find(K key)
        {
            int hash = Math.Abs(key.GetHashCode() % capacity);
            if (this.table[hash] == null)
            {
                return default(T);
            }
            foreach (var item in this.table[hash])
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(T);
        }

        public bool Remove(K key)
        {
            int hash = Math.Abs(key.GetHashCode() % capacity);
            var node = this.table[hash].First;
            while (node != null)
            {
                if (node.Value.Key.Equals(key))
                {
                    this.table[hash].Remove(node);
                    this.count--;
                    return true;
                }
                node = node.Next;
            }
            return false;
        }

        public void Clear()
        {
            this.keys = new List<K>();
            this.table = new LinkedList<KeyValuePair<K,T>>[InitialCapacity];
            this.count = 0;
            this.capacity = InitialCapacity;
        }

        public T this[K key]
        {
            get
            {
                return this.Find(key);
            }
        }        

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            foreach (var list in this.table)
            {
                if (list == null)
                {
                    continue;
                }
                foreach (var pair in list)
                {
                    yield return pair;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Resize()
        {
            int newCapacity = this.capacity * 2;
            LinkedList<KeyValuePair<K, T>>[] newTable = new LinkedList<KeyValuePair<K, T>>[newCapacity];
            foreach (var list in this.table)
            {
                foreach (var item in list)
                {
                    int newHash = Math.Abs(item.Key.GetHashCode() % newCapacity);
                    if (newTable[newHash] == null)
                    {
                        newTable[newHash] = new LinkedList<KeyValuePair<K, T>>();
                    }
                    newTable[newHash].AddFirst(item);
                }
            }

            this.capacity = newCapacity;
            this.table = newTable;
        }

        public bool Contains(K key)
        {
            int hash = Math.Abs(key.GetHashCode() % capacity);
            if (this.table[hash] == null)
            {
                return false;
            }

            foreach (var item in this.table[hash])
            {
                if (item.Key.Equals(key))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
