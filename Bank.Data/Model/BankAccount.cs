using Common.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Data.Model
{
    public class BankAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(13)]
        public int AccountHolderIdNumber { get; set; }

        public string? AccountHolderFirstName { get; set; }

        public string? AccountHolderLastName { get; set; }

        [Required]
        [MaxLength(25)]
        public int  AccountNumber { get; set; }

        [Required]
        [MaxLength(25)]
        public AccountType AccountType { get; set; }

        [Required]
        [MaxLength(25)]
        public string? AccountName { get; set; }

        [Required]
        [MaxLength(25)]
        public AccountStatus AccountStatus { get; set; }

        public decimal AccountBalance { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
