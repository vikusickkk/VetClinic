using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinic.DataAccess.Entities
{
    [Table("Admins")]
    public class AdminEntity: BaseEntity
    {
        public int VetClinicID { get; set; }
        public VetClinicEntity VetClinic { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public virtual ICollection<ReviewEntity> Reviews { get; set; }
    }
}
