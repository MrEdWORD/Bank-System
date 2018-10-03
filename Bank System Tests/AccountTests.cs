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
        public void Account_Withdraw_TooMuch_ThrowsException()
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
            decimal actualAmount_accountOne = accountOne.Balance;
            decimal actualAmount_accountTwo = accountTwo.Balance;

            //Assert
            Assert.IsTrue(transferCompleted);
            Assert.AreEqual(expectedAmount_accountOne, actualAmount_accountOne);
            Assert.AreEqual(expectedAmount_accountTwo, actualAmount_accountTwo);
        }

        [TestMethod]
        public void Account_Transfer_NotEnoughFunds_ReturnsFalse()
        {
            //Arrange
            Account accountOne = new CheckingAccount(100m);
            Account accountTwo = new CheckingAccount(500m);
            decimal transferAmount = 200m;
            decimal expectedAmount_accountOne = 100m;
            decimal expectedAmount_accountTwo = 500m;

            //Act
            bool transferCompleted = accountOne.Transfer(transferAmount, accountTwo);
            decimal actualAmount_accountOne = accountOne.Balance;
            decimal actualAmount_accountTwo = accountTwo.Balance;

            //Assert
            Assert.IsFalse(transferCompleted);
            Assert.AreEqual(expectedAmount_accountOne, actualAmount_accountOne);
            Assert.AreEqual(expectedAmount_accountTwo, actualAmount_accountTwo);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Account_Savings_HasReachedMaxTransactions_ThrowsException()
        {
            //Arrange
            SavingsAccount accountOne = new SavingsAccount(700m);

            //Act
            for (int i = 0; i <=5; i++)
            {
                //Generate 6 withdraw transactions in the current month
                accountOne.Withdraw(100m);
            }

            //Generate one more transaction to trigger the max transaction check
            accountOne.Withdraw(100m);

            //Assert - no assertion, expected to throw exception
        }

        [TestMethod]
        public void Account_Savings_HasReachedNotMaxTransactions_ReturnsAmount()
        {
            //Arrange
            SavingsAccount accountOne = new SavingsAccount(700m);
            decimal expectedBalance = 100m;

            //Act
            for (int i = 0; i <= 5; i++)
            {
                //Generate 6 withdraw transactions in the current month
                accountOne.Withdraw(100m);
            }

            //Assert
            Assert.AreEqual(expectedBalance, accountOne.Balance);
        }
    }
}
