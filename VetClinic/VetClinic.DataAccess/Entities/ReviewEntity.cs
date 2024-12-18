using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinic.DataAccess.Entities
{
    [Table("Reviews")]
    public class ReviewEntity: BaseEntity
    {
        public int ClientID { get; set; }
        public ClientEntity Client { get; set; }
        public int AdminID { get; set; }
        public AdminEntity Admin { get; set; }
        public string Description { get; set; }
        public DateTime DateWriting { get; set; }
    }
}
