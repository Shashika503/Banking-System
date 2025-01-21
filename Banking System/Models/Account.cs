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
        public required ICollection<Transaction?> Transaction { get; set; }
    }
}
