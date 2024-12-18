namespace VetClinic.WebAPI.Controllers.Entities
{
    public class UpdateAdminRequest
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
