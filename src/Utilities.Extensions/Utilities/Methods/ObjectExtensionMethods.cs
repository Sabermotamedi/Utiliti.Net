using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ComponentModel;
//using System.Web;

namespace Utilities
{
    public static class ObjectExtensionMethods
    {
        public static string ToStringSupportingNull(this object obj)
        {
            if (obj == null)
                return "";
            return obj.ToString();
        }

        public static List<Variance> DetailedCompare<T, S>(this T obj1, S obj2)
        {
            List<Variance> variances = new List<Variance>();

            var obj1Type = obj1.GetType();
            if (obj1Type.BaseType != null && obj1Type.Namespace == "System.Data.Entity.DynamicProxies")
            {
                obj1Type = obj1Type.BaseType;
            }
            var obj2Type = obj2.GetType();
            if (obj2Type.BaseType != null && obj2Type.Namespace == "System.Data.Entity.DynamicProxies")
            {
                obj2Type = obj2Type.BaseType;
            }

            var props1 = obj1Type.GetProperties().Where(x=>x.PropertyType.IsSimple()).ToArray();
            var props2 = obj2Type.GetProperties().Where(x => x.PropertyType.IsSimple()).ToArray();
            foreach (var p1 in props1)
            {
                foreach (var p2 in props2)
                {
                    if (p1.Name == p2.Name)
                    {
                        Variance v = new Variance();
                        var val1 = p1.GetValue(obj1);
                        var val2 = p2.GetValue(obj2);
                        if (!Equals(val1,val2))
                            variances.Add(new Variance()
                            {
                                PropertyName = p1.Name,
                                ValueOf1 = val1,
                                ValueOf2 = val2
                            });
                    }
                }
            }
            return variances;
        }

        public static bool IsSimple(this Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                // nullable type, check if the nested type is simple.
                return IsSimple(type.GetGenericArguments()[0]);
            }
            return type.IsPrimitive
              || type.IsEnum
              || type.Equals(typeof(string))
              || type.Equals(typeof(decimal));
        }
    }
    
    public class Variance
    {
        public string PropertyName { get; set; }
        public object ValueOf1 { get; set; }
        public object ValueOf2 { get; set; }

        public override string ToString()
        {
            return string.Format("Value of \'{0}\' was: {1} \t is: {2}", PropertyName, ValueOf2, ValueOf1);
        }
    }
}