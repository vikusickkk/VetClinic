using VetClinic.BL.Admins;
using VetClinic.BL.Clients;
using VetClinic.BL.Reviews;
using VetClinic.DataAccess;

namespace VetClinic.WebAPI.IoC
{
    public class ServicesConfigurator
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAdminsProvider, AdminsProvider>();
            services.AddScoped<IAdminsManager, AdminsManager>();
            services.AddScoped<IClientsProvider, ClientsProvider>();
            services.AddScoped<IClientsManager, ClientsManager>();
            services.AddScoped<IReviewsProvider, ReviewsProvider>();
            services.AddScoped<IReviewsManager, ReviewsManager>();
        }
    }
}
