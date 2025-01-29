using Microsoft.EntityFrameworkCore;
using System;

namespace EventsManagement.Models;

public class EventsManagementDbContext : DbContext
{
    public EventsManagementDbContext(DbContextOptions<EventsManagementDbContext> options)
            : base(options)
    {
    }

    public DbSet<Event> Events { get; set; }
    public DbSet<Participant> Participants { get; set; }
    public DbSet<Organizer> Organizers{ get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Feedback>()
            .HasOne(f => f.Participant)
            .WithMany(p => p.Feedbacks)
            .HasForeignKey(f => f.ParticipantId);

        modelBuilder.Entity<Feedback>()
            .HasOne(f => f.Event)
            .WithMany(e => e.Feedbacks)
            .HasForeignKey(f => f.EventId);
    }
}
