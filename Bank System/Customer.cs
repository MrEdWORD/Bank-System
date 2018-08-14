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
        internal DateTime JoinedDate { get; private set; }

        public Customer(string firstName, string lastName, int ssn, DateTime joinedDate)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.JoinedDate = joinedDate;
        }

        internal bool UpdateName(string firstName, string lastName)
        {
            if (!String.IsNullOrWhiteSpace(firstName) && !String.IsNullOrWhiteSpace(lastName))
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                return true;
            }
            return false;
        }

        //TODO add method for updating SSN
    }
}
