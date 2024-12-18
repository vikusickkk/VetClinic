namespace VetClinic.WebAPI.Controllers.Entities
{
    public class UpdateClientRequest
    {
        public string NameClient { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
