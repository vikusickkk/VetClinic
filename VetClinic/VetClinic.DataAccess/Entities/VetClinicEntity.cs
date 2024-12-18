using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinic.DataAccess.Entities
{
    [Table("VetClinics")]
    public class VetClinicEntity: BaseEntity
    {
        public string Address {  get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<AdminEntity> Admins { get; set; }
        public virtual ICollection<VetEntity> Vets { get; set; }
    }
}
