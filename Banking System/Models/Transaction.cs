using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Banking_System.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Required]
        public int AccountId { get; set; }

        [Required]
        public string TransactionType { get; set; }

        [Required]
        public Decimal Amount { get; set; }

        public Account? Account { get; set; }

    }
}
