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
    public class IndexModel : PageModel
    {
        private readonly DeploymentApp.Data.ProjectContext _context;

        public IndexModel(DeploymentApp.Data.ProjectContext context)
        {
            _context = context;
        }

        public IList<ExpenseType> ExpenseType { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ExpenseType = await _context.ExpenseTypes.ToListAsync();
        }
    }
}
