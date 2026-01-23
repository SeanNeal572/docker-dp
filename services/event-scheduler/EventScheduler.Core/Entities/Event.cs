using EventScheduler.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventScheduler.Core.Entities
{
    public class Event
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int Id { get; set; }
        public required DateOnly StartDate { get; set; }
        public required EventFrequency Frequency { get; set; }
        public List<DayOfWeek>? Days { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}; StartDate: {StartDate}; Frequency: {Frequency}; Days: {string.Join(", ", Days ?? [])}";
        }
    }
}
