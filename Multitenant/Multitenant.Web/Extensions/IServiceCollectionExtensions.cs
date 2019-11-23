using Multitenant.Repository;
using Multitenant.Repository.SqlServer;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static void AddMultitenantConfiguration(this IServiceCollection services)
        {
            services.AddMultiTenant()
                    .WithEFCoreStore<AppDbContext, AppTenantInfo>()
                    .WithRouteStrategy();
            services.AddDbContext<SampleContext>();
        }

        public static void AddServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
