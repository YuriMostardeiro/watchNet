using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Watch.DTO
{
    public class Sale
    {
        public string SaleId { get; set; }
        public string Salesman { get; set; }

        public decimal SalePrice { get; set; }

        public List<SaleItem> SaleItems { get; set; }

        public List<Sale> LoadSale(IEnumerable<string> sales)
        {
            List<Sale> lstSale = new List<Sale>();

            foreach (var sale in sales)
            {
                var saleData = sale.Split(new char[] { 'ç' });
                decimal totalValue = 0;

                if (saleData.Count() != 4)
                    throw new Exception("Incorrect salesman data!");

                var itensFile = saleData[2].Replace("[", string.Empty).Replace("]", string.Empty).Split(new char[] { ',' });

                List<SaleItem> lstSaleItem = new List<SaleItem>();

                foreach (var item in itensFile)
                {
                    var saleValue = item.Split(new char[] { '-' });

                    int quantity = Convert.ToInt32(saleValue[1]);
                    decimal price = Convert.ToDecimal(saleValue[2]);                    

                    totalValue += quantity * price;                    

                    lstSaleItem.Add(
                        new SaleItem()
                        {
                            Quantity = quantity,
                            Price = price
                        }                 
                    );
                }

                lstSale.Add(
                           new Sale()
                           {
                               SaleId = saleData[1],
                               SaleItems = lstSaleItem,                               
                               Salesman = saleData[3],
                               SalePrice = totalValue
                           }); ;
            }

            return lstSale;
        }
    }
}

