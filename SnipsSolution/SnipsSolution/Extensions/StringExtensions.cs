using System;
namespace SnipsSolution.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns characters from the right of a specified string.
        /// </summary>
        /// <returns>Returns string from right.</returns>
        /// <param name="value">String value.</param>
        /// <param name="length">Max number of of characters to return</param>
        public static string Right(this string value, int length = 0){
            if (value == null) throw new ArgumentNullException(nameof(value));

            return value != null && value.Length > length ? value.Substring(value.Length - length) : value;
        }

        /// <summary>
        /// Returns characters from the left of specified string.
        /// </summary>
        /// <returns>Returns string from left</returns>
        /// <param name="value">String value</param>
        /// <param name="length">Max number of characters to return</param>
        public static string Left(this string value, int length = 0){
            if (value == null) throw new ArgumentNullException(nameof(value));
            return value != null && value.Length > length ? value.Substring(0, length) : value;
        }

        /// <summary>
        /// Truncate the string to specified length and appends '...'
        /// </summary>
        /// <returns>Truncated string</returns>
        /// <param name="text">String to be truncated.</param>
        /// <param name="maxlength">Total length of characters to maintain.</param>
        public static string Truncate(this string text, int maxlength){
            //replaces string to maxLength appending a ...
            const string suffix = "...";
            string truncatedString = text;

            if (maxlength <= 0) return truncatedString;
            int stringLength = maxlength - suffix.Length;

            if (stringLength <= 0) return truncatedString;

            if (text ==null || text.Length <= maxlength) return truncatedString;

            truncatedString = text.Substring(0, stringLength);
            truncatedString = truncatedString.TrimEnd();
            truncatedString += suffix;
            return truncatedString;
        }
    }
}
