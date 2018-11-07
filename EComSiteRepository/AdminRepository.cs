using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComSiteRepository
{
    public class AdminRepository : IAdminRepository
    {
        public bool Insert(Admin a)
        {
            try
            {
                string query = "INSERT into Admin VALUES ('" + a.ID + "', '" + a.Name + "', '" + a.DOB + "','" + a.Gender + "','" + a.Email + "','" + a.ContactNo + "' )";
                string query1 = "INSERT into Login VALUES ('" + a.ID + "', '" + a.Username + "', '" + a.Password + "', 'Admin')";

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




        public bool Update(Admin a)
        {
            try
            {
                string query = "UPDATE Admin SET Name = '" + a.Name + "', DOB = " + a.DOB + ", Gender = '" + a.Gender + "',Email= '" + a.Email + "',ContactNo= '" + a.ContactNo + "' WHERE Id= '" + a.ID + "'";
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
                string query = "DELETE from Admin WHERE Id = '" + Id + "'";
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
        public string getAdminId(string Username)
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



        public Admin GetAdmin(string Id)
        {
            string query = "SELECT * from Admin WHERE Id= '" + Id + "'";
            string query1 = "SELECT * from Login WHERE Id= '" + Id + "'";
            Admin a = null;

            DatabaseConnectionClass dcc = new DatabaseConnectionClass();
            dcc.ConnectWithDB();
            SqlDataReader sdr = dcc.GetData(query);
            
            if (sdr.Read())
            {
                a = new Admin();
                a.ID = sdr["Id"].ToString();
                a.Name = sdr["Name"].ToString();
                a.DOB = sdr["DOB"].ToString();
                a.Gender = sdr["Gender"].ToString();
                a.Email = sdr["Email"].ToString();
                a.ContactNo = sdr["ContactNo"].ToString();
                
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



        public List<Admin> GetAllAdmin()
        {
            string query = "SELECT * from Admin";
            List<Admin> aList = new List<Admin>();
            Admin a = null;

            DatabaseConnectionClass dcc = new DatabaseConnectionClass();
            dcc.ConnectWithDB();
            SqlDataReader sdr = dcc.GetData(query);
            while (sdr.Read())
            {
                a = new Admin();
                a.ID = sdr["Id"].ToString();
                a.Name = sdr["Name"].ToString();
                a.DOB = sdr["DOB"].ToString();
                a.Gender = sdr["Gender"].ToString();
                a.Email = sdr["Email"].ToString();
                a.ContactNo = sdr["ContactNo"].ToString();

                aList.Add(a);
            }
            dcc.CloseConnection();

            
            
            string query1;
            for (int i = 0; i < aList.Count; i++ )
            {
                query1 = "SELECT * from Login WHERE Id = '" + aList[i].ID + "'";
                dcc.ConnectWithDB();
                SqlDataReader sdr1 = dcc.GetData(query1);
                if(sdr1.Read())
                {
                    aList[i].Username = sdr1["Username"].ToString();
                    aList[i].Password = sdr1["Password"].ToString();
                }
                dcc.CloseConnection();
            }

                return aList;
        }


        public bool AdminLoginVerification(Admin a)
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
