using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PaymentAPI.Extensions
{
    public static class ValidationExtension
    {
        public static bool IsCreditCardValid(this bool isValid,  string ccNumber)
        {
            int sumOfDigits = ccNumber.Where((e) => e >= '0' && e <= '9')
               .Reverse()
               .Select((e, i) => ((int)e - 48) * (i % 2 == 0 ? 1 : 2))
               .Sum((e) => e / 10 + e % 10);
            isValid = sumOfDigits % 10 == 0;
            return isValid;
        }
    }
}
