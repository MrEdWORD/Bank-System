using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class CheckingAccount : Account
    {
        const decimal DailyWithdrawLimit = 1000;

        public CheckingAccount(decimal interestRate, decimal amount)
        {
            InterestRate = interestRate;
            Amount = amount;
        }
    }
}
