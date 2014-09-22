namespace T07to08ArrayStatistics
{
    using System;
    using System.Collections.Generic;

    public class ArrayStatsUI
    {
        public ArrayStatsUI(IArrayOperation operation)
        {
            this.Operation = operation;
        }

        public IArrayOperation Operation { get; set; }

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

                int[] sequence;
                switch (key)
                {
                    case '1':
                        sequence = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
                        this.Operation.Execute(sequence);                        
                        break;
                    case '2':
                        sequence = this.Fill();
                        this.Operation.Execute(sequence);
                        break;
                    case '3':
                        Console.WriteLine("\n +++++++++++++++++++++++++++++ \n");
                        break;
                }
            }
        }
        
        private int[] Fill()
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

            return sequence.ToArray();
        }

        private void IntroMessage()
        {
            Console.WriteLine("Select operation:");
            Console.WriteLine("1. Execute operation on preset array.");
            Console.WriteLine("2. Execute operation on custom array.");
            Console.WriteLine("3. Exit.");
        }
    }
}
