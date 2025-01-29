using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EventsManagement.Models
{
    public class Organizer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Phone]
        public required string Phone { get; set; }

        public ICollection<Event>? Events { get; set; }
    }
}
