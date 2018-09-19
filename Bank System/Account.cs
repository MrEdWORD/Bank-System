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
        protected internal decimal InterestRate { get; set; }
        protected internal decimal Amount { get; set; }

        private static int globalAccountID;

        public Account()
        {
            this.AccountID = Interlocked.Increment(ref globalAccountID);
        }

        public virtual decimal Deposit(decimal amount)
        {
            this.Amount += amount;

            return this.Amount;
        }

        public virtual decimal Withdraw(decimal amount)
        {
            if (this.Amount >= amount)
            {
                this.Amount -= amount;
                return this.Amount;
            }
            else
            {
                throw new Exception ("Your account must have enough funds in it to withdraw that amount!");
            }
        }

        public virtual bool Transfer(decimal amount, Account account)
        {
            if (this.Amount >= amount)
            {
                this.Amount -= amount;
                account.Amount += amount;
                return true;
            }
            return false;
        }
    }
}
