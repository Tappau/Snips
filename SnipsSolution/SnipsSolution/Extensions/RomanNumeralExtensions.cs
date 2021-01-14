using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SnipsSolution.Extensions

{
    public static class RomanNumeralExtensions
    {
        private const int NumberOfRomanNumeralMaps = 13;

        private static readonly Dictionary<string, int> RomanNumerals =
            new Dictionary<string, int>(NumberOfRomanNumeralMaps)
            {
                {"M", 1000},
                {"CM", 900},
                {"D", 500},
                {"CD", 400},
                {"C", 100},
                {"XC", 90},
                {"L", 50},
                {"XL", 40},
                {"X", 10},
                {"IX", 9},
                {"V", 5},
                {"IV", 4},
                {"I", 1}
            };

        private static readonly Regex ValidRomanNumeral = new Regex(
            "^(?i:(?=[MDCLXVI])((M{0,3})((C[DM])|(D?C{0,3}))"
            + "?((X[LC])|(L?XX{0,2})|L)?((I[VX])|(V?(II{0,2}))|V)?))$",
            RegexOptions.Compiled);

        /// <summary>
        ///     Checks if string equals a valid roman numeral
        /// </summary>
        /// <returns><c>true</c>, if valid roman numeral was ised, <c>false</c> otherwise.</returns>
        /// <param name="value">Value.</param>
        public static bool IsValidRomanNumeral(this string value)
        {
            return ValidRomanNumeral.IsMatch(value);
        }

        /// <summary>
        ///     Parses the roman numeral.
        /// </summary>
        /// <returns>The roman numeral as an integer.</returns>
        /// <param name="value">String to parse.</param>
        public static int ParseRomanNumeral(this string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            value = value.ToUpperInvariant().Trim();

            var length = value.Length;

            if (length == 0 || !value.IsValidRomanNumeral())
            {
                throw new ArgumentException("Empty or invalid Roman numeral string.", nameof(value));
            }

            var total = 0;
            var i = length;

            while (i > 0)
            {
                var digit = RomanNumerals[value[--i].ToString()];

                if (i > 0)
                {
                    var previousDigit = RomanNumerals[value[i - 1].ToString()];

                    if (previousDigit < digit)
                    {
                        digit -= previousDigit;
                        i--;
                    }
                }

                total += digit;
            }

            return total;
        }

        /// <summary>
        ///     Converts integer to a roman numeral string
        /// </summary>
        /// <returns>The roman numeral string.</returns>
        /// <param name="value">Number to convert</param>
        public static string ToRomanNumeralString(this int value)
        {
            const int minValue = 1;
            const int maxValue = 3999;
            const int maxRomanNumeralLength = 15;

            if (value < minValue || value > maxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, "Argument out of Roman numeral range.");
            }

            var sb = new StringBuilder(maxRomanNumeralLength);

            foreach (var pair in RomanNumerals)
            {
                while (value / pair.Value > 0)
                {
                    sb.Append(pair.Key);
                    value -= pair.Value;
                }
            }

            return sb.ToString();
        }
    }
}