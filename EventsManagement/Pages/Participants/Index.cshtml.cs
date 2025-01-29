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
    public class IndexModel : PageModel
    {
        private readonly EventsManagement.Models.EventsManagementDbContext _context;

        public IndexModel(EventsManagement.Models.EventsManagementDbContext context)
        {
            _context = context;
        }

        public IList<Participant> Participant { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Participant = await _context.Participants.ToListAsync();
        }
    }
}
