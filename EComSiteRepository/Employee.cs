using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComSiteRepository
{
    public class Employee : Person
    {
        private string type;
        private double salary;
        private string address;


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public string DOB
        {
            get { return dob; }
            set { dob = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }



        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string ContactNo
        {
            get { return contactNo; }
            set { contactNo = value; }
        }

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
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


        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }


    }
}
