using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class IntExtensionMethods
    {
        public static string ToTwoDigitString(this int number)
        {
            if (number < 10)
            {
                return "0" + number;
            }
            else
            {
                return number.ToString();
            }
        }

        public static string ToTimeString(this int number)
        {
            var numberText = number.ToString();
            string result = "";

            if (numberText.Length % 2 == 1)
                numberText = "0" + numberText;

            if (numberText.Length > 1)
                result = numberText.Substring(0, 2);
            if (numberText.Length > 3)
                result += ":" + numberText.Substring(2, 2);

            return result;
        }

        public static string ToTimeStringWithSeconds(this int number)
        {
            var numberText = number.ToString();
            string result = "";

            if (numberText.Length % 2 == 1)
                numberText = "0" + numberText;

            if (numberText.Length > 1)
                result = numberText.Substring(0, 2);
            if (numberText.Length > 3)
                result += ":" + numberText.Substring(2, 2);
            if (numberText.Length > 5)
                result += ":" + numberText.Substring(4);

            return result;
        }

        /// <summary>
        /// Only supports 8 digit int like 13930621
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static DateTime ToDateFromEnglishDateNumber(this int englishDateNumber)
        {
            var format = "yyyyMMdd";
            return DateTime.ParseExact(englishDateNumber.ToString(), format, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Only supports 8 digit int like 13930621
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string ToPersianDateStringFromEnglishDateNumber(this int englishDateNumber)
        {
            var format = "yyyyMMdd";
            return DateTime.ParseExact(englishDateNumber.ToString(), format, CultureInfo.InvariantCulture).ToPersianDate();
        }


        /// <summary>
        /// Only supports 8 digit int like 13930621
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string ToPersianDateString(this int number)
        {
            return number.ToString().ToFormatedPersianDate();
        }

        public static DateTime? ToEnglishDateTime(this int number)
        {
            if (number < 19000000 || number > 21000000)
                return null;
            return DateTime.ParseExact(number.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
        }

        //public static string ShortenNumber(this int number, int fractions = 2)
        //{
        //    return ((long)number).ShortenNumber(fractions);
        //}

        //public static string ShortenNumber(this decimal number, int fractions = 2)
        //{
        //    return ((long)number).ShortenNumber(fractions);
        //}

        //public static string ShortenNumber(this long number, int fractions = 2)
        //{
        //    if (number >= 1000000000)
        //        return Math.Round((double)number / 1000000000, fractions) + "B";
        //    else if (number >= 1000000)
        //        return Math.Round((double)number / 1000000, fractions) + "M";
        //    else if (number >= 1000)
        //        return Math.Round((double)number / 1000, fractions) + "K";
        //    else
        //        return number.ToString();
        //}

        public static string ShortenNumberAndSeperateTousands(this decimal number, int fractions = 3)
        {
            return ((long)number).ShortenNumberAndSeperateTousands(fractions);
        }
        public static string ShortenNumberAndSeperateTousands(this int number, int fractions = 3)
        {
            return ((long)number).ShortenNumberAndSeperateTousands(fractions);
        }
        public static string ShortenNumberAndSeperateTousands(this long number, int fractions = 3)
        {
            if (number >= 1000000000 )
                return Math.Round((double)number / 1000000000, fractions).SeperateTousands(fractions) + "B";
            else if (number >= 1000000 )
                return Math.Round((double)number / 1000000, fractions).SeperateTousands(fractions) + "M";
            else if (number >= 1000 && fractions<3)
                return Math.Round((double)number / 1000, fractions).SeperateTousands(fractions) + "K";
            else
                return number.SeperateTousands(fractions);
        }

        public static string SeperateTousands(this double number, int fractions = 0)
        {
            //NumberFormatInfo nfi = (NumberFormatInfo)
            //CultureInfo.InvariantCulture.NumberFormat.Clone();
            //nfi.NumberGroupSeparator = ",";

            if (number == 0)
                return "0";
            else
            {
                if (fractions == 0)
                    return number.ToString("#,#");
                else
                    return number.ToString($"#,#.{new string('#', fractions)}") ;
            }

            //return Regex.Replace(text, @"/\B(?=(\d{3})+(?!\d))/g", ",");
        }

        public static string SeperateTousands(this decimal number, int fractions = 0)
        {
            return ((double)number).SeperateTousands(fractions);
        }

        public static string SeperateTousands(this int number, int fractions = 0)
        {
            return ((double)number).SeperateTousands(fractions);
        }

        public static string SeperateTousands(this long number, int fractions = 0)
        {
            return ((double)number).SeperateTousands(fractions);
        }
    }
}
