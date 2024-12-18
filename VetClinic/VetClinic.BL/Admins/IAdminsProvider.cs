using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.BL.Admins.Entities;

namespace VetClinic.BL.Admins
{
    public interface IAdminsProvider
    {
        IEnumerable<AdminModel> GetAdmins(AdminModelFilter modelFilter = null);
        AdminModel GetAdminInfo(Guid id);
    }
}
}
