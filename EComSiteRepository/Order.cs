using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComSiteRepository
{
    class Order
    {
        private string orderID;
        private double totalAmount;

        private List<Product> p;

        public string OrderId
        {
            get { return orderID; }
            set { orderID = value; }
        }

        public double TotalAmount
        {
            get { return totalAmount; }
            set { totalAmount = value; }
        }

    }
}
