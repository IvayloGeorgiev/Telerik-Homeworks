namespace T04LongestSubsequence
{
    using System;
    using System.Collections.Generic;

    public class RemovedOddNumbers : IManipulateList
    {
        public string OperationDescription
        {
            get { return "even numbers"; }
        }

        public IEnumerable<int> Manipulate(List<int> sequence)
        {
            List<int> result = new List<int>();
            foreach (var num in sequence)
            {
                if ((num & 1) == 0)
                {
                    result.Add(num);
                }
            }

            return result;
        }
    }
}
