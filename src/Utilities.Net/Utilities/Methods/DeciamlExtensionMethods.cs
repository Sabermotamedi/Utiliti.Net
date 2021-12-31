using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class DeciamlExtensionMethods
    {
        public static string ToPhoneNumber(this decimal phoneNumber)
        {
            string result = phoneNumber.ToString();
            if (result.Length == 11)
                return result;
            return "0" + result;
        }
        public static string ToNationalCode(this decimal nationalCode)
        {
            string result = nationalCode.ToString();
            if (result.Length == 10)
                return result;
            return "0" + result;
        }
    }
}
