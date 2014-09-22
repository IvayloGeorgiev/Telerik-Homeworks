namespace T03_Sorted_Integer_List
{
    using System;
    using System.Collections.Generic;

    public class SortedIntegerList
    {
        private List<int> integersList;

        public SortedIntegerList()
        {
            this.IntegersList = new List<int>();
        }

        public List<int> IntegersList
        {
            get
            {
                return this.integersList;
            }

            private set
            {
                this.integersList = value;
            }
        }

        public void Fill()
        {
            string input = Console.ReadLine();
            while (input != string.Empty)
            {
                int currentInt;
                if (int.TryParse(input, out currentInt))
                {
                    this.IntegersList.Add(currentInt);                    
                }
                else
                {
                    Console.WriteLine("Only enter integers.");
                }

                input = Console.ReadLine();
            }
        }

        public List<int> NormalSort()
        {
            List<int> sorted = new List<int>(this.IntegersList);
            sorted.Sort((first, second) => first.CompareTo(second));            
            return sorted;
        }

        public List<int> CustomSort()
        {
            List<int> sorted = new List<int>();
            foreach (var num in this.IntegersList)
            {
                this.AddToSortedList(num, sorted);
            }

            return sorted;
        }

        private void AddToSortedList(int toAdd, List<int> sorted)
        {
            int index = 0;
            foreach (var item in sorted)
            {
                if (item < toAdd)
                {
                    index++;
                }
                else
                {
                    break;
                }
            }     
       
            sorted.Insert(index, toAdd);
        }
    }
}
