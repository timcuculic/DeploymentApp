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
    public class DeleteModel : PageModel
    {
        private readonly DeploymentApp.Data.ProjectContext _context;

        public DeleteModel(DeploymentApp.Data.ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expensetype = await _context.ExpenseTypes.FindAsync(id);
            if (expensetype != null)
            {
                ExpenseType = expensetype;
                _context.ExpenseTypes.Remove(ExpenseType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
