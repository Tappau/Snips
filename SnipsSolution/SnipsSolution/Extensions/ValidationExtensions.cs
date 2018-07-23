using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        
    }
}
