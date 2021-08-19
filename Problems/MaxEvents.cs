using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeProblems.Problems
{
    public class Event
    {
        public int StartDay { get; set; }
        public int EndDay { get; set; }
    }

    public class MaxEvents
    {
        public static void Start()
        {
            List<int> arrival = new List<int> { 1, 3, 3, 5, 7 };
            List<int> duration = new List<int> { 2, 2, 1, 2, 1 };
            int count = maxEvents(arrival, duration);
            Console.WriteLine(count);
        }

        public static int maxEvents(List<int> arrival, List<int> duration)
        {
            int maxStartDay = arrival.OrderByDescending(a => a).First();
            int maxArrivalDayIndex = arrival.IndexOf(maxStartDay);
            int maxDay = maxStartDay + duration[maxArrivalDayIndex] - 1;

            List<Event> events = new List<Event>();
            for (int i = 0; i < arrival.Count(); i++)
            {
                Event evt = new Event
                {
                    StartDay = arrival[i],
                    EndDay = arrival[i] + duration[i] - 1
                };

                events.Add(evt);
            }

            List<Event> attendedEvents = new List<Event>();
            for (int day = 1; day <= maxDay; day++)
            {
                Event evt = events.Where(e => day >= e.StartDay && day <= e.EndDay && !attendedEvents.Contains(e)).OrderBy(e => e.EndDay).FirstOrDefault();
                if (evt != null)
                {
                    attendedEvents.Add(evt);
                }
            }
            return attendedEvents.Count();
        }
    }
}