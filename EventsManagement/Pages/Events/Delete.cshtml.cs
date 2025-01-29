using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventsManagement.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EventsManagement.Pages.Events
{
    public class DeleteModel : PageModel
    {
        private readonly EventsManagementDbContext _context;

        public DeleteModel(EventsManagementDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Event Event { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _context.Events.FirstOrDefaultAsync(m => m.Id == id);

            if (result is not null)
            {
                Event = result;
                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _context.Events.FindAsync(id);

            if (result != null)
            {
                Console.WriteLine("Pateu");
                _context.Events.Remove(result);
                _context.SaveChanges();
                Event = result;
                return RedirectToPage("./Index");
            }

            return RedirectToPage("./Index");
        }
    }
}
