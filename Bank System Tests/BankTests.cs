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
            string branchName = "Seattle";
            Branch expectedBranch = null;

            //Act
            expectedBranch = Bank.AddBranch(branchName);

            //Assert
            Assert.IsTrue(Bank.Branches.Contains(expectedBranch));
        }

        [TestMethod]
        public void Bank_RemoveOneOfOneBranch_ReturnsTrue()
        {
            //Arrange
            Branch newBranch = Bank.AddBranch("London");

            //Act
            bool branchRemoved = Bank.RemoveBranch(newBranch.ID);

            //Assert
            Assert.IsTrue(branchRemoved);
            Assert.IsFalse(Bank.Branches.Contains(newBranch));
        }

        [TestMethod]
        public void Bank_RemoveOneOfManyBranches_ReturnsTrue()
        {
            //Arrange
            Branch branchOne = Bank.AddBranch("Seattle");
            Branch branchTwo = Bank.AddBranch("Portland");
            Branch branchThree = Bank.AddBranch("Vancouver");
            Branch branchFour = Bank.AddBranch("Las Vegas");

            //Act
            bool branchRemoved = Bank.RemoveBranch(branchThree.ID);

            //Assert
            Assert.IsTrue(branchRemoved);
            Assert.IsFalse(Bank.Branches.Contains(branchThree));
            Assert.IsTrue(Bank.Branches.Contains(branchOne));
            Assert.IsTrue(Bank.Branches.Contains(branchTwo));
            Assert.IsTrue(Bank.Branches.Contains(branchFour));
        }

        [TestMethod]
        public void Bank_RemoveNonExistantBranch_ReturnsFalse()
        {
            //Arrange
            Branch newBranch = Bank.AddBranch("Las Vegas");

            //Act
            bool branchRemoved = Bank.RemoveBranch(100);

            //Assert
            Assert.IsFalse(branchRemoved);
        }
    }
}
