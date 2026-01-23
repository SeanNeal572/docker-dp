using EventScheduler.Core.Entities;
using System.Diagnostics.CodeAnalysis;

namespace EventScheduler.TestInfrastructure.EqualityComparers
{
    public class EventEqualityComparer : IEqualityComparer<Event>
    {
        public readonly static EventEqualityComparer Instance = new();

        public bool Equals(Event? x, Event? y)
        {
            if (x == null || y == null) return x == y;

            return x.Id == y.Id
                && x.Frequency == y.Frequency
                && DaysEqual(x.Days, y.Days)
                && x.StartDate == y.StartDate;
        }

        public int GetHashCode([DisallowNull] Event x)
        {
            unchecked
            {
                int hash = 17;

                hash = hash * 23 + x.Id.GetHashCode();
                hash = hash * 23 + x.Frequency.GetHashCode();
                if (x.Days != null) hash = hash * 23 + x.Days.GetHashCode();
                hash = hash * 23 + x.StartDate.GetHashCode();

                return hash;
            }
        }

        private static bool DaysEqual(List<DayOfWeek>? x, List<DayOfWeek>? y)
        {
            return x == y || x != null && y != null && x.Count == y.Count && x.All(y.Contains);
        }
    }
}
