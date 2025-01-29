using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventsManagement.Models;

namespace EventsManagement.Pages.Events
{
    public class DetailsModel : PageModel
    {
        private readonly EventsManagementDbContext _context;

        public DetailsModel(EventsManagementDbContext context)
        {
            _context = context;
        }

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
    }
}
