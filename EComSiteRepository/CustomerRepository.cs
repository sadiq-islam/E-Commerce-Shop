using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComSiteRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        public bool Insert(Customer a)
        {
            try
            {
                string query = "INSERT into Customer VALUES ('" + a.ID + "', '" + a.Name + "', '" + a.DOB + "','" + a.Gender + "','" + a.Email + "','" + a.ContactNo + "','" + a.DiscountPoint + "','" + a.Type + "','" + a.Address + "' )";
                string query1 = "INSERT into Login VALUES ('" + a.ID + "', '" + a.Username + "', '" + a.Password + "', 'Customer')";

                DatabaseConnectionClass dcc = new DatabaseConnectionClass();
                dcc.ConnectWithDB();
                int x = dcc.ExecuteSQL(query);
                dcc.CloseConnection();

                dcc.ConnectWithDB();
                int y = dcc.ExecuteSQL(query1);
                dcc.CloseConnection();


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(Customer a)
        {
            try
            {
                string query = "UPDATE Customer SET Name = '" + a.Name + "', DOB = " + a.DOB + ", Gender = '" + a.Gender + "', Email= '" + a.Email + "', ContactNo= '" + a.ContactNo + "', Salary= '" + a.DiscountPoint + "', Type= '" + a.Type + "', Address= '" + a.Address + "' WHERE Id= '" + a.ID + "'";
                string query1 = "UPDATE Login SET Username='" + a.Username + "', Password='" + a.Password + "', Type='Employee' WHERE Id= '" + a.ID + "' ";

                DatabaseConnectionClass dcc = new DatabaseConnectionClass();

                dcc.ConnectWithDB();
                int x = dcc.ExecuteSQL(query);
                dcc.CloseConnection();

                dcc.ConnectWithDB();
                int y = dcc.ExecuteSQL(query1);
                dcc.CloseConnection();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool Delete(string Id)
        {
            try
            {
                string query = "DELETE from Customer WHERE Id = '" + Id + "'";
                string query1 = "DELETE from Login WHERE Id = '" + Id + "'";

                DatabaseConnectionClass dcc = new DatabaseConnectionClass();
                dcc.ConnectWithDB();
                int x = dcc.ExecuteSQL(query);
                dcc.CloseConnection();

                dcc.ConnectWithDB();
                int y = dcc.ExecuteSQL(query1);
                dcc.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        string id;
        public string getCustomerId(string Username)
        {

            string query = "SELECT * from Login WHERE Username= '" + Username + "'";

            DatabaseConnectionClass dcc = new DatabaseConnectionClass();
            dcc.ConnectWithDB();
            SqlDataReader sdr = dcc.GetData(query);
            if (sdr.Read())
            {
                id = sdr["Id"].ToString();
            }
            dcc.CloseConnection();
            return id;

        }

        public Customer GetCustomer(string Id)
        {
            string query = "SELECT * from Customer WHERE Id= '" + Id + "'";
            string query1 = "SELECT * from Login WHERE Id= '" + Id + "'";
            Customer a = null;

            DatabaseConnectionClass dcc = new DatabaseConnectionClass();
            dcc.ConnectWithDB();
            SqlDataReader sdr = dcc.GetData(query);
            SqlDataReader sdr1 = dcc.GetData(query1);

            if (sdr.Read())
            {
                 a = new Customer();
                a.ID = sdr["Id"].ToString();
                a.Name = sdr["Name"].ToString();
                a.DOB = sdr["DOB"].ToString();
                a.Gender = sdr["Gender"].ToString();
                a.Email = sdr["Email"].ToString();
                a.ContactNo = sdr["ContactNo"].ToString();
                a.DiscountPoint = Convert.ToInt32(sdr["Discount Point"]);
                a.Type = sdr["Type"].ToString();
                a.Address = sdr["Address"].ToString();
                a.Username = sdr1["Username"].ToString();
                a.Password = sdr1["Password"].ToString();

            }
            dcc.CloseConnection();
            return a;
        }

        public List<Customer> GetAllCustomer()
        {
            string query = "SELECT * from Customer";
            string query1 = "SELECT * from Login WHERE Type= 'Customer'";

            List<Customer> cList = new List<Customer>();
            DatabaseConnectionClass dcc = new DatabaseConnectionClass();
            dcc.ConnectWithDB();
            SqlDataReader sdr = dcc.GetData(query);
            SqlDataReader sdr1 = dcc.GetData(query1);
            while (sdr.Read())
            {
                Customer a = new Customer();
                a.ID = sdr["Id"].ToString();
                a.Name = sdr["Name"].ToString();
                a.DOB = sdr["DOB"].ToString();
                a.Gender = sdr["Gender"].ToString();
                a.Email = sdr["Email"].ToString();
                a.ContactNo = sdr["ContactNo"].ToString();
                a.DiscountPoint = Convert.ToInt32(sdr["Discount Point"]);
                a.Type = sdr["Type"].ToString();
                a.Address = sdr["Address"].ToString();
                a.Username = sdr1["Username"].ToString();
                a.Password = sdr1["Password"].ToString();

                cList.Add(a);
            }
            dcc.CloseConnection();
            return cList;
        }


        public bool CustomerLoginVerification(Customer a)
        {
            string query = "SELECT * from Login WHERE Username= '" + a.Username + "' AND Password= '" + a.Password + "'";

            DatabaseConnectionClass dcc = new DatabaseConnectionClass();
            dcc.ConnectWithDB();
            SqlDataReader sdr = dcc.GetData(query);

            if (sdr.Read())
            {
                dcc.CloseConnection();
                return true;
            }
            else
            {
                dcc.CloseConnection();
                return false;
            }
        }
    }
}
