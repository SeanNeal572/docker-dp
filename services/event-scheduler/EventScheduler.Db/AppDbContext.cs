using EventScheduler.Core.Entities;
using EventScheduler.Db.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventScheduler.Db
{
    public abstract class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Event> Events { get; set; }
    }
}
