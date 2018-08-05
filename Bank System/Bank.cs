using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank_System
{
    public class Bank
    {
        private int ID { get; set; }
        private string Name { get; set; }
        public List<Branch> Branches { get; set; }

        private static int globalBankID;

        public Bank(string name)
        {
            this.ID = Interlocked.Increment(ref globalBankID);
            this.Name = name;
            this.Branches = new List<Branch>();
        }

        public Branch AddBranch(string branchName)
        {
            Branch newBranch = new Branch(branchName);
            Branches.Add(newBranch);
            return newBranch;
        }

        public bool RemoveBranch(int branchID)
        {
            bool branchIDFound = false;

            while (!branchIDFound)
            {
                foreach (Branch b in Branches)
                {
                    if (b.ID == branchID)
                    {
                        Branches.Remove(b);
                        branchIDFound = true;
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
