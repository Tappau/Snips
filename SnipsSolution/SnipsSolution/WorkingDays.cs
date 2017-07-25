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
        private static List<DateTime> GetHolidays()
        {
            var client = new WebClient();
            var json = client.DownloadString("https://www.gov.uk/bank-holidays.json");
            var holidays = JsonConvert.DeserializeObject<Dictionary<string,  Holidays>>(json);
            return holidays["england-and-wales"].events.Select(d => d.date).ToList();
        }

        public int GetWorkingDays(DateTime fromDate, DateTime toDate)
        {
            var totalDays = 0;
            var holidays = GetHolidays();

            for (var date = fromDate.AddDays(1); date <= toDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday
                    && !holidays.Contains(date))
                    totalDays++;
            }
            return totalDays;
        }


        public static DateTime AddWorkingDays(DateTime date, int numberOfDays)
        {
            if (numberOfDays < 0)
            {
                throw new ArgumentException("Day's cannot be negative", nameof(numberOfDays));
            }

            if (numberOfDays == 0) return date;

            switch (date.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    date = date.AddDays(2);
                    numberOfDays -= 1;
                    break;
                case DayOfWeek.Sunday:
                    date = date.AddDays(1);
                    numberOfDays -= 1;
                    break;
            }

            date = date.AddDays(numberOfDays/5*7);
            var extraDays = numberOfDays%5;
            if ((int) date.DayOfWeek + extraDays > 5)
            {
                extraDays += 2;
            }

            return date.AddDays(extraDays);
        }

        


        public sealed class Holidays
        {
            public string division { get; set; }
            public List<Event> events { get; set; }
        }

        public sealed class Event
        {
            public DateTime date { get; set; }
            public string notes { get; set; }
            public string title { get; set; }
        }
    }
}