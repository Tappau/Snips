using System.Globalization;
using System.Text;

namespace SnipsSolution.Extensions
{
    /// <summary>
    /// TODO write unittests
    /// </summary>
    public static class DecimalExtensions
    {
        public static string ToFormattedString(this decimal value, int decimalPlaces, string delimiter = ".")
        {
            var sb = new StringBuilder(delimiter);
            for (int i = 0; i < decimalPlaces; i++)
            {
                sb.Append("#");
            }

            return value.ToString(sb.ToString());
        }
    }
}