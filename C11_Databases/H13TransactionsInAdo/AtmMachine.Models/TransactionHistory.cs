namespace AtmMachine.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public class TransactionHistory
    {
        public int Id { get; set; }

        [MinLength(10)]
        [MaxLength(10)]
        public string CardNumber { get; set; }

        public DateTime TransactionDate { get; set; }

        [Column(TypeName="money")]
        public decimal Amount { get; set; }
    }
}
