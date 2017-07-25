using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

// ReSharper disable InconsistentNaming

namespace SnipsSolution
{
    public class WorkingDays
    {
        public List<DateTime> GetHolidays()
        {
            var client = new WebClient();
            var json = client.DownloadString("https://www.gov.uk/bank-holidays.json");
            var holidays = JsonConvert.DeserializeObject<Dictionary<string, Holidays>>(json);
            return holidays["england-and-wales"].events.Select(d => d.date).ToList();
        }

        public int GetWorkingDays(DateTime from, DateTime to)
        {
            var totalDays = 0;
            var holidays = GetHolidays();
            for (var date = from.AddDays(1); date <= to; date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday
                    && !holidays.Contains(date))
                    totalDays++;
            }
            return totalDays;
        }


        public class Holidays
        {
            public string division { get; set; }
            public List<Event> events { get; set; }
        }

        public class Event
        {
            public DateTime date { get; set; }
            public string notes { get; set; }
            public string title { get; set; }
        }
    }
}