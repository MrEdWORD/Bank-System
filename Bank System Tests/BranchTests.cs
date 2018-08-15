using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank_System;

namespace BankSystemTests
{
    [TestClass]
    public class BranchTests
    {
        [TestMethod]
        public void Branch_AddCustomer_ReturnsNewCustomer()
        {
            //Arrange
            Branch branch = new Branch("San Diego");

            string customerFirstName = "Robin";
            string customerLastName = "Williams";
            string customerSSN = "123-45-6789";
            DateTime joinedDate = DateTime.Now;
            Customer expectedCustomer = null;

            //Act
            expectedCustomer = Branch.AddCustomer(customerFirstName, customerLastName, customerSSN, joinedDate);

            //Assert
            Assert.IsTrue(Branch.Customers.Contains(expectedCustomer));
        }

        [TestMethod]
        public void Branch_RemoveCustomer_ReturnsTrue()
        {
            //Arrange
            Branch branch = new Branch("New York City");
            Customer customer = Branch.AddCustomer("Tina", "Fey", "123-45-6789", DateTime.Now);

            //Act
            bool customerRemoved = Branch.RemoveCustomer(customer);

            //Assert
            Assert.IsTrue(customerRemoved);
            Assert.IsFalse(Branch.Customers.Contains(customer));
        }
    }
}
