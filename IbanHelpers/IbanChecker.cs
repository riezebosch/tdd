using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;

namespace IbanHelpers
{
    public class IbanChecker : IbanHelpers.IIbanChecker
    {
        public bool Check(string iban)
        {
            if (iban == null)
            {
                throw new ArgumentNullException("iban");
            }

            iban = iban.Replace(" ", "").ToUpper(CultureInfo.InvariantCulture);

            if (iban.Length == 18
                && iban.StartsWith("NL", StringComparison.Ordinal)
                && iban.Substring(2, 2) == BerekenControleGetal(iban))
            {
                return true;
            }

            return false;
        }

        internal static string BerekenControleGetal(string iban)
        {
            var result = iban.Substring(4, 4) +
                iban.Substring(8, 10) +
                iban.Substring(0, 2) +
                "00";

            var sb = new StringBuilder();
            checked
            {
                foreach (var c in result)
                {
                    
                    if (char.IsLetter(c))
                    {
                        sb.Append((c - 'A') + 10);
                    }
                    else if (char.IsDigit(c))
                    {
                        sb.Append(c - '0');
                    }
                }
            }

            var total = BigInteger.Parse(sb.ToString(), CultureInfo.InvariantCulture);
            return (98 - total % 97).ToString("D2", CultureInfo.InvariantCulture);
        }
    }
}
