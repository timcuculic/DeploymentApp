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

namespace DeploymentApp.Pages.Cars
{
    public class EditModel : PageModel
    {
        private readonly DeploymentApp.Data.ProjectContext _context;

        public EditModel(DeploymentApp.Data.ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car =  await _context.Car.FirstOrDefaultAsync(m => m.CarId == id);
            if (car == null)
            {
                return NotFound();
            }
            Car = car;
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

            _context.Attach(Car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(Car.CarId))
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

        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.CarId == id);
        }
    }
}
