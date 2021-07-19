using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SnipsSolution.Extensions
{
    public static class StringBuilderExtensions
    {
        /// <summary>
        /// Append all values, if not empty/null.
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static StringBuilder AppendIfNotEmpty(this StringBuilder sb, params string[] values)
        {
            if (values.Any(v => !string.IsNullOrEmpty(v)))
            {
                sb.Append(values); 
            }

            return sb;
        }

        public static StringBuilder AddQueryParams(this StringBuilder source, IDictionary<string, string> keyValues)
        {
            foreach (var keyValue in keyValues)
            {
                source.AddQueryParam(keyValue.Key, keyValue.Value);
            }

            return source;
        }

        public static StringBuilder AddQueryParam(this StringBuilder source, string key, string value)
        {
            var delim = GetDelimiter(source);

            return source.Append($"{delim}{HttpUtility.UrlEncode(key)}={HttpUtility.UrlEncode(value)}");
        }

        private static string GetDelimiter(StringBuilder source)
        {
            var hasQuery = false;
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] != '?')
                {
                    continue;
                }

                hasQuery = true;
                break;
            }

            string delim;
            if (!hasQuery)
            {
                delim = "?";
            }else if ((source[source.Length - 1] == '?') || source[source.Length - 1] == '&')
            {
                delim = string.Empty;
            }
            else
            {
                delim = "&";
            }

            return delim;
        }
    }
}