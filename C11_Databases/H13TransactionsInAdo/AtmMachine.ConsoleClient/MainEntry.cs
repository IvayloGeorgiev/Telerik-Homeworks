namespace AtmMachine.ConsoleClient
{
    using System;
    using System.Linq;
    using System.Transactions;    

    using AtmMachine.Data;
    using AtmMachine.Models;    

    public class MainEntry
    {
        public static void Main(string[] args)
        {
            var data = new AtmData();

            var accounts = data.CardAccounts.All();

            foreach (var account in accounts)
            {
                Console.WriteLine(string.Format("CardNum: {0}\n Available: {1}", account.CardNumber, account.CardCash));
            }

            RetrieveMoney("1111111111", "0000", 200);
        }

        //You need to have the Distribute Transaction Coordinator service enabled for this code to work.
        private static void RetrieveMoney(string cardNumber, string pinNumber, decimal amount)
        {
            using (var tranScope = new TransactionScope())
            {
                var data = new AtmData();
                var match = data.CardAccounts
                    .SearchFor(x => x.CardNumber == cardNumber && x.CardPin == pinNumber)
                    .FirstOrDefault();                

                if (match != null && match.CardCash > amount)
                {                    
                    match.CardCash -= amount;                    
                    SaveToHistory(cardNumber, DateTime.Now, amount);
                }

                data.SaveChanges();
                tranScope.Complete();
            }
        }

        private static void SaveToHistory(string cardNumber, DateTime date, decimal amount)
        {
            using (var tranScope = new TransactionScope())
            {
                var data = new AtmData();
                TransactionHistory entry = new TransactionHistory()
                {
                    CardNumber = cardNumber,
                    TransactionDate = date,
                    Amount = amount
                };

                data.TransactionHistorys.Add(entry);
                data.SaveChanges();
                tranScope.Complete();
            }
        }
    }
}
