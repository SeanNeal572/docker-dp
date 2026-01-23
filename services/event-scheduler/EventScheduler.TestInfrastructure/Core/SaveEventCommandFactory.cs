using EventScheduler.Core.Commands;
using EventScheduler.Core.Enums;

namespace EventScheduler.TestInfrastructure.Core
{
    public class SaveEventCommandFactory : BaseFactory<SaveEventCommandFactory, SaveEventCommand>
    {
        protected override SaveEventCommand CreateBaseEntity()
        {
            var frequency = Faker.EnumFaker.SelectFrom<EventFrequency>();
            var days = Enum.GetValues<DayOfWeek>().Where(_ => Faker.BooleanFaker.Boolean()).ToList();

            return new SaveEventCommand()
            {
                Frequency = frequency,
                Days = frequency == EventFrequency.Weekly ? days : null,
                StartDate = DateOnly.FromDateTime(Faker.DateTimeFaker.DateTime())
            };
        }
    }
}
