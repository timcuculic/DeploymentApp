using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DeploymentApp.Data;
using DeploymentApp.Models;

namespace DeploymentApp.Pages.ExpenseTypes
{
    public class DetailsModel : PageModel
    {
        private readonly DeploymentApp.Data.ProjectContext _context;

        public DetailsModel(DeploymentApp.Data.ProjectContext context)
        {
            _context = context;
        }

        public ExpenseType ExpenseType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expensetype = await _context.ExpenseTypes.FirstOrDefaultAsync(m => m.ExpenseTypeId == id);
            if (expensetype == null)
            {
                return NotFound();
            }
            else
            {
                ExpenseType = expensetype;
            }
            return Page();
        }
    }
}
