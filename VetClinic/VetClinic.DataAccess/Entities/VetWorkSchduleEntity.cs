using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinic.DataAccess.Entities
{
    [Table("VetWorkSchdules")]
    public class VetWorkSchduleEntity: BaseEntity
    {
        public int VetID { get; set; }
        public VetEntity Vet { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
