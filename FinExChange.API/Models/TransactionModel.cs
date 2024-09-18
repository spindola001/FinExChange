using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinExChange.API.Models
{
    [Table("Transaction")]
    public class TransactionModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        [Required]
        public DateTime DateUpdate { get; set; }

        public string? Description { get; set; }
    }
}
