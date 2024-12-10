using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeploymentApp.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string? Description { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime? DateIncurred { get; set; }

        public string? Location { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }

        // Expense Type Id (forign key)
        [Display(Name = "Expense Type")]




        public int? ExpenseTypeId { get; set; }
        public ExpenseType ExpenseType { get; set; }




        // User Id
        public int? UserId { get; set; }
    }
}
