using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComSiteRepository
{
    public class Customer : Person
    {
        private string type;
        private string address;
        private int discountPoint;

        public int DiscountPoint
        {
            get { return discountPoint; }
            set { discountPoint = value; }
        }


        public string Type
        {
            get { return type; }
            set { type = value; }

        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

    }
}
