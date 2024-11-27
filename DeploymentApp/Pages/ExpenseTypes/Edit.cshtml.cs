using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeploymentApp.Data;
using DeploymentApp.Models;

namespace DeploymentApp.Pages.ExpenseTypes
{
    public class EditModel : PageModel
    {
        private readonly DeploymentApp.Data.ProjectContext _context;

        public EditModel(DeploymentApp.Data.ProjectContext context)
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

            var expensetype =  await _context.ExpenseTypes.FirstOrDefaultAsync(m => m.ExpenseTypeId == id);
            if (expensetype == null)
            {
                return NotFound();
            }
            ExpenseType = expensetype;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ExpenseType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseTypeExists(ExpenseType.ExpenseTypeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ExpenseTypeExists(int id)
        {
            return _context.ExpenseTypes.Any(e => e.ExpenseTypeId == id);
        }
    }
}
