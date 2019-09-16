using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Watch.DTO;

namespace WatchTest
{
    [TestClass]
    public class SalesmanTest
    {
        [TestMethod]
        public void LoadSalesmanTest()
        {
            Salesman salesman = new Salesman();

            List<string> simulatedFile = new List<string>();
            simulatedFile.Add("001ç1234567891234çPedroç50000");

            var salesmanResult = salesman.LoadSalesman(simulatedFile).FirstOrDefault();
            Assert.AreEqual(salesmanResult.Cpf, "1234567891234");
            Assert.AreEqual(salesmanResult.Name, "Pedro");
            Assert.AreEqual(salesmanResult.Salary, 50000);
        }
    }
}
