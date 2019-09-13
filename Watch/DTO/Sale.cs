using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Watch.DTO
{
    public class Sale
    {
        public string SaleId { get; set; }
        public decimal SalePrice { get; set; }
        public string Salesman { get; set; }

        public List<Sale> LoadSale(IEnumerable<string> sales)
        {
            List<Sale> lstSale = new List<Sale>();

            foreach (var sale in sales)
            {
                var saleData = sale.Split(new char[] { 'ç' });

                if (saleData.Count() != 4)
                    throw new Exception("Incorrect salesman data!");

                lstSale.Add(
                           new Sale()
                           {
                               SaleId = saleData[1],
                               SalePrice = Convert.ToDecimal(saleData[2]),
                               Salesman = saleData[3]
                           });
            }

            return lstSale;
        }
    }
}

