using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComSiteRepository
{
    class Product
    {
        private string pid;
        private string name;
        private string type;
        private string price;
        private string quantity;


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Pid
        {
            get { return pid; }
            set { pid = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }



    }
}
