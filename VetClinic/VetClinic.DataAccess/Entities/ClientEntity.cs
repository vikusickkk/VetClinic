using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinic.DataAccess.Entities
{
    [Table("Clients")]
    public class ClientEntity: BaseEntity
    {
        public Guid ExternalId { get; set; }
        public DateTime ModificationTime { get; set; }
        public DateTime CreationTime { get; set; }

        public string NameClient { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public virtual ICollection<PetEntity> Pets { get; set; }
        public virtual ICollection<ReviewEntity> Reviews { get; set; }
    }

    public class ClientRoleEntity : IdentityRole<int>
    {
    }
}
