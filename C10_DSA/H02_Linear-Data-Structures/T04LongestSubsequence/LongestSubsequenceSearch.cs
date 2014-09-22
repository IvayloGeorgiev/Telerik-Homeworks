namespace T04LongestSubsequence
{
    using System;
    using System.Collections.Generic;

    public class LongestSubsequenceSearch : IManipulateList
    {
        public string OperationDescription
        {
            get
            {
                return "longest reapting number subsequence";
            }
        }

        public IEnumerable<int> Manipulate(List<int> sequence)
        {
            Dictionary<int, int> occurances = new Dictionary<int, int>();
            List<int> result = new List<int>();
            int currentMax = 0;
            int currentMaxKey = 0;

            if (sequence.Count < 1)
            {
                throw new ArgumentException("Sequence has no values.");
            }

            foreach (var item in sequence)
            {
                if (occurances.ContainsKey(item))
                {
                    occurances[item]++;
                }
                else
                {
                    occurances.Add(item, 1);
                }

                if (currentMax < occurances[item])
                {
                    currentMax = occurances[item];
                    currentMaxKey = item;
                }
            }

            for (int i = 0; i < currentMax; i++)
            {
                result.Add(currentMaxKey);
            }

            return result;
        }        
    }
}
