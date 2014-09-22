namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {            
            BottomUpSort(collection.Count, collection);
        }

        private void BottomUpSort(int n, IList<T> source)
        {
            for (int width = 1; width < n; width++)
            {
                IList<T> worker = new List<T>(n);
                for (int sublistFirst = 0; sublistFirst < n; sublistFirst += 2 * width)
                {
                    BottomUpMerge(source, sublistFirst, Math.Min(sublistFirst + width, n), Math.Min(sublistFirst + 2 * width, n), worker);
                }

                for (int i = 0; i < n; i++)
                {
                    source[i] = worker[i];
                }                
            }
        }

        private void BottomUpMerge(IList<T> source, int leftStart, int rightStart, int width, IList<T> worker)
        {
            int leftIndex = leftStart;
            int rightIndex = rightStart;

            for (int i = leftIndex; i < width; i++)
            {
                if (leftIndex < rightStart && 
                    (rightIndex >= width ||
                    source[leftIndex].CompareTo(source[rightIndex]) < 0))
                {
                    worker.Add(source[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    worker.Add(source[rightIndex]);
                    rightIndex++;
                }
            }
        }
    }
}
