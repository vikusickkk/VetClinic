using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinic.DataAccess.Entities
{
    [Table("Vets")]
    public class VetEntity: BaseEntity
    {
        public int VetClinicID {  get; set; }
        public VetClinicEntity VetClinic { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<VetWorkSchduleEntity> VetWorkSchdules { get; set;}
        public virtual ICollection<VisitEntity> Visits { get; set; }
    }
}
