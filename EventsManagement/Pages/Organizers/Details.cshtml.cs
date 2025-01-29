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
    public class DetailsModel : PageModel
    {
        private readonly EventsManagement.Models.EventsManagementDbContext _context;

        public DetailsModel(EventsManagement.Models.EventsManagementDbContext context)
        {
            _context = context;
        }

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
    }
}
