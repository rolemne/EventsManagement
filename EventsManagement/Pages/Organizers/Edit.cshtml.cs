using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventsManagement.Models;

namespace EventsManagement.Pages.Organizers
{
    public class EditModel : PageModel
    {
        private readonly EventsManagement.Models.EventsManagementDbContext _context;

        public EditModel(EventsManagement.Models.EventsManagementDbContext context)
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

            var organizer =  await _context.Organizers.FirstOrDefaultAsync(m => m.Id == id);
            if (organizer == null)
            {
                return NotFound();
            }
            Organizer = organizer;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Organizer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizerExists(Organizer.Id))
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

        private bool OrganizerExists(int id)
        {
            return _context.Organizers.Any(e => e.Id == id);
        }
    }
}
