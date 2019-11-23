using Finbuckle.MultiTenant;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Microsoft.AspNetCore.Builder
{
    public static class IApplicationBuilderExtensions
    {
        public static void UseMultitenantStrategy(this IApplicationBuilder app)
        {
            app.UseMultiTenant();
            SetupStore(app.ApplicationServices);
        }

        private static void SetupStore(IServiceProvider serviceProvider)
        {
            var scopeServices = serviceProvider.CreateScope().ServiceProvider;
            var store = scopeServices.GetRequiredService<IMultiTenantStore>();

            store.TryAddAsync(new TenantInfo("tenant-a-d043favoiaw", "tenant-a", "Tenant EIRL", "Server=localhost\\SQLEXPRESS;Database=TenantA;Trusted_Connection=True;", null)).Wait();
            store.TryAddAsync(new TenantInfo("tenant-b-341ojadsfa", "tenant-b", "Tenant LLC", "Server=localhost\\SQLEXPRESS;Database=TenantB;Trusted_Connection=True;", null)).Wait();
        }
    }
}