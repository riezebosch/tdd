using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IbanHelpers
{
    public class Bank
    {
        private IIbanChecker _checker;
        public Bank(IIbanChecker checker)
        {
            _checker = checker;
        }

        
        public Bank() 
            : this(new IbanChecker())
        {

        }

        public void Stort(string iban, decimal bedrag)
        {
            if (!_checker.Check(iban))
            {
                throw new ArgumentException("IBAN is niet correct");
            }

            Krediet += bedrag;
        }

        public decimal Krediet { get; set; }
    }
}
