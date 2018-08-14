using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank_System
{
    internal static class Bank
    {
        internal static string Name { get; private set; }
        internal static List<Branch> Branches { get; private set; }

        static Bank()
        {
            Name = "Bank Headquarters";
            Branches = new List<Branch>();
            //PopulateBranches(); //TODO add method for populating program with default branches
        }

        internal static Branch AddBranch(string branchName)
        {
            Branch newBranch = new Branch(branchName);
            Branches.Add(newBranch);
            return newBranch;
        }

        internal static bool RemoveBranch(int branchID) //todo refactor parameter to be of type Branch instead of BranchID, or make consistent with AddBranch
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
