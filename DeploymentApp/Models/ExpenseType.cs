using System.ComponentModel.DataAnnotations;

namespace DeploymentApp.Models
{
    public class ExpenseType
    {
        public int ExpenseTypeId { get; set; }

        [Display(Name = "Expense Type")]
        public string Name { get; set; }
    }
}
