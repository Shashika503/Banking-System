using System.ComponentModel.DataAnnotations;

namespace Banking_System.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }

        public string? AccountHolderName { get; set; }

        public string? AccountType { get; set; }

        [Required]
        public decimal Balance { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        // Default empty collection to prevent null reference issues
        public ICollection<Transaction?> Transactions { get; set; } = new List<Transaction?>();
    }
}
