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
        protected internal decimal Balance { get; set; }
        protected internal List<Transaction> Transactions = new List<Transaction>(); // Store the history of transactions for reporting or audit purposes

        private static int _globalAccountID;

        public Account()
        {
            AccountID = Interlocked.Increment(ref _globalAccountID);
        }

        public virtual decimal Deposit(decimal amount)
        {
            Balance += amount;
            Transactions.Add(new Transaction(amount, "Deposit", DateTime.Now));

            return Balance;
        }

        public virtual decimal Withdraw(decimal amount)
        {
            if (this.Balance >= amount)
            {
                Balance -= amount;
                Transactions.Add(new Transaction(amount, "Withdraw", DateTime.Now));

                return Balance;
            }
            else
            {
                throw new Exception ("Your account must have enough funds in it to withdraw that amount!");
            }
        }

        public virtual bool Transfer(decimal amount, Account recipientAccount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Transactions.Add(new Transaction(amount, "Transfer", DateTime.Now));

                recipientAccount.Deposit(amount);

                return true;
            }
            return false;
        }
    }
}
