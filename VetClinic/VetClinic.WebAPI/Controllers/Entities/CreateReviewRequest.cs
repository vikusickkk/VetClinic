using System.ComponentModel.DataAnnotations;

namespace VetClinic.WebAPI.Controllers.Entities
{
    public class CreateReviewRequest
    {
        [Required]
        public int ClientID { get; set; }

        [Required]
        public int AdminID { get; set; }

        [Required]
        [MinLength(20)]
        public string Description { get; set; }

        [Required]
        public DateTime DateWriting { get; set; }
    }
}
