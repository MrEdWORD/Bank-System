using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class Branch
    {
        internal int ID { get; private set; }
        internal string Name { get; private set; }
        internal static List<Account> Accounts { get; private set; }
        internal static List<Customer> Customers { get; private set; }

        private static int globalBranchID;

        public Branch (string name)
        {
            this.ID = Interlocked.Increment(ref globalBranchID);
            this.Name = name;
            Accounts = new List<Account>();
            Customers = new List<Customer>();
        }

        internal static Customer AddCustomer(string firstName, string lastName, int ssn, DateTime joinedDate)
        {
            Customer newCustomer = new Customer(firstName, lastName, ssn, joinedDate);
            Customers.Add(newCustomer);
            return newCustomer;
        }

        internal static bool RemoveCustomer(Customer customer)
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
