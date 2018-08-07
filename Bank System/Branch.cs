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

        internal Customer AddCustomer(string firstName, string lastName, int SSN)
        {
            Customer newCustomer = new Customer(firstName, lastName, SSN);
            Customers.Add(newCustomer);
            return newCustomer;
        }

        internal bool RemoveCustomer(Customer customer)
        {
            bool customerFound = false;

            while (!customerFound)
            {
                foreach (Customer c in Customers)
                {
                    if (object.ReferenceEquals(c, customer))
                    {
                        Customers.Remove(c);
                        customerFound = true;
                        return true;
                    }
                    else
                    {
                        continue;
                    }
                }
                break;
            }
            return false;

        }
    }
}
