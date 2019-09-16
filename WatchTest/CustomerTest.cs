using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Watch.DTO;

namespace WatchTest
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void LoadCustomerTest()
        {
            Customer customer = new Customer();

            List<string> simulatedFile = new List<string>();
            simulatedFile.Add("002Á2345675434544345ÁJose da SilvaÁRural");

            var customerResult = customer.LoadCustomer(simulatedFile).FirstOrDefault();
            Assert.AreEqual(customerResult.BusinessArea, "Rural");
            Assert.AreEqual(customerResult.Name, "Jose da Silva");
            Assert.AreEqual(customerResult.Cnpj, "2345675434544345");
        }
    }
}
