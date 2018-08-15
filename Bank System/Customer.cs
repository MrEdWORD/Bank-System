using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Bank_System
{
    internal class Customer
    {
        internal string FirstName { get; private set; }
        internal string LastName { get; private set; }
        internal string SSN { get; private set; }
        internal DateTime JoinedDate { get; private set; }

        public Customer(string firstName, string lastName, string ssn, DateTime joinedDate)
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

        internal bool UpdateSSN(string ssn)
        {
            //SSN format must be "###-##-###"
            Regex regex = new Regex("^\\d{3}-\\d{2}-\\d{4}$");
            Match match = regex.Match(ssn);

            if (match.Success)
            {
                this.SSN = ssn;
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
