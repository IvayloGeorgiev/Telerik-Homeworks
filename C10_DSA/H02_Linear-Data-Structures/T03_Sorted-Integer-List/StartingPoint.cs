namespace T03_Sorted_Integer_List
{
    using System;

    public class StartingPoint
    {
        public static void Main(string[] args)
        {
            SortedIntegerList list = new SortedIntegerList();
            Console.WriteLine("Enter numbers for the array (to end, enter an empty line):");
            list.Fill();
            Console.WriteLine("Original list: ");
            Console.WriteLine(string.Join(", ", list.IntegersList));
            Console.WriteLine("Sorted list using custom:");
            Console.WriteLine(string.Join(", ", list.CustomSort()));
            Console.WriteLine("Sorted list using built in sort:");
            Console.WriteLine(string.Join(", ", list.NormalSort()));
        }
    }
}
