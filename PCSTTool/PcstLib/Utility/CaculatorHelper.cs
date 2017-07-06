using System;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.CSharp.RuntimeBinder;

namespace PcstLib.Utility
{
    public  static class CaculatorHelper
    {
        public static string GetFullName(string firstName, string middleName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return string.Empty;
            }

            var firstname = "";
            if (!string.IsNullOrEmpty(firstName))
            {
                firstname = ", " + firstName;
            }
            return lastName + firstname + (string.IsNullOrEmpty(middleName) ? "" : " " + middleName);
        }

        public static string GetFullAddress(string address1, string address2, string city, string state, string zip)
        {
            if (string.IsNullOrEmpty(address1) && string.IsNullOrEmpty(address2) && string.IsNullOrEmpty(city) &&
                string.IsNullOrEmpty(city) && string.IsNullOrEmpty(zip))
            {
                return string.Empty;
            }
            var result = "";
            if (!string.IsNullOrEmpty(address1))
                result += address1 + ", ";
            if (!string.IsNullOrEmpty(address2))
                result += address2 + ", ";
            if (!string.IsNullOrEmpty(city))
                result += city + ", ";
            if (!string.IsNullOrEmpty(state))
                result += state;
            if (!string.IsNullOrEmpty(zip))
                result += " " + zip;

            return result;
        }
        public static string RemoveFormatPhone(this string maskPhoneNumber)
        {
            if (!string.IsNullOrEmpty(maskPhoneNumber))
            {
                var phone = maskPhoneNumber.Replace(" ", "").Replace("(", "").Replace(")", "").Replace("-", "").Replace("_", "");
                return phone;
            }
            return maskPhoneNumber;
        }
        public static string RemoveFormat(this string number)
        {
            return string.IsNullOrEmpty(number) ? number : Regex.Replace(number, "[^.0-9]+", "");
        }
        public static string ApplyFormatPhone(this string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber)) return "";

            phoneNumber = RemoveFormat(phoneNumber);

            if (string.IsNullOrEmpty(phoneNumber) || phoneNumber.Length != 10) return phoneNumber;

            return String.Format("{0:(000) 000-0000}", double.Parse(phoneNumber));
        }

        public static string GetConnectionString(string key = "DefaulDataContext")
        {
            return ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }

        public static int TryParseIntFromStr(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            int valInt;
            if (int.TryParse(input, out valInt))
            {
                return valInt;
            }
            return 0;
        }

        public static int GetNumberFromString(string input)
        {
            return Convert.ToInt32(Regex.Replace(input, "[^0-9]+", string.Empty));
        }

        /// <summary>
        /// Conpare datetime
        /// </summary>
        /// <param name="d1">destination</param>
        /// <param name="d2">source</param>
        /// <param name="format">foramt datetime</param>
        /// <returns>-1 is d2 > d1, 0 is d1 = d2, 1 is d1 > d2. </returns>
        public static int CompareDateTime(this DateTime d1, DateTime d2, string format = "MM/dd/yyyy HH:mm")
        {
            if (string.IsNullOrEmpty(format))
            {
                throw new Exception("Format invalid.");
            }

            var dr1 = DateTime.ParseExact(d1.ToString(format), format, CultureInfo.InvariantCulture);
            var dr2 = DateTime.ParseExact(d2.ToString(format), format, CultureInfo.InvariantCulture);
            return dr1 > dr2 ? 1 : dr2 > dr1 ? -1 : 0;
        }

        public static bool CheckFileNameValid(string fileName)
        {
            var listCharInvalid = new[] { "\\", "/", ":", "*", "?", "<", ">", "|","." };
            return fileName.All(t => !listCharInvalid.Contains(t.ToString()));
        }

        public static DateTime? TryParseDatTimeFromStr(string input)
        {
            if (string.IsNullOrEmpty(input))
                return null;
            try
            {
                //var valDate = DateTime.ParseExact(valStr, "MM/dd/yyyy", provider);
                DateTime dt = DateTime.Parse(input, new CultureInfo("en-US"));
                return dt;
            }
            catch (FormatException)
            {
                return null;
            }
            return null;
        }
    }
}
