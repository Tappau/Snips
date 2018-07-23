using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnipsSolution.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Checks if date specified is in future.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public static bool IsFuture(this DateTime date, DateTime from)
        {
            return date.Date > from.Date;
        }

        /// <summary>
        /// Checks if date is in future from current time.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsFuture(this DateTime date)
        {
            return date.IsFuture(DateTime.Now);
        }

        /// <summary>
        /// Checks if date is in past. If no parameter checks against current time.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public static bool IsPast(this DateTime date, DateTime from)
        {
            return date.Date < from.Date;
        }

        /// <summary>
        /// Check if date is in past of current time.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsPast(this DateTime date)
        {
            return date.IsPast(DateTime.Now);
        }

        /// <summary>
        /// Returns number of month from string representation.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static int ToMonthNumber(this DateTime dateTime, string month)
        {
            month = month.ToLower();
            for (int i = 1; i <= 12; i++)
            {
                DateTime _dt = DateTime.Parse("1." + i + ".2000");
                string _month = CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(i).ToLower();
                if (_month ==  month)
                {
                    return i;
                }
            }

            return 0;
        }
    }
}
