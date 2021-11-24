using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web;

namespace Utilities
{
    public static class ArrayExtensionMethods
    {
        public static string ConvertToString(this long[] array)
        {
            string result = "";
            if (array != null && array.Length > 0)
                for (int i = 0; i < array.Length; i++)
                {
                    result += array[i] + ";";
                }
            return result.Length > 1 ? result.Substring(0, result.Length - 1) : "";
        }
    }
}