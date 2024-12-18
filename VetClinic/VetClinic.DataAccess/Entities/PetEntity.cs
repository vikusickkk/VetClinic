using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinic.DataAccess.Entities
{
    [Table("Pets")]
    public class PetEntity: BaseEntity
    {

        public string NamePet {  get; set; }
        public string DiseaseHistory { get; set; }
        public int ClientID { get; set; }
        public ClientEntity Client {  get; set; }
        public int Old {  get; set; }
        public string Specie { get; set; }
        public virtual ICollection<VisitEntity> Visits { get; set; }
    }
}
