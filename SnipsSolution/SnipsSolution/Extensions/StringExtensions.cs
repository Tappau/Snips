using System;
using System.IO;
using System.Xml.Serialization;

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
        public static string Right(this string value, int length = 0)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            return length != 0 && value.Length > length ? value.Substring(value.Length - length) : value;
        }

        /// <summary>
        /// Returns characters from the left of specified string.
        /// </summary>
        /// <returns>Returns string from left</returns>
        /// <param name="value">String value</param>
        /// <param name="length">Max number of characters to return</param>
        public static string Left(this string value, int length = 0)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            return length != 0 && value.Length > length ? value.Substring(0, length) : value;
        }

        /// <summary>
        /// Truncate the string to specified length and appends '...'
        /// </summary>
        /// <returns>Truncated string</returns>
        /// <param name="text">String to be truncated.</param>
        /// <param name="maxlength">Total length of characters to maintain.</param>
        public static string Truncate(this string text, int maxlength)
        {
            //replaces string to maxLength appending a ...
            const string suffix = "...";
            string truncatedString = text;

            if (maxlength <= 0) return truncatedString;
            int stringLength = maxlength - suffix.Length;

            if (stringLength <= 0) return truncatedString;

            if (text == null || text.Length <= maxlength) return truncatedString;

            truncatedString = text.Substring(0, stringLength);
            truncatedString = truncatedString.TrimEnd();
            truncatedString += suffix;
            return truncatedString;
        }

        /// <summary>
        /// Serialise a object to type T into an XML string.
        /// </summary>
        /// <returns>A string representation of object T, otherwise empty.</returns>
        /// <param name="obj">Object to serialise</param>
        /// <typeparam name="T">Any object type.</typeparam>
        public static string ToXml<T>(this T obj) where T : class, new()
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            var serialiser = new XmlSerializer(typeof(T));
            using (var writer = new StringWriter())
            {
                serialiser.Serialize(writer, obj);
                return writer.ToString();
            }
        }

        /// <summary>
        /// Deserialise a XML string into an object of type T.
        /// </summary>
        /// <returns>A new object of type T if successful, null if failed.</returns>
        /// <param name="xml">XML as string to deserialise from</param>
        /// <typeparam name="T">Any class type.</typeparam>
        public static T ParseXmlTo<T>(this string xml) where T : class, new()
        {
            if (string.IsNullOrWhiteSpace(xml))
            {
                throw new ArgumentNullException(nameof(xml));
            }

            var serialiser = new XmlSerializer(typeof(T));
            using (var reader = new StringReader(xml))
            {
                try
                {
                    return (T)serialiser.Deserialize(reader);
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the Nth <paramref name="occurance"/> of specified <paramref name="match"/>
        /// This is case sensitive.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="match"></param>
        /// <param name="occurance"></param>
        /// <returns>Returns index value, -1 if not found.</returns>
        public static int NthIndexOf(this string str, string match, int occurance)
        {
            var i = 1;
            var index = 0;

            while (i <= occurance && (index = str.IndexOf(match, index + 1, StringComparison.Ordinal)) != 1)
            {
                if (i == occurance)
                {
                    //ooccurance match found
                    return index;
                }

                i++;
            }

            //No matchs
            return -1;
        }
        /// <summary>
        /// Removes the last character of a string
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string RemoveLastCharacter(this string val)
        {
            if (string.IsNullOrWhiteSpace(val)) throw new ArgumentNullException(nameof(val));
            return val.Substring(0, val.Length - 1);
        }

        /// <summary>
        /// Remove the last 'N' characters
        /// </summary>
        /// <param name="val"></param>
        /// <param name="charsToRemove">Count of characters to remove from end</param>
        /// <returns></returns>
        public static string RemoveLast(this string val, int charsToRemove = 0)
        {
            if (string.IsNullOrWhiteSpace(val)) throw new ArgumentNullException(nameof(val));
            return val.Substring(0, val.Length - charsToRemove);
        }

        /// <summary>
        /// Remove first character of a string
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string RemoveFirstCharacter(this string val)
        {
            if (string.IsNullOrWhiteSpace(val)) throw new ArgumentNullException(nameof(val));
            return val.Substring(1);
        }

        /// <summary>
        /// Remove first 'N' characters
        /// </summary>
        /// <param name="val"></param>
        /// <param name="charsToRemove">Count of chars to remove from begining</param>
        /// <returns></returns>
        public static string RemoveFirst(this string val, int charsToRemove = 0)
        {
            if (string.IsNullOrWhiteSpace(val)) throw new ArgumentNullException(nameof(val));
            return val.Substring(charsToRemove);
        }

        /// <summary>
        /// Convert a string number to integer. If not able to convert will return -1.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int ToInt(this string val)
        {
            if (!int.TryParse(val, out var result))
            {
                result = -1;
            }

            return result;
        }

        /// <summary>
        /// Convert string to a double, if not able will return -1.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static double ToDouble(this string val)
        {
            if (!double.TryParse(val, out var result))
            {
                result = -1;
            }

            return result;
        }
    }
}
