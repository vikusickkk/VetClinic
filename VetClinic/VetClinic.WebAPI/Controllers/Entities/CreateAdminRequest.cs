using System.ComponentModel.DataAnnotations;
namespace VetClinic.WebAPI.Controllers.Entities
{
    public class CreateAdminRequest
    {
        [Required]
        [MinLength(11)]
        public string Email { get; set; }

        [Required]
        [MinLength(7)]
        public string PasswordHash { get; set; }

        [Required]
        public int VetClinicID { get; set; }

    }
}