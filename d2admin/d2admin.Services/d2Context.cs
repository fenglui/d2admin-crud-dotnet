using d2admin.Services.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace d2admin.Services
{
    public static class d2Context
    {
        public const string AdminRole = "Admin";

        public static IServiceProvider ServiceProvider { get; set; }

        public static void RegisterD2ContextService(this IServiceCollection services, ServiceLifetime lifeTime = ServiceLifetime.Scoped)
        {
            d2Context.ServiceProvider = services.BuildServiceProvider();
        }

        public static D2AdminServiceContext NewDataContext()
        {
            return new D2AdminServiceContext(
                ServiceProvider.GetRequiredService<
                    DbContextOptions<D2AdminServiceContext>>());
        }

        public static UserManager<User> GetUserManager()
        {
            return ServiceProvider.GetRequiredService<UserManager<User>>();
        }

        public static IPasswordHasher<User> GetPasswordHasher()
        {
            return ServiceProvider.GetRequiredService<IPasswordHasher<User>>();
        }
    }
}
