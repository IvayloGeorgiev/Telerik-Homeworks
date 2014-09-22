namespace T04LongestSubsequence
{
    using System.Collections.Generic;

    public interface IManipulateList
    {
        string OperationDescription { get; }

        IEnumerable<int> Manipulate(List<int> sequence);        
    }
}
