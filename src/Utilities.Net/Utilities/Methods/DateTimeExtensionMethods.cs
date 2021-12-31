using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Utilities
{
    public static class DateTimeExtensionMethods
    {
        public static string RemainTimeToString(this TimeSpan tim)
        {
            if (tim.TotalMinutes < 0)
                return "-" +Math.Abs(tim.Days) + "روز " + Math.Abs(tim.Hours) + "ساعت " + Math.Abs(tim.Minutes) + " دقیقه";// + " گذشته";
            else
                return Math.Abs(tim.Days) + "روز " + Math.Abs(tim.Hours) + "ساعت " + Math.Abs(tim.Minutes) + " دقیقه";// + " مانده";

        }
        public static string ToPersianDate(this DateTime dt)
        {
            PersianCalendar pc = new PersianCalendar();
            try
            {
                return pc.GetYear(dt) + "/" + pc.GetMonth(dt).ToTwoDigitString() + "/" + pc.GetDayOfMonth(dt).ToTwoDigitString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public static string ToPersianDateTime(this DateTime dt)
        {
            return dt.ToPersianTime() + "  " + dt.ToPersianDate();
        }
        public static string ToPersianTime(this DateTime dt)
        {
            PersianCalendar pc = new PersianCalendar();
            try
            {
                return pc.GetHour(dt).ToTwoDigitString() + ":" + pc.GetMinute(dt).ToTwoDigitString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static string ToPersianDate(this DateTime? dt)
        {
            if (!dt.HasValue)
                return "";
            PersianCalendar pc = new PersianCalendar();
            try
            {
                return pc.GetYear(dt.Value) + "/" + pc.GetMonth(dt.Value).ToTwoDigitString() + "/" + pc.GetDayOfMonth(dt.Value).ToTwoDigitString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public static string ToPersianDateTime(this DateTime? dt)
        {
            if (!dt.HasValue)
                return "";
            return dt.ToPersianDate() + "  " + dt.ToPersianTime();
        }
        public static string ToPersianTime(this DateTime? dt)
        {
            if (!dt.HasValue)
                return "";
            PersianCalendar pc = new PersianCalendar();
            try
            {
                return pc.GetHour(dt.Value).ToTwoDigitString() + ":" + pc.GetMinute(dt.Value).ToTwoDigitString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static int ToDateInteger(this DateTime dt)
        {
            return dt.Year * 10000 + dt.Month * 100 + dt.Day;
        }

    }
}