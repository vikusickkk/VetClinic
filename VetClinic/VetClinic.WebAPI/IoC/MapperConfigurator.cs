using VetClinic.BL.Mapper;
using VetClinic.WebAPI.Mapper;
namespace VetClinic.WebAPI.IoC
{
    public class MapperConfigurator
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile<AdminBLProfile>();
                config.AddProfile<ClientBLProfile>();
                config.AddProfile<ReviewBLProfile>();
                config.AddProfile<AdminsWebAPIProfile>();
                config.AddProfile<ClientsWebAPIProfile>();
                config.AddProfile<ReviewsWebAPIProfile>();
            });
        }
    }
}
