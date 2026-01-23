using EventScheduler.Core.Commands;
using EventScheduler.Core.Entities;
using EventScheduler.Core.Repositories;
using EventScheduler.Db.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventScheduler.Db.Repositories
{
    public class EventRepository(IAppDbContext dbContext) : IEventRepository
    {
        public IEnumerable<Event> GetEvents()
        {
            return dbContext.Events.AsNoTracking().AsEnumerable();
        }

        public Event? GetEventById(int id)
        {
            return dbContext.Events.AsNoTracking().FirstOrDefault(e => e.Id == id);
        }

        public int SaveEvent(SaveEventCommand command)
        {
            var savedEvent = dbContext.Events.Add(new Event()
            {
                Id = 0,
                Frequency = command.Frequency,
                Days = command.Days,
                StartDate = command.StartDate
            });
            dbContext.SaveChanges();
            return savedEvent.Entity.Id;
        }

        public bool UpdateEvent(int id, UpdateEventCommand command)
        {
            var existingEvent = dbContext.Events.FirstOrDefault(e => e.Id == id);
            if (existingEvent != null)
            {
                existingEvent.Frequency = command.Frequency;
                existingEvent.Days = command.Days;
                existingEvent.StartDate = command.StartDate;
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteEvent(int id)
        {
            var existingEvent = dbContext.Events.FirstOrDefault(e => e.Id == id);
            if (existingEvent != null)
            {
                dbContext.Events.Remove(existingEvent);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
