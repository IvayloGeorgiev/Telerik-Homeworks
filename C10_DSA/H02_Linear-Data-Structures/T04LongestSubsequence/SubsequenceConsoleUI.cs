namespace T04LongestSubsequence
{
    using System;
    using System.Collections.Generic;

    public class SubsequenceConsoleUI
    {
        public SubsequenceConsoleUI(IManipulateList operation)
        {
            this.Operation = operation;            
        }

        public IManipulateList Operation { get; set; }        

        public void Start()
        {
            char key = '0';
            while (key != '3')
            {
                this.IntroMessage();
                key = Console.ReadKey().KeyChar;
                Console.WriteLine();
                while (key != '1' && key != '2' && key != '3')
                {
                    Console.WriteLine("Invalid action.");
                    key = Console.ReadKey().KeyChar;
                }
                
                List<int> sequence;
                IEnumerable<int> result;
                switch (key)
                {
                    case '1':
                        sequence = new List<int> { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
                        result = this.Operation.Manipulate(sequence);
                        this.Print(sequence, result);
                        break;
                    case '2':
                        sequence = this.Fill();
                        result = this.Operation.Manipulate(sequence);
                        this.Print(sequence, result);
                        break;
                    case '3':
                        break;
                }
            }
        }

        private void Print(List<int> original, IEnumerable<int> longestEqual)
        {
            if (longestEqual == null)
            {
                return;
            }

            Console.WriteLine("Original sequnce:");
            Console.WriteLine(string.Join(", ", original));
            Console.WriteLine("Modification result:");
            Console.WriteLine(string.Join(", ", longestEqual));
            Console.WriteLine();
        }

        private List<int> Fill()
        {
            List<int> sequence = new List<int>();
            Console.WriteLine("Enter integers for sequence (empty line to stop).");
            string input = Console.ReadLine();
            while (input != string.Empty)
            {
                int currentInt;
                if (int.TryParse(input, out currentInt))
                {
                    sequence.Add(currentInt);
                }
                else
                {
                    Console.WriteLine("Only enter integers.");
                }

                input = Console.ReadLine();
            }

            return sequence;
        }

        private void IntroMessage()
        {
            Console.WriteLine("Select operation:");
            Console.WriteLine("1. Find {0} in preset list.", this.Operation.OperationDescription);
            Console.WriteLine("2. Find {0} in custom list.", this.Operation.OperationDescription);
            Console.WriteLine("3. Exit.");
        }
    }
}
