using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventsManagement.Models;

namespace EventsManagement.Pages.Organizers
{
    public class DeleteModel : PageModel
    {
        private readonly EventsManagement.Models.EventsManagementDbContext _context;

        public DeleteModel(EventsManagement.Models.EventsManagementDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Organizer Organizer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizer = await _context.Organizers.FirstOrDefaultAsync(m => m.Id == id);

            if (organizer is not null)
            {
                Organizer = organizer;

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

            var organizer = await _context.Organizers.FindAsync(id);
            if (organizer != null)
            {
                Organizer = organizer;
                _context.Organizers.Remove(Organizer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
