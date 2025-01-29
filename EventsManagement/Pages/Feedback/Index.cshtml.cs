using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventsManagement.Models;

namespace EventsManagement.Pages.Feedback
{
    public class IndexModel : PageModel
    {
        private readonly EventsManagement.Models.EventsManagementDbContext _context;

        public IndexModel(EventsManagement.Models.EventsManagementDbContext context)
        {
            _context = context;
        }

        public IList<Models.Feedback> Feedback { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Feedback = await _context.Feedbacks
                .Include(f => f.Event)
                .Include(f => f.Participant).ToListAsync();
        }
    }
}
