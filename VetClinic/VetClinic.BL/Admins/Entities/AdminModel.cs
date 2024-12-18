using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.DataAccess.Entities;

namespace VetClinic.BL.Admins.Entities
{
    public class AdminModel
    {
        public Guid Id { get; set; }
        public int VetClinicID { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
