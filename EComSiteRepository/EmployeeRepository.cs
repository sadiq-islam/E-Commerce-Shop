using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComSiteRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public bool Insert(Employee a)
        {
            try
            {
                string query = "INSERT into Employee VALUES ('" + a.ID + "', '" + a.Name + "', '" + a.DOB + "','" + a.Gender + "','" + a.Email + "','" + a.ContactNo + "','" + a.Salary + "','" + a.Type + "','" + a.Address+ "' )";
                string query1 = "INSERT into Login VALUES ('" + a.ID + "', '" + a.Username + "', '" + a.Password + "', 'Employee')";

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

        public bool Update(Employee a)
        {
            try
            {
                string query = "UPDATE Employee SET Name = '" + a.Name + "', DOB = " + a.DOB + ", Gender = '" + a.Gender + "', Email= '" + a.Email + "', ContactNo= '" + a.ContactNo + "', Salary= '" + a.Salary + "', Type= '" + a.Type + "', Address= '" + a.Address + "' WHERE Id= '" + a.ID + "'";
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
                string query = "DELETE from Employee WHERE Id = '" + Id + "'";
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
        public string getEmployeeId(string Username)
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







        public Employee GetEmployee(string Id)
        {
            string query = "SELECT * from Employee WHERE Id= '" + Id + "'";
            string query1 = "SELECT * from Login WHERE Id= '" + Id + "'";
            Employee a = null;

            DatabaseConnectionClass dcc = new DatabaseConnectionClass();
            dcc.ConnectWithDB();
            SqlDataReader sdr = dcc.GetData(query);
            //SqlDataReader sdr1 = dcc.GetData(query1);

            if (sdr.Read())
            {
                a = new Employee();
                a.ID = sdr["Id"].ToString();
                a.Name = sdr["Name"].ToString();
                a.DOB = sdr["DOB"].ToString();
                a.Gender = sdr["Gender"].ToString();
                a.Email = sdr["Email"].ToString();
                a.ContactNo = sdr["ContactNo"].ToString();
                a.Salary = Convert.ToDouble(sdr["Salary"]);
                a.Type = sdr["Type"].ToString();
                a.Address = sdr["Address"].ToString();
                //a.Username = sdr1["Username"].ToString();
                //a.Password = sdr1["Password"].ToString();
            
            }
            dcc.CloseConnection();


            dcc.ConnectWithDB();
            SqlDataReader sdr1 = dcc.GetData(query1);

            if (sdr1.Read())
            {
                a.Username = sdr1["Username"].ToString();
                a.Password = sdr1["Password"].ToString();
            }
            dcc.CloseConnection();


            return a;
        }

        public List<Employee> GetAllEmployee()
        {
            string query = "SELECT * from Employee";
            
            List<Employee> empList = new List<Employee>();
            DatabaseConnectionClass dcc = new DatabaseConnectionClass();
            dcc.ConnectWithDB();
            SqlDataReader sdr = dcc.GetData(query);
            while (sdr.Read())
            {
                Employee a = new Employee();
                a.ID = sdr["Id"].ToString();
                a.Name = sdr["Name"].ToString();
                a.DOB = sdr["DOB"].ToString();
                a.Gender = sdr["Gender"].ToString();
                a.Email = sdr["Email"].ToString();
                a.ContactNo = sdr["ContactNo"].ToString();
                a.Salary = Convert.ToDouble(sdr["Salary"]);
                a.Type = sdr["Type"].ToString();
                a.Address = sdr["Address"].ToString();

                empList.Add(a);
            }
            dcc.CloseConnection();

           

            string query1;
            for (int i = 0; i < empList.Count; i++)
            {
                query1 = "SELECT * from Login WHERE Id = '" + empList[i].ID + "'";
                dcc.ConnectWithDB();
                SqlDataReader sdr1 = dcc.GetData(query1);
                if (sdr1.Read())
                {
                    empList[i].Username = sdr1["Username"].ToString();
                    empList[i].Password = sdr1["Password"].ToString();
                }
                dcc.CloseConnection();
            }


            return empList;
        }


        public bool EmployeeLoginVerification(Employee a)
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
