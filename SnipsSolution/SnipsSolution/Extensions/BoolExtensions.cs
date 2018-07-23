using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnipsSolution.Extensions
{
    public static class BoolExtensions
    {
        /// <summary>
        /// If string matches, Y, Yes, N, No. 
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Defaults to false if doesn't match specified values.</returns>
        public static bool ToBoolean(this string value)
        {
            switch (value)
            {
                case "Y":
                case "Yes": case "1":
                    return true;

                case "N": case "No":
                case "0":
                    return false;
            }

            return false;

        }
    }
}
