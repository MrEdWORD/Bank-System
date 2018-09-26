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
            Balance = amount;
            Transactions.Add(new Transaction(amount, "Account creation and initial deposit", DateTime.Now));
        }

        public override decimal InterestRate //Interest rate needs to be the same for all objects of the class and cannot change at run-time, so we have to read it from a const
        {
            get
            {
                return _interestRate;
            }
        }
    }
}
