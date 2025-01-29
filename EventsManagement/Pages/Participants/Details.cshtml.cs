using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventsManagement.Models;

namespace EventsManagement.Pages.Participants
{
    public class DetailsModel : PageModel
    {
        private readonly EventsManagement.Models.EventsManagementDbContext _context;

        public DetailsModel(EventsManagement.Models.EventsManagementDbContext context)
        {
            _context = context;
        }

        public Participant Participant { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participant = await _context.Participants.FirstOrDefaultAsync(m => m.Id == id);

            if (participant is not null)
            {
                Participant = participant;

                return Page();
            }

            return NotFound();
        }
    }
}
