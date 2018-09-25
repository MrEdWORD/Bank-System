using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class CheckingAccount : Account
    {
        private const decimal _interestRate = 0.75m;

        public CheckingAccount(decimal amount)
        {
            Amount = amount;
        }

        public override decimal InterestRate
        {
            get
            {
                return _interestRate;
            }
        }
    }
}
