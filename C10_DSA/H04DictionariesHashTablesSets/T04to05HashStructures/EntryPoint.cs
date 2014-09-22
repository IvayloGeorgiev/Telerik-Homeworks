namespace T04to05HashStructures
{
    using System;

    class EntryPoint
    {
        static void Main(string[] args)
        {
            HashTable<string, int> peopleWithAge = new HashTable<string, int>();
            peopleWithAge.Add("Pencho", 25);
            Console.WriteLine(peopleWithAge.Find("Pencho"));
            Console.WriteLine(string.Join(", ", peopleWithAge.Keys));
            peopleWithAge.Add("Penka", 30);
            peopleWithAge.Add("Horka", 60);
            foreach (var item in peopleWithAge)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }

            Console.WriteLine(peopleWithAge.Count);
            peopleWithAge.Clear();
            Console.WriteLine("Cleared");
            peopleWithAge.Add("Gosho", 30);
            foreach (var item in peopleWithAge)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
            peopleWithAge.Add("Giro", 23);
            peopleWithAge.Remove("Gosho");
            foreach (var item in peopleWithAge)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
            Console.WriteLine(peopleWithAge["Giro"]);

            Console.WriteLine("\n---------------------------------------------\n");
            HashedSet<int> stuff = new HashedSet<int>();
            for (int i = 0; i < 5; i++)
            {
                stuff.Add(i);
            }

            Console.WriteLine(stuff.Count);
            Console.WriteLine(stuff.Find(2));
            Console.WriteLine(string.Join(", ", stuff));
            
            HashedSet<int> otherStuff = new HashedSet<int>();
            for (int i = 3; i < 10; i++)
            {
                otherStuff.Add(i);
            }

            Console.WriteLine(string.Join(", ", otherStuff));
            Console.WriteLine(otherStuff.Count);
            Console.WriteLine(stuff.Union(otherStuff).Count);
            Console.WriteLine(string.Join(", ", stuff.Union(otherStuff)));
            Console.WriteLine(stuff.Intersect(otherStuff).Count);
            Console.WriteLine(string.Join(", ", stuff.Intersect(otherStuff)));
        }
    }
}
