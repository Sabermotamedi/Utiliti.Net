using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Utilities.Attributes;


namespace Utilities
{
    public static class EnumExtensionMethods
    {
        public static Dictionary<int,string> ToDictionary(this Type enumType)
        {
            var values = System.Enum.GetValues(enumType);
            Dictionary<int, string> result = new Dictionary<int, string>();
            foreach (var item in values)
            {
                var enumItem = (System.Enum)item;
                result.Add((int)item, enumItem.ToDescriptionString());
            }

            return result;
        }

        public static string ToDescriptionString(this Enum val)
        {
            if(val == null || val.GetType().GetField(val.ToString()) == null)
            {
                return "";
            }
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }

        public static string ToEnglishDescriptionString(this Enum val)
        {
            if (val == null || val.GetType().GetField(val.ToString()) == null)
            {
                return "";
            }
            var attributes = (EnglishDescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(EnglishDescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].EnglishDescription : string.Empty;
        }
    }
}