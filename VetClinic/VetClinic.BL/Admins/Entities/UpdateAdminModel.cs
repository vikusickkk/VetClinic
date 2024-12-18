using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.BL.Admins.Entities
{
    public class UpdateAdminModel
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
