using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComSiteRepository
{
    interface ICustomerRepository
    {
        bool Insert(Customer a);
        bool Update(Customer a);
        bool Delete(string Id);
        Customer GetCustomer(string Id);
        List<Customer> GetAllCustomer();
    }
}
