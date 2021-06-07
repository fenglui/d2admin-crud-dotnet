using d2admin.Services;
using d2admin.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace d2admin.IoC.Configuration.DI
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (services != null)
            {
                services.AddTransient<IUserService, UserService>();

                services.AddTransient<IRoleService, RoleService>();

                services.AddTransient<IUserRoleService, UserRoleService>();

                services.AddTransient<IResourceService, ResourceService>();

                services.AddTransient<IDepartmentService, DepartmentService>();

                services.AddTransient<IQiniuService, QiniuService>();

                var dd = configuration.GetSection("QiniuMac");
                if (null != dd)
                {
                    var mac = dd.Get<QiniuMac>();
                    Console.WriteLine($"{ mac.AccessKey }");
                    services.AddSingleton(typeof(QiniuMac), mac);
                }
            }
        }

        public static void ConfigureMappings(this IServiceCollection services)
        {
            if (services != null)
            {
                //Automap settings
                services.AddAutoMapper(Assembly.GetExecutingAssembly());
            }
        }
    }
}
