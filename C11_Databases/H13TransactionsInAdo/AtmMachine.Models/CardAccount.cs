namespace AtmMachine.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CardAccount
    {        
        public int Id { get; set; }
        
        [MinLength(10)]
        [MaxLength(10)]
        public string CardNumber { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        public string CardPin { get; set; }

        [Column(TypeName="money")]
        public decimal CardCash { get; set; }
    }
}
