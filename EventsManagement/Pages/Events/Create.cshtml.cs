using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EventsManagement.Models;
using NuGet.Protocol;

namespace EventsManagement.Pages.Events
{
    public class CreateModel : PageModel
    {
        private readonly EventsManagementDbContext _context;

        public CreateModel(EventsManagementDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Event Event { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync() 
        { 
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Events.Add(Event);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
