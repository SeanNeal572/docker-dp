using EventScheduler.Core.Commands;
using EventScheduler.Core.Entities;
using EventScheduler.Core.Enums;

namespace EventScheduler.TestInfrastructure.Core
{
    public class EventFactory : BaseFactory<EventFactory, Event>
    {
        private static int IncrementingId = 1;

        protected override Event CreateBaseEntity()
        {
            var frequency = Faker.EnumFaker.SelectFrom<EventFrequency>();
            var days = Enum.GetValues<DayOfWeek>().Where(_ => Faker.BooleanFaker.Boolean()).ToList();

            return new Event()
            {
                Id = IncrementingId++,
                Frequency = frequency,
                Days = frequency == EventFrequency.Weekly ? days : null,
                StartDate = DateOnly.FromDateTime(Faker.DateTimeFaker.DateTime())
            };
        }

        public EventFactory From(SaveEventCommand command)
        {
            return With(entity =>
            {
                entity.Frequency = command.Frequency;
                entity.Days = command.Days;
                entity.StartDate = command.StartDate;
            });
        }
        public EventFactory From(UpdateEventCommand command)
        {
            return With(entity =>
            {
                entity.Frequency = command.Frequency;
                entity.Days = command.Days;
                entity.StartDate = command.StartDate;
            });
        }

        public EventFactory WithId(int id)
        {
            return With(entity => entity.Id = id);
        }
    }
}
