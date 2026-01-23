using EventScheduler.Core.Enums;

namespace EventScheduler.Core.Commands
{
    public class UpdateEventCommand
    {
        public required DateOnly StartDate { get; set; }
        public required EventFrequency Frequency { get; set; }
        public List<DayOfWeek>? Days { get; set; }
    }
}
