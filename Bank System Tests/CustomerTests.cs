using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank_System;

namespace BankSystemTests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void Customer_UpdateValidName_ReturnsTrue()
        {
            //Arrange
            string firstName = "Gordan";
            string lastName = "Freeman";
            int ssn = 123456789;
            DateTime joinedDate = DateTime.Now;

            Customer newCustomer = new Customer(firstName, lastName, ssn, joinedDate);

            string updatedFirstName = "G";
            string updatedLastName = "Man";

            //Act
            bool namesAreValid = newCustomer.UpdateName(updatedFirstName, updatedLastName);

            //Assert
            Assert.IsTrue(namesAreValid);
        }

        [TestMethod]
        public void Customer_UpdateInvalidName_ReturnsFalse()
        {
            //Arrange
            string firstName = "Cloud";
            string lastName = "Strife";
            int ssn = 123456789;
            DateTime joinedDate = DateTime.Now;

            Customer newCustomer = new Customer(firstName, lastName, ssn, joinedDate);

            string whiteSpaceFirstName = "   ";
            string whiteSpaceLastName = "           ";
            string emptyFirstName = string.Empty;
            string emptyLastName = string.Empty;
            string nullFirstName = null;
            string nullLastName = null;

            //Act
            bool namesAreInvalid_whiteSpace = newCustomer.UpdateName(whiteSpaceFirstName, whiteSpaceLastName);
            bool namesAreInvalid_empty = newCustomer.UpdateName(emptyFirstName, emptyLastName);
            bool namesAreInvalid_null = newCustomer.UpdateName(nullFirstName, nullLastName);

            //Assert
            Assert.IsFalse(namesAreInvalid_whiteSpace);
            Assert.IsFalse(namesAreInvalid_empty);
            Assert.IsFalse(namesAreInvalid_null);
        }
    }
}
