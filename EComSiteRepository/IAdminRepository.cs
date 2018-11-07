using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComSiteRepository
{
    interface IAdminRepository
    {
        bool Insert(Admin a);
        bool Update(Admin a);
        bool Delete(string Id);
        Admin GetAdmin(string Id);
        List<Admin> GetAllAdmin();
    }
}
