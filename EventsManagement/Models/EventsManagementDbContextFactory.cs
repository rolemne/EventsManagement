using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EventsManagement.Models
{
    public class EventsManagementDbContextFactory : IDesignTimeDbContextFactory<EventsManagementDbContext>
    {
        public EventsManagementDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EventsManagementDbContext>();

            // Replace with your actual connection string
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\rluci\\source\\repos\\EventsManagement\\EventsManagement\\db\\events-management.mdf;Integrated Security=True;Connect Timeout=30");

            return new EventsManagementDbContext(optionsBuilder.Options);
        }
    }
}