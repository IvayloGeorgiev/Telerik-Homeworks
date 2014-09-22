namespace T03BiDictionary
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;
    
    public class TheDictionary<K1, K2, V>
    {
        private MultiDictionary<K1, V> dict1;
        private MultiDictionary<K2, V> dict2;
        private MultiDictionary<int, V> dict3;
        
        public TheDictionary()
        {
            this.dict1 = new MultiDictionary<K1, V>(true);
            this.dict2 = new MultiDictionary<K2, V>(true);
            this.dict3 = new MultiDictionary<int, V>(true);
        }
    
        public void Add(K1 key1, K2 key2, V element)
        {
            this.dict1.Add(key1, element);
            this.dict2.Add(key2, element);

            var hash = this.GetHashFromTwoKeys(key1, key2);
            this.dict3.Add(hash, element);
        }

        public V[] FindByFirstKey(K1 key1)
        {
            return this.dict1[key1].ToArray();
        }

        public V[] FindBySecondKey(K2 key2)
        {
            return this.dict2[key2].ToArray();
        }

        public V[] FindByBothKeys(K1 key1, K2 key2)
        {
            var hash = this.GetHashFromTwoKeys(key1, key2);
            return this.dict3[hash].ToArray();
        }

        private int GetHashFromTwoKeys(K1 key1, K2 key2)
        {
            return key1.GetHashCode() ^ key2.GetHashCode();
        }
    }
}
