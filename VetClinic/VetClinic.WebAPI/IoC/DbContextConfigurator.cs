using VetClinic.DataAccess;
using VetClinic.WebAPI.Settings;
using Microsoft.EntityFrameworkCore;

namespace VetClinic.WebAPI.IoC
{
    public class DbContextConfigurator
    {
        public static void ConfigureService(IServiceCollection services, VetClinicSettings settings)
        {
            services.AddDbContextFactory<VetClinicDbContext>(
                options => { options.UseSqlServer(settings.VetClinicDbContextConnectionString); },
                ServiceLifetime.Scoped);
        }

        public static void ConfigureApplication(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<VetClinicDbContext>>();
            using var context = contextFactory.CreateDbContext();
            context.Database.Migrate();
        }
    }
}
