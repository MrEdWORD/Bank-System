using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank_System
{
    public class Branch
    {
        internal int ID { get; private set; }
        internal string Name { get; private set; }
        internal List<Account> Accounts { get; private set; }
        internal List<Customer> Customers { get; private set; }

        private static int globalBranchID;

        public Branch (string name)
        {
            this.ID = Interlocked.Increment(ref globalBranchID);
            this.Name = name;
            this.Accounts = new List<Account>();
            this.Customers = new List<Customer>();
        }
    }
}
