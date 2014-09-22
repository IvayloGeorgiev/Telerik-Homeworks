/* Task 1: Write a program that counts in a given array of double values the number of occurrences of each value. Use Dictionary<TKey,TValue>.
 * Task 2: Write a program that extracts from a given sequence of strings all elements that present in it odd number of times. 
 * Task 3: Write a program that counts how many times each word from given text file words.txt appears in it. The character casing differences should be ignored. The result words should be ordered by their number of occurrences in the text. 
 */

namespace T01to03CountingThings
{
    using System;    
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    class EntryPoint
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1:\n");
            var array = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            CoundDoublesArray(array);
            Console.WriteLine("\n-------------------------------------\n");
            Console.WriteLine("Task 2:\n");
            var strings = new string[] {"C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            var oddStrings = ListOddStrings(strings);
            Console.WriteLine("Original strings:");
            Console.WriteLine(string.Join(", ", strings));
            Console.WriteLine("Odd strings:");
            Console.WriteLine(string.Join(", ", oddStrings));
            Console.WriteLine("\n-------------------------------------\n");
            Console.WriteLine("Task 3:\n");
            WordOccurance("..\\..\\text.txt");
        }

        //Task 1;
        private static void CoundDoublesArray(double[] array)
        {            
            Dictionary<double, int> occurances = new Dictionary<double, int>();
            foreach (var element in array)
            {
                if (!occurances.ContainsKey(element))
                {
                    occurances.Add(element, 0);
                }
                occurances[element]++;
            }

            foreach (var key in occurances.Keys)
            {
                Console.WriteLine(key + "->" + occurances[key]);
            }
        }

        //Task 2
        private static IEnumerable<string> ListOddStrings(IEnumerable<string> array)
        {
            Dictionary<string, int> occurances = new Dictionary<string, int>();
            foreach (var element in array)
            {
                if (!occurances.ContainsKey(element))
                {
                    occurances.Add(element, 0);
                }
                occurances[element]++;
            }

            LinkedList<string> oddStrings = new LinkedList<string>();
            foreach (var key in occurances.Keys)
            {
                if ((occurances[key] & 1) != 0)
                {
                    oddStrings.AddLast(key);
                }
            }

            return oddStrings;
        }

        //Task 3
        private static void WordOccurance(string filePath)
        {
            StreamReader reader = new StreamReader(filePath);
            string text = string.Empty;
            using (reader)
            {
                text = reader.ReadToEnd();
            }

            Console.WriteLine("Original text:");
            Console.Write(text);

            string textToLower = text.ToLowerInvariant();
            IEnumerable<string> words = GetWords(textToLower);

            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!wordCount.ContainsKey(word))
                {
                    wordCount.Add(word, 0);
                }

                wordCount[word]++;
            }            

            SortedDictionary<int, List<string>> occurenceSorted = new SortedDictionary<int, List<string>>();
            foreach (var key in wordCount.Keys)
            {
                int occurance = wordCount[key];
                if (!occurenceSorted.ContainsKey(occurance))
                {
                    occurenceSorted[occurance] = new List<string>();
                }
                
                occurenceSorted[occurance].Add(key);
            }

            foreach (var key in occurenceSorted.Keys)
            {
                foreach (var word in occurenceSorted[key])
                {
                    Console.WriteLine("{0} -> {1}", word, key);
                }
            }
        }

        // Task 3.5
        private static IEnumerable<string> GetWords(string text)
        {
            MatchCollection matches = Regex.Matches(text, @"\b[\w']*\b");

            var words = matches.Cast<Match>().Where((m) => !string.IsNullOrEmpty(m.Value)).Select(m => m.Value);            
            return words.ToList();
        }


    }
}
