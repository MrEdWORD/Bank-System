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
        public abstract decimal InterestRate { get; } // Read-only property because the interest rates are declared in the derived class using a constant field. Const field implementation was chosen because we don't want interest rates to change during run-time since all objects of a derived class will have the same interest rate.
        protected internal decimal Amount { get; set; } 

        private static int globalAccountID;

        public Account()
        {
            AccountID = Interlocked.Increment(ref globalAccountID);
        }

        public virtual decimal Deposit(decimal amount)
        {
            Amount += amount;

            return Amount;
        }

        public virtual decimal Withdraw(decimal amount)
        {
            if (this.Amount >= amount)
            {
                Amount -= amount;
                return Amount;
            }
            else
            {
                throw new Exception ("Your account must have enough funds in it to withdraw that amount!");
            }
        }

        public virtual bool Transfer(decimal amount, Account account)
        {
            if (Amount >= amount)
            {
                Amount -= amount;
                account.Amount += amount;
                return true;
            }
            return false;
        }
    }
}
