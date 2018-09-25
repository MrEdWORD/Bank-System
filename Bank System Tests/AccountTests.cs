using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank_System;

namespace BankSystemTests
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void Account_Deposit_ReturnsAmount()
        {
            //Arrange
            Account account = new CheckingAccount(500m);
            decimal depositAmount = 100m;
            decimal expectedAmount = 600m;

            //Act
            decimal actualAmount = account.Deposit(depositAmount);

            //Assert
            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [TestMethod]
        public void Account_Withdraw_ReturnsAmount()
        {
            //Arrange
            Account account = new CheckingAccount(500m);
            decimal withdrawAmount = 200m;
            decimal expectedAmount = 300m;

            //Act
            decimal actualAmount = account.Withdraw(withdrawAmount);

            //Assert
            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Account_WithdrawTooMuch_ThrowsException()
        {
            //Arrange
            Account account = new CheckingAccount(500m);
            decimal withdrawAmount = 501m;

            //Act
            decimal actualAmount = account.Withdraw(withdrawAmount);
        }

        [TestMethod]
        public void Account_Transfer_ReturnsTrue()
        {
            //Arrange
            Account accountOne = new CheckingAccount(500m);
            Account accountTwo = new CheckingAccount(500m);
            decimal transferAmount = 200m;
            decimal expectedAmount_accountOne = 300m;
            decimal expectedAmount_accountTwo = 700m;

            //Act
            bool transferCompleted = accountOne.Transfer(transferAmount, accountTwo);
            decimal actualAmount_accountOne = accountOne.Amount;
            decimal actualAmount_accountTwo = accountTwo.Amount;

            //Assert
            Assert.IsTrue(transferCompleted);
            Assert.AreEqual(expectedAmount_accountOne, actualAmount_accountOne);
            Assert.AreEqual(expectedAmount_accountTwo, actualAmount_accountTwo);
        }
    }
}
