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
    public class IndexModel : PageModel
    {
        private readonly EventsManagementDbContext _context;

        public IndexModel(EventsManagementDbContext context)
        {
            _context = context;
        }

        public IList<Event> Event { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Event = await _context.Events.ToListAsync();
        }
    }
}
