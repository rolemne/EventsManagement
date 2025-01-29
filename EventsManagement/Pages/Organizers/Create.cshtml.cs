using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EventsManagement.Models;

namespace EventsManagement.Pages.Organizers
{
    public class CreateModel : PageModel
    {
        private readonly EventsManagement.Models.EventsManagementDbContext _context;

        public CreateModel(EventsManagement.Models.EventsManagementDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Organizer Organizer { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Organizers.Add(Organizer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
