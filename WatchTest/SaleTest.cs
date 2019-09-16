using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Watch.DTO;

namespace WatchTest
{
    [TestClass]
    public class SaleTest
    {
        [TestMethod]
        public void LoadSaleTest()
        {
            Sale sale = new Sale();

            List<string> simulatedFile = new List<string>();
            simulatedFile.Add("003Á10Á[1-10-100,2-30-2.50,3-40-3.10]ÁPedro");

            var saleResult = sale.LoadSale(simulatedFile).FirstOrDefault();
            Assert.AreEqual(saleResult.Salesman, "Pedro");
            Assert.AreEqual(saleResult.SalePrice, 20900);
            Assert.AreEqual(saleResult.SaleId, "10");
            Assert.AreEqual(saleResult.SaleItems.Count(), 3);
        }
    }
}
