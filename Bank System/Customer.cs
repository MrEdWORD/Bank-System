using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class Customer
    {
        internal string FirstName { get; private set; }
        internal string LastName { get; private set; }
        internal int SSN { get; private set; }

        public Customer(string firstName, string lastName, int ssn)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.SSN = ssn;
        }
    }
}
