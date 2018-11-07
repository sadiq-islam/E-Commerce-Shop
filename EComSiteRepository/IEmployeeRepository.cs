using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComSiteRepository
{
    interface IEmployeeRepository
    {
        bool Insert(Employee a);
        bool Update(Employee a);
        bool Delete(string Id);
        Employee GetEmployee(string Id);
        List<Employee> GetAllEmployee();
    }
}
