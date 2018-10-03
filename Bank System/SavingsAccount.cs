using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class SavingsAccount : Account
    {
        private const decimal _interestRate = 1.85m;
        private const int maxMonthlyTransactions = 6; //Regulation D imposes a six-transaction limit https://en.wikipedia.org/wiki/Regulation_D_(FRB)

        public SavingsAccount(decimal amount)
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

        public override decimal Withdraw(decimal amount)
        {
            //Before withdrawing money from savings accounts, check to make sure that there have been <=6 transactions in the same month
            if (HasReachedMaxTransactions(Transactions))
            {
                throw new Exception("You cannot have more than 6 savings account withdraws per month!");
            }
            else
            {
                return base.Withdraw(amount);
            }
        }

        private bool HasReachedMaxTransactions(List<Transaction> transactions)
        {
            //Counts the number of withdraw transactions in the current month and returns true when its more than 6

            int transactionCounter = 0;
            foreach (Transaction transaction in transactions)
            {
                if (transaction.Description == "Withdraw" && transaction.TransactionDate.Month == DateTime.Now.Month)
                {
                    transactionCounter++;

                    if (transactionCounter >= 6) 
                    {
                        return true;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            return false;
        }
    }
}
