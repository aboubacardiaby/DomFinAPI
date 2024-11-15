using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomFinAPI.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }


        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string AccountNumber { get; set; }

        [Required]
        public string AccountType { get; set; }  // e.g., Savings, Checking

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Balance must be non-negative")]
        public decimal Balance { get; set; }

        [Required]
        public int CustomerId { get; set; }

        // Navigation Property
        public Customer Customer { get; set; }
    }
}
