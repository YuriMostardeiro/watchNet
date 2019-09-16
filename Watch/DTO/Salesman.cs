using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Watch.DTO
{
    public class Salesman
    {
        public string Cpf { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public List<Salesman> LoadSalesman(IEnumerable<string> salesmans)
        {
            List<Salesman> lstSalesman = new List<Salesman>();

            foreach (var salesman in salesmans)
            {
                var salesmanData = salesman.Split(new char[] { 'ç' });

                if (salesmanData.Count() != 4)
                    throw new Exception("Incorrect salesman data!");

                lstSalesman.Add(
                   new Salesman()
                   {
                       Cpf = salesmanData[1],
                       Name = salesmanData[2],
                       Salary = Convert.ToDecimal(salesmanData[3])
                   });
            }

            return lstSalesman;
        }
    }
}
