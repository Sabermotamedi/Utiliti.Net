using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class LongExtensionMethods
    {
        public static long ToLong(this long? longValue)
        {
            if (longValue.HasValue)
                return longValue.Value;
            return 0;
        }

        public static string ToFileSizeString(this long fileSize)
        {
            if (fileSize < 1024)
            {
                return fileSize + " بایت";
            }
            else if (fileSize < 1024 * 1024)
            {
                return Math.Round(fileSize / 1024.0, 2) + " کیلوبایت";
            }
            else
            {
                return Math.Round(fileSize / (1024.0 * 1024.0), 2) + " مگابایت";
            }
        }
    }
}
