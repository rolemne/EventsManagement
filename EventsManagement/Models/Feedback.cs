using System.ComponentModel.DataAnnotations;

namespace EventsManagement.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ParticipantId { get; set; }

        [Required]
        public int EventId { get; set; }

        [Range(1, 5, ErrorMessage = "Rating-ul trebuie să fie între 1 și 5.")]
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime Date { get; set; }
        public Participant? Participant { get; set; }
        public Event? Event { get; set; }
    }
}
