using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    interface IAccount
    {
        decimal Deposit(decimal amount);
        decimal Withdraw(decimal amount);
        bool Transfer(decimal amount, int accountID);
    }
}
