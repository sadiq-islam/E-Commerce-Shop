using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComSiteRepository
{
     abstract public class Person
    {
         protected string name;
         protected string id;
         protected string dob;
         protected string gender;
         protected string email;
         protected string contactNo;
         protected string username;
         protected string password;
         


         public string Name
         {
             get { return name; }
             set { name = value;  }
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
