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

        public virtual decimal Deposit(decimal amount)
        {
            return Amount += amount;
        }

        public virtual bool Transfer(decimal amount, int accountID)
        {
            throw new NotImplementedException();

            //make sure accountID we want to transfer to exists
            //bool recipientAccountFound = false;
            //while (!recipientAccountFound)
            //{

            //}

            //make sure the account we are transferring from has enough funds in the account

            //Deposit amount in the transfer-to account's amount

            //Decrease transfer-from accounts' amountt by the transfer amount
        }

        public decimal Withdraw(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
