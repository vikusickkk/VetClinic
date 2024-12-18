namespace VetClinic.WebAPI.Settings
{
    public class VetClinicSettings
    {
        public string VetClinicDbContextConnectionString { get; set; }
        public string IdentityServerUri { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
