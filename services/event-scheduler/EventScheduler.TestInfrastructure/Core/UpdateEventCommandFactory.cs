using EventScheduler.Core.Commands;
using EventScheduler.Core.Enums;

namespace EventScheduler.TestInfrastructure.Core
{
    public class UpdateEventCommandFactory : BaseFactory<UpdateEventCommandFactory, UpdateEventCommand>
    {
        protected override UpdateEventCommand CreateBaseEntity()
        {
            var frequency = Faker.EnumFaker.SelectFrom<EventFrequency>();
            var days = Enum.GetValues<DayOfWeek>().Where(_ => Faker.BooleanFaker.Boolean()).ToList();

            return new UpdateEventCommand()
            {
                Frequency = frequency,
                Days = frequency == EventFrequency.Weekly ? days : null,
                StartDate = DateOnly.FromDateTime(Faker.DateTimeFaker.DateTime())
            };
        }

    }
}
