using System.ComponentModel.DataAnnotations.Schema;
namespace VetClinic.DataAccess.Entities
{
    public enum StatusOfOrder
    {
        Recorded, // записан
        Completed, // выполнен
        Canceled, // отменен
    }
    [Table("Visit")]
    public class VisitEntity: BaseEntity
    {
        public int VetID { get; set; }
        public VetEntity Vet { get; set; }
        public int PetID { get; set; }
        public PetEntity Pet { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public string Discription { get; set; }
        public string Diagnosis {  get; set; }
        public StatusOfOrder Status { get; set; }
    }
}
