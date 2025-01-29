using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventsManagement.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol;

namespace EventsManagement.Pages.Feedback
{
    public class DetailsModel : PageModel
    {
        private readonly EventsManagement.Models.EventsManagementDbContext _context;

        public DetailsModel(EventsManagement.Models.EventsManagementDbContext context)
        {
            _context = context;
        }

        public Models.Feedback Feedback { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedbacks
                .Include(f => f.Event)
                .Include(f => f.Participant)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (feedback is not null)
            {
                Feedback = feedback;
                return Page();
            }

            return NotFound();
        }
    }
}
