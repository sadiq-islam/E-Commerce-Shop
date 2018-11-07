using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComSiteRepository
{
    interface IProductRepository
    {
        bool Insert(Product a);
        bool Update(Product a);
        bool Delete(string Id);
        Product GetProduct(string Id);
        List<Product> GetAllProduct();
    }
}
