using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneNumbers;

namespace TestValidPhone
{
    class Program
    {
        private static void Main(string[] args)
        {
            String swissNumberStr = "0947160500";
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            PhoneNumber phoneNumber = phoneUtil.Parse(swissNumberStr, "VN");
            var phone = phoneNumber.CountryCode.ToString() + (phoneNumber.NationalNumber).ToString();
            var a = phoneUtil.IsValidNumber(phoneNumber);


        }
    }
}
