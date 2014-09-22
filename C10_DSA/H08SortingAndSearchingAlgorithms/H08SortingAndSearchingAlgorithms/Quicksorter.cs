namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {            
            int min = 0;
            int max = collection.Count - 1;            
            Quicksort(collection, min, max);
        }

        private void Quicksort(IList<T> list, int min, int max)
        {            
            if (min < max)
            {
                
                int pivot = ((max - min) / 2) + min;                
                T pivotValue = list[pivot];
                Swap(list, max, pivot);                
                int store = min;
                for (int i = min; i < max; i++)
		        {                    
                    if (list[i].CompareTo(pivotValue) < 0)
                    {
                        Swap(list, i, store);
                        store++;
                    }
		        }
                Swap(list, store, max);                

                Quicksort(list, min, store - 1);
                Quicksort(list, store + 1, max);
            }
        }

        private void Swap(IList<T> list, int first, int second)
        {
            T temp = list[first];
            list[first] = list[second];
            list[second] = temp;
        }
    }
}
