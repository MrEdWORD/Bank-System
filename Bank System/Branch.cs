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
        public int ID { get; set; }
        public string Name { get; set; }
        private List<Account> Accounts { get; set; }
        private List<Customer> Customers { get; set; }

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
