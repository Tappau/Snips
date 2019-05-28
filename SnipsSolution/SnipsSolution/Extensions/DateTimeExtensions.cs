using System;
using System.Globalization;

namespace SnipsSolution.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        ///     Checks if date is in future from current time.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsFuture(this DateTime date)
        {
            return date.Date > Clock.Now;
        }

        /// <summary>
        ///     Check if date is in past of current time.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsPast(this DateTime date)
        {
            return date.Date < Clock.Now;
        }

        /// <summary>
        ///     Returns number of month from string representation.
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public static int ToMonthNumber(this string month)
        {
            return Array.FindIndex(CultureInfo.CurrentCulture.DateTimeFormat.MonthNames,
                       mon => mon.Equals(month, StringComparison.CurrentCultureIgnoreCase)) + 1;
        }

        /// <summary>
        ///     Checks if date is between two given datetimes
        /// </summary>
        /// <param name="dt">Datetime to check</param>
        /// <param name="rangeBeg">Earlier Date</param>
        /// <param name="rangeEnd">Older date</param>
        /// <returns>True if between two test values</returns>
        public static bool Between(this DateTime dt, DateTime rangeBeg, DateTime rangeEnd)
        {
            return dt.Ticks >= rangeBeg.Ticks && dt.Ticks <= rangeEnd.Ticks;
        }

        /// <summary>
        ///     Calculates the age of something to the current date
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static int CalculateAge(this DateTime dateTime)
        {
            var age = Clock.Now.Year - dateTime.Year;
            if (DateTime.Now < dateTime.AddYears(age))
                age--;
            return age;
        }

        /// <summary>
        ///     Converts Datetime to a descriptive time elapsed sentance.
        ///     eg. 'one second ago' 'yesterday'
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToReadableTime(this DateTime value)
        {
            var ts = new TimeSpan(Clock.UtcNow.Ticks - value.Ticks);
            var delta = ts.TotalSeconds;
            if (delta < 60) return ts.Seconds == 1 ? "one second ago" : $"{ts.Seconds} seconds ago";
            if (delta < 120) return "a minute ago";
            if (delta < 2700) // 45 * 60
                return $"{ts.Minutes} minutes ago";
            if (delta < 5400) // 90 * 60
                return "an hour ago";
            if (delta < 86400) // 24 * 60 * 60
                return $"{ts.Hours} hours ago";
            if (delta < 172800) // 48 * 60 * 60
                return "yesterday";
            if (delta < 2592000) // 30 * 24 * 60 * 60
                return $"{ts.Days} days ago";
            if (delta < 31104000) // 12 * 30 * 24 * 60 * 60
            {
                var months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : $"{months} months ago";
            }

            var years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
            return years <= 1 ? "one year ago" : $"{years} years ago";
        }

        /// <summary>
        ///     Check if date is a working day.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsWorkingDay(this DateTime date)
        {
            return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
        }

        /// <summary>
        ///     Check if date is a weekend
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsWeekend(this DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        /// <summary>
        ///     Returns the next working day.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime NextWorkDay(this DateTime date)
        {
            DateTime nextDay;
            if (date.IsWorkingDay())
            {
                nextDay = date.AddDays(1);
                while (nextDay.IsWeekend()) nextDay = nextDay.AddDays(1);
                return nextDay;
            }

            nextDay = date.AddDays(1);
            while (nextDay.IsWeekend())
            {
                nextDay = nextDay.AddDays(1);
            }

            return nextDay;
        }

        /// <summary>
        ///     Get the date of the next day of week specified.
        ///     e.g Get the following Tuesday.
        /// </summary>
        /// <param name="current"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime GetNextDay(this DateTime current, DayOfWeek dayOfWeek)
        {
            var offSet = dayOfWeek - current.DayOfWeek;
            if (offSet <= 0) offSet += 7;

            return current.AddDays(offSet);
        }

        /// <summary>
        ///     Returns day number with correct suffix.
        ///     'th', 'st', 'nd', 'rd' to end of the day number.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string OrdinalSuffix(this DateTime date)
        {
            var day = date.Day;
            if (day % 100 >= 11 && day % 100 <= 13) return string.Concat(day, "th");

            switch (day % 10)
            {
                case 1:
                    return $"{day}st";
                case 2:
                    return $"{day}nd";
                case 3:
                    return $"{day}rd";
                default:
                    return $"{day}th";
            }
        }
    }
}