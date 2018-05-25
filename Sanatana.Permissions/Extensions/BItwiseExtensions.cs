using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanatana.Permissions.Extensions
{
    public static class BitwiseExtensions
    { 
        /// <summary>
        /// Includes an enumerated type and returns the new value
        /// </summary>
        public static long Include(this long value, long append)
        {
            return value | append;
        }

        /// <summary>
        /// Removes an enumerated type and returns the new value
        /// </summary>
        public static long Remove(this long value, long remove)
        {
            return value & ~remove;
        }

        /// <summary>
        /// Checks if an enumerated type contains a value
        /// </summary>
        public static bool Has(this long value, long check)
        {
            return (value & check) == check;
        }

        /// <summary>
        /// Checks if an enumerated type is missing a value
        /// </summary>
        public static bool Missing(this long value, long check)
        {
            return !value.Has(check);
        }
    }
}
