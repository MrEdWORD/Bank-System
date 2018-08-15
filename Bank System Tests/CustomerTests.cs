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
            string ssn = "123-45-6789";
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
            string ssn = "456-12-3057";
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

        [TestMethod]
        public void Customer_UpdateSSNValid_ReturnsTrue()
        {
            //Arrange
            string firstName = "Albert";
            string lastName = "Einstein";
            string ssn = "495-10-3852";
            DateTime joinedDate = DateTime.Now;

            Customer newCustomer = new Customer(firstName, lastName, ssn, joinedDate);

            string updatedSSN = "528-44-5183";

            //Act
            bool ssnIsValid = newCustomer.UpdateSSN(updatedSSN);

            //Assert
            Assert.IsTrue(ssnIsValid);
        }

        [TestMethod]
        public void Customer_UpdateSSNInvalid_ReturnsFalse()
        {
            //Arrange
            string firstName = "Alfred";
            string lastName = "Wallace";
            string ssn = "333-33-3333";
            DateTime joinedDate = DateTime.Now;

            Customer newCustomer = new Customer(firstName, lastName, ssn, joinedDate);

            //Act
            bool ssnIsInvalid_noDashes = newCustomer.UpdateSSN("123451020");
            bool ssnIsInvalid_letters = newCustomer.UpdateSSN("lol-jk-gfy");
            bool ssnIsInvalid_spaces = newCustomer.UpdateSSN("111 11 1111");

            //Assert
            Assert.IsFalse(ssnIsInvalid_noDashes);
            Assert.IsFalse(ssnIsInvalid_letters);
            Assert.IsFalse(ssnIsInvalid_spaces);
        }
    }
}
