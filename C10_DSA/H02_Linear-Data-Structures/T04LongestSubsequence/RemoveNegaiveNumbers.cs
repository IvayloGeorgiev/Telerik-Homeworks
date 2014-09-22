namespace T04LongestSubsequence
{
    using System;
    using System.Collections.Generic;

    public class RemoveNegaiveNumbers : IManipulateList
    {
        public string OperationDescription
        {
            get { return "positive numbers"; }
        }

        public IEnumerable<int> Manipulate(List<int> sequence)
        {
            List<int> result = new List<int>();
            foreach (var num in sequence)
            {
                if (num >= 0)
                {
                    result.Add(num);
                }
            }

            return result;
        }
    }
}
