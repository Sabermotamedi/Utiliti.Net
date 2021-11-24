using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace Utilities
{
    public static class StringExtensionMethods
    {

        public static string ToEnglishNumbers(this string text)
        {
            return text.Replace('۰', '0').Replace('۱', '1')
                  .Replace('۲', '2').Replace('۳', '3')
                  .Replace('۴', '4').Replace('۵', '5')
                  .Replace('۶', '6').Replace('۷', '7')
                  .Replace('۸', '8').Replace('۹', '9')

                  .Replace('٠', '0').Replace('١', '1')
                  .Replace('٢', '2').Replace('٣', '3')
                  .Replace('٤', '4').Replace('٥', '5')
                  .Replace('٦', '6').Replace('٧', '7')
                  .Replace('٨', '8').Replace('٩', '9');
        }

        public static string ToPersianLetters(this string text)
        {
            return text.Replace("ی", "ی")
                .Replace("ک", "ک")
                .Replace('ي', 'ی')
                .Replace('ك', 'ک')
                .Replace('أ', 'ا');
        }

        public static string RemoveTabAndNewlines(this string text)
        {
            text = text.Replace(System.Environment.NewLine, "").Replace('\t', ' ');
            return Regex.Replace(text, @"\r\n?|\n", "");
        }

        public static string NormalizeLettersAndNumbers(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;
            return text.Trim().ToEnglishNumbers().ToPersianLetters().RemoveTabAndNewlines();
        }

        public static string ToMD5(this string password)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString().ToUpper();
        }

        public static string ToSha1(this string text)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(text));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }

        public static DateTime ConvertToDateTime(this string persianDate)
        {
            PersianCalendar pc = new PersianCalendar();
            try
            {
                var parts = persianDate.Split('/');
                return new DateTime(Int16.Parse(parts[0]), Int16.Parse(parts[1]), Int16.Parse(parts[2]), pc);
            }
            catch (Exception ex)
            {
                return DateTime.Today;
            }
        }

        public static string SeperateTousands(this string text, int fractions = 0)
        {
            //NumberFormatInfo nfi = (NumberFormatInfo)
            //CultureInfo.InvariantCulture.NumberFormat.Clone();
            //nfi.NumberGroupSeparator = ",";
            if (string.IsNullOrWhiteSpace(text))
                return "";

            double number;
            if (double.TryParse(text, out number))
                return number.SeperateTousands(fractions);
            else
                return "";

            //return Regex.Replace(text, @"/\B(?=(\d{3})+(?!\d))/g", ",");
        }

        /// <summary>
        /// Only supports 8 digit int like 20170621
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string ToFormatedPersianDate(this string numberOnlyDate)
        {
            string result = "";

            if (numberOnlyDate.Length == 8)
            {
                result = string.Format("{0}/{1}/{2}",
                    numberOnlyDate.Substring(0, 4),
                    numberOnlyDate.Substring(4, 2),
                    numberOnlyDate.Substring(6));
            }

            return result;
        }

        public static DateTime? ToDateTimeFromPersianDate(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;
            s = s.ToEnglishNumbers();
            PersianCalendar pc = new PersianCalendar();
            try
            {
                
                var parts = s.Split('/');
                if (parts[0].Length != 4 && parts[0].Length == 2)
                    parts[0] = "13" + parts[0];
                return new DateTime(Int16.Parse(parts[0]), Int16.Parse(parts[1]), Int16.Parse(parts[2]), pc);
            }
            catch (Exception ex)
            {
                throw new Exception("Wrong Format ! DateTime Conversion Failed");
            }
        }
        public static DateTime? ToDateTimeFromPersianDateTime(this string ss)
        {
            if (string.IsNullOrEmpty(ss))
                return null;

            ss = ss.ToEnglishNumbers();
            string s = ss.Split(' ').Where(x => x.Contains("/")).First();
            var time = ss.Split(' ').Where(x => x.Contains(":")).First();
            PersianCalendar pc = new PersianCalendar();
            try
            {

                var parts = s.Split('/');
                if (parts[0].Length != 4 && parts[0].Length == 2)
                    parts[0] = "13" + parts[0];
                var dateTime= new DateTime(Int16.Parse(parts[0]), Int16.Parse(parts[1]), Int16.Parse(parts[2]), pc);
                return dateTime.Add(TimeSpan.Parse(time));
            }
            catch (Exception ex)
            {
                throw new Exception("Wrong Format ! DateTime Conversion Failed");
            }
        }
        /// <summary>
        /// Only supports 8 digit int like 13930621
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static DateTime ToDateFromEnglishDate(this string englishDateNumber)
        {
            var format = "yyyyMMdd";
            return DateTime.ParseExact(englishDateNumber, format, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Only supports 8 digit int like 13930621
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string ToPersianDateStringFromEnglishDate(this string englishDateNumber)
        {
            var format = "yyyyMMdd";
            return DateTime.ParseExact(englishDateNumber, format, CultureInfo.InvariantCulture).ToPersianDate();
        }

        public static string ToPersianDateTimeStringFromEnglishDate(this string englishDateNumber)
        {
            englishDateNumber = englishDateNumber.Trim();

            var format = "yyyyMMdd HH:mm:ss";
            var secondFormat = "yyyy-MM-dd HH:mm:ss";
            DateTime result;
            if (DateTime.TryParseExact(englishDateNumber, format , CultureInfo.InvariantCulture, DateTimeStyles.None,out  result))
                return result.ToPersianDateTime();
            else if (DateTime.TryParseExact(englishDateNumber, secondFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                return result.ToPersianDateTime();
            else return "";
        }

        public static string ToTimeString(this string numberText)
        {
            string result = "";

            if (numberText.Length % 2 == 1)
                numberText = "0" + numberText;

            if (numberText.Length > 1)
                result = numberText.Substring(0, 2);
            if (numberText.Length > 3)
                result += ":" + numberText.Substring(2, 2);

            return result;
        }

        public static string RemoveStylesTag(this string source)
        {
            if (string.IsNullOrWhiteSpace(source))
                return "";

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(source);
            // string cleaned = new Regex("style=\"[^\"]*\"").Replace(source, "");
            //return cleaned;
            if (doc.DocumentNode != null)
            {
                doc.DocumentNode.RemoveTag("//@style", "style");
                doc.DocumentNode.RemoveTag("//font[@face]", "face");
                //doc.DocumentNode.RemoveTag("//@width", "width");
                if (doc.DocumentNode.InnerHtml != null && doc.DocumentNode.InnerHtml.Contains("table"))
                {
                    var s = doc.DocumentNode.SelectNodes("//table");

                    if (s != null && s.Count > 0)
                        foreach (var item in s)
                        {
                            //var h = item.Attributes["align"].Value;
                            //if (h=="center")
                            //{
                            //    item.Attributes.Add("class", "tablePart");

                            //}
                            //var htmlResult = item.OuterHtml;

                            if (item.ParentNode != null)
                                item.ParentNode.InnerHtml = "\r\n<div class=\"tablePart\">\r\n"
                                + item.OuterHtml ?? "" +
                                                            "\r\n</div>\r\n";

                        }
                }
                if (doc.DocumentNode.InnerHtml != null && doc.DocumentNode.InnerHtml.Contains("img"))
                {
                    var s = doc.DocumentNode.SelectNodes("//img[@src]");
                    foreach (HtmlNode item in s)
                    {
                        var src = item.Attributes["src"].Value;
                        src = "http://cmr.seo.ir" + src;
                        //  src =item.Attributes["src"].Value.Replace("/Upload", "http://cmr.seo.ir/Upload");
                        item.SetAttributeValue("src", src);
                        item.SetAttributeValue("class", "img-responsive");
                    }
                }
                if (doc.DocumentNode.InnerHtml != null)
                {
                    return doc.DocumentNode?.InnerHtml;
                }
            }
            return source;
        }
        public static void RemoveTag(this HtmlNode node, string pattern, string attributeName)
        {
            var elementsWithStyleAttribute = node.SelectNodes(pattern);
            if (elementsWithStyleAttribute != null)
            {
                foreach (var item in elementsWithStyleAttribute)
                {
                    item.Attributes[attributeName].Remove();
                }
            }
        }
    }

}