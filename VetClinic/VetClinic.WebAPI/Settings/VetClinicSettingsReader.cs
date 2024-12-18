namespace VetClinic.WebAPI.Settings
{
    public class VetClinicSettingsReader
    {
        public static VetClinicSettings Read(IConfiguration configuration)
        {
            return new VetClinicSettings()
            {
                VetClinicDbContextConnectionString = configuration.GetValue<string>("VetClinicDbContext"),
                IdentityServerUri = configuration.GetValue<string>("IdentityServerSettings:Uri"),
                ClientId = configuration.GetValue<string>("IdentityServerSettings:ClientId"),
                ClientSecret = configuration.GetValue<string>("IdentityServerSettings:ClientSecret")
            };
        }
    }
}
