using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank_System
{
    internal abstract class Account : IAccount
    {
        internal int AccountID { get; private set; }
        internal decimal InterestRate { get; private set; }
        internal decimal Amount { get; private set; }

        private static int globalAccountID;

        public Account(decimal interestRate, decimal amount = 0)
        {
            this.AccountID = Interlocked.Increment(ref globalAccountID);
            this.InterestRate = interestRate;
            this.Amount = amount;
        }

        public abstract decimal Deposit(decimal amount);

        public abstract bool Transfer(decimal amount, Account account);

        public abstract decimal Withdraw(decimal amount);
    }
}
