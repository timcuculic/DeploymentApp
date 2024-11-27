using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DeploymentApp.Data;
using DeploymentApp.Models;

namespace DeploymentApp.Pages.Expenses
{
    public class CreateModel : PageModel
    {
        private readonly DeploymentApp.Data.ProjectContext _context;

        public CreateModel(DeploymentApp.Data.ProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Expense Expense { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Expenses.Add(Expense);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
