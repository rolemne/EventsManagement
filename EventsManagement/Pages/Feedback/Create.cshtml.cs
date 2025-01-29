using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EventsManagement.Models;
using NuGet.Protocol;

namespace EventsManagement.Pages.Feedback
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
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Name");
            ViewData["ParticipantId"] = new SelectList(_context.Participants, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Models.Feedback Feedback { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var attempteEventIdValue = ModelState.GetValueOrDefault("Feedback.EventId");
            var attempteParticipantIdValue = ModelState.GetValueOrDefault("Feedback.ParticipantId");


            if (attempteEventIdValue != null && attempteParticipantIdValue != null)
            {
                var currentEvent = await _context.Events.FindAsync(Int32.Parse(attempteEventIdValue?.AttemptedValue!));
                var currentParticipant = await _context.Participants.FindAsync(Int32.Parse(attempteParticipantIdValue?.AttemptedValue!));
                if (currentEvent != null && currentParticipant != null)
                {
                    Feedback.Event = currentEvent;
                    Feedback.Participant = currentParticipant;
                }
                else
                {
                    ModelState.AddModelError("Feedback.EventId", "Event not found");
                    ModelState.AddModelError("Feedback.ParticipantId", "Participant not found");
                    return Page();
                }
            }

            _context.Feedbacks.Add(Feedback);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
