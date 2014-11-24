using System;
namespace IbanHelpers
{
    public interface IIbanChecker
    {
        bool Check(string iban);
    }
}
