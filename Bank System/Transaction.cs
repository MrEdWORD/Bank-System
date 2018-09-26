using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank_System
{
    class Transaction
    {
        internal int ID { get; private set; }
        internal decimal Amount { get; set; }
        internal string Description { get; set; }
        internal DateTime TransactionDate { get; set; }

        private static int _globalTransactionID;

        public Transaction(decimal amount, string description, DateTime date)
        {
            ID = Interlocked.Increment(ref _globalTransactionID);
            Amount = amount;
            Description = description;
            TransactionDate = date;
        }
    }
}
