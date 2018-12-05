using System;

namespace SnipsSolution.Extensions
{
    public static class BoolExtensions
    {
        private static readonly string[] ValidList =
        {
            "y", "n", "yes", "no", "true", "false", "0", "1"
        };

        /// <summary>
        ///     If string matches, Y, Yes, N, No.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Defaults to false if doesn't match specified values.</returns>
        public static bool ToBoolean(this string value)
        {
            var val = value.ToLower();

            if (!val.IsAnyOf(ValidList))
                throw new ArgumentException("Must be an accepted string representation of boolean", nameof(value));

            switch (val.ToLower())
            {
                case "y":
                case "yes":
                case "1":
                case "true":
                    return true;

                case "n":
                case "no":
                case "0":
                case "false":
                    return false;
                default:
                    return false;
            }
        }
    }
}