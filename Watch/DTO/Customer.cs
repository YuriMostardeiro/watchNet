using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Watch.DTO
{
    public class Customer
    {
        public string Cnpj { get; set; }
        public string Name { get; set; }
        public string BusinessArea { get; set; }        

        public List<Customer> LoadCustomer(IEnumerable<string> customers)
        {
            List<Customer> lstCustomers = new List<Customer>();

            foreach (var customer in customers)
            {
                var customerData = customer.Split(new char[] { 'ç' });

                if (customerData.Count() != 4)
                    throw new Exception("Incorrect salesman data!");

                lstCustomers.Add(
                           new Customer()
                           {
                               Cnpj = customerData[1],
                               Name = customerData[2],
                               BusinessArea = customerData[3]
                           });
            }

            return lstCustomers;
        }
    }
}
