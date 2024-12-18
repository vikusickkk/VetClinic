using System.ComponentModel.DataAnnotations;

namespace VetClinic.WebAPI.Controllers.Entities
{
    public class CreateClientRequest
    {
        [Required]
        [MinLength(1)]
        public string NameClient { get; set; }

        [Required]
        [MinLength(11)]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        [Required]
        [MinLength(7)]
        public string PasswordHash { get; set; }
    }
}
