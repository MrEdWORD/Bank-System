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
            int customerSSN = 123456789;
            Customer expectedCustomer = null;
            Customer actualCustomer = null;

            //Act
            expectedCustomer = branch.AddCustomer(customerFirstName, customerLastName, customerSSN);
            actualCustomer = branch.Customers[0];

            //Assert
            Assert.AreSame(expectedCustomer, actualCustomer);
            Assert.IsTrue(branch.Customers.Contains(expectedCustomer));
        }

        [TestMethod]
        public void Branch_RemoveCustomer_ReturnsTrue()
        {
            //Arrange
            Branch branch = new Branch("New York City");
            Customer customer = branch.AddCustomer("Tina", "Fey", 123456789);

            //Act
            bool customerRemoved = branch.RemoveCustomer(customer);

            //Assert
            Assert.IsTrue(customerRemoved);
            Assert.IsFalse(branch.Customers.Contains(customer));
        }
    }
}
