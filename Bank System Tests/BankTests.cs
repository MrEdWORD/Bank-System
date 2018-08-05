using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank_System;

namespace BankSystemTests
{
    [TestClass]
    public class BankTests
    {
        [TestMethod]
        public void Bank_AddBranch_ReturnsNewBranch()
        {
            //Arrange
            Bank headquarter = new Bank("HQ");
            string branchName = "Seattle";
            Branch expectedBranch = null;
            Branch actualBranch = null;

            //Act
            expectedBranch = headquarter.AddBranch(branchName);
            actualBranch = headquarter.Branches[0];

            //Assert
            Assert.AreSame(expectedBranch, actualBranch);
            Assert.IsTrue(headquarter.Branches.Contains(expectedBranch));
        }

        [TestMethod]
        public void Bank_RemoveOneOfOneBranch_ReturnsTrue()
        {
            //Arrange
            Bank headquarter = new Bank("HQ");
            Branch newBranch = headquarter.AddBranch("London");

            //Act
            bool branchRemoved = headquarter.RemoveBranch(newBranch.ID);

            //Assert
            Assert.IsTrue(branchRemoved);
            Assert.IsFalse(headquarter.Branches.Contains(newBranch));
        }

        [TestMethod]
        public void Bank_RemoveOneOfManyBranches_ReturnsTrue()
        {
            //Arrange
            Bank headquarter = new Bank("HQ");
            Branch branchOne = headquarter.AddBranch("Seattle");
            Branch branchTwo = headquarter.AddBranch("Portland");
            Branch branchThree = headquarter.AddBranch("Vancouver");
            Branch branchFour = headquarter.AddBranch("Las Vegas");

            //Act
            bool branchRemoved = headquarter.RemoveBranch(branchThree.ID);

            //Assert
            Assert.IsTrue(branchRemoved);
            Assert.IsFalse(headquarter.Branches.Contains(branchThree));
            Assert.IsTrue(headquarter.Branches.Contains(branchOne));
            Assert.IsTrue(headquarter.Branches.Contains(branchTwo));
            Assert.IsTrue(headquarter.Branches.Contains(branchFour));
        }

        [TestMethod]
        public void Bank_RemoveNonExistantBranch_ReturnsFalse()
        {
            //Arrange
            Bank headquarter = new Bank("HQ");
            Branch newBranch = headquarter.AddBranch("Las Vegas");

            //Act
            bool branchRemoved = headquarter.RemoveBranch(100);

            //Assert
            Assert.IsFalse(branchRemoved);
        }
    }
}
