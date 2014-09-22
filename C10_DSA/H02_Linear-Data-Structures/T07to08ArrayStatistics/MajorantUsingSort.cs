namespace T07to08ArrayStatistics
{
    using System;

    public class MajorantUsingSort : IArrayOperation
    {
        public void Execute(int[] arr)
        {
            if (arr == null || arr.Length < 1)
            {
                throw new ArgumentException("Array must not be empty");
            }

            int[] arrCopy = new int[arr.Length];
            Array.Copy(arr, arrCopy, arr.Length);
            Array.Sort(arrCopy);            

            int curOccurance = 1;
            int bestOccurance = 1;
            int index = 0;
            int majorantCandidate = arrCopy[index];            
            do
            {
                if (index == arrCopy.Length - 1)
                {
                    break;
                }
                else if (arrCopy[index] == arrCopy[index + 1])
                {
                    curOccurance += 1;                    
                }
                else
                {
                    curOccurance = 1;
                }

                if (curOccurance > bestOccurance)
                {
                    bestOccurance = curOccurance;
                    majorantCandidate = arrCopy[index];
                }

                index++;
            }
            while (index < arrCopy.Length);

            Console.WriteLine("Original array:");
            Console.WriteLine(string.Join(", ", arr));

            if (bestOccurance >= ((arrCopy.Length / 2) + 1))
            {                
                Console.WriteLine("Majorant is {0}", majorantCandidate);
            }
            else
            {
                Console.WriteLine("No majorant found.");
            }

            Console.WriteLine("\n------------------\n");
        }
    }
}
