using EventScheduler.Core.Commands;
using EventScheduler.Core.Entities;

namespace EventScheduler.Core.Repositories
{
    public interface IEventRepository
    {
        public Event? GetEventById(int id);
        public IEnumerable<Event> GetEvents();
        public int SaveEvent(SaveEventCommand command);
        public bool UpdateEvent(int id, UpdateEventCommand command);
        public bool DeleteEvent(int id);
    }
}
