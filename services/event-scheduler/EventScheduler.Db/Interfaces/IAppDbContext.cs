using EventScheduler.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EventScheduler.Db.Interfaces
{
    public interface IAppDbContext
    {
        DatabaseFacade Database { get; }
        DbSet<Event> Events { get; }
        int SaveChanges();
    }
}
