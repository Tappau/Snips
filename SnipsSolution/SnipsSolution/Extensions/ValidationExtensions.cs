using System;
using System.Globalization;

namespace SnipsSolution.Extensions
{
    public static class ValidationExtensions
    {

        /// <summary>
        /// Checks of object is null.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Returns true if null, otherwise false.</returns>
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        /// <summary>
        /// Returns a new Guid if empty. Otherwise does nothing
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Guid NewGuidIfEmpty(this Guid value)
        {
            return (value != Guid.Empty ? value : Guid.NewGuid());
        }

        /// <summary>
        /// Check if a given date is UK format.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsUkDateFormat(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) { throw new ArgumentNullException(nameof(value), $"{nameof(value)} cannot be null, whitespace or empty."); }

            string[] validFormats = { "dd/MM/yyyy", "dd/MM/yy", "MM/yy", "MM/yyyy", "d/M/yy", "d/M/yyyy", "dd/M/yy", "dd/M/yyyy" };
            return DateTime.TryParseExact(value, validFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }


    }
}
