using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EventsManagement.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }
        public required string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public required DateTime Date { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Capacitatea trebuie să fie mai mare decât 0.")]
        public required int Capacity { get; set; }

        [StringLength(200)]
        public required string Location { get; set; }

        public ICollection<Participant>? Participants { get; set; }
        public ICollection<Feedback>? Feedbacks { get; set; }
    }
}
