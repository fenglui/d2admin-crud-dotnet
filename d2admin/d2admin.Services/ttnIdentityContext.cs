//using Microsoft.EntityFrameworkCore;
using d2admin.Services.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace d2admin.Services
{
    public static class ttnIdentityContext
    {
        public const string AdminRole = "Admin";

        public static IServiceProvider ServiceProvider { get; set; }

        public static IServiceCollection RegisterTTNIdentityContextService<T, D>(this IServiceCollection services,
ServiceLifetime lifeTime = ServiceLifetime.Scoped) where T: User where D:D2AdminServiceContext
        {
            ttnIdentityContext.ServiceProvider = services.BuildServiceProvider();

            services.AddIdentity<T, Role>(options =>
            {
                // https://docs.microsoft.com/zh-cn/aspnet/core/security/authentication/accconfirm?view=aspnetcore-2.1&tabs=visual-studio
                // 阻止注册的用户登录，直到其电子邮件得到确认。

                // 用户设置
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;

                // 登录设置
                options.SignIn = new SignInOptions
                {
                    RequireConfirmedEmail = false,
                    RequireConfirmedAccount = false,
                    RequireConfirmedPhoneNumber = false
                };

                // 密码配置
                options.Password = new PasswordOptions
                {
                    RequiredLength = Consts.PasswordMinimumLength,
                    RequireUppercase = false,
                    RequireDigit = true,
                    RequiredUniqueChars = 0,
                    RequireLowercase = false,
                    RequireNonAlphanumeric = false
                };

                // Lockout settings.锁定设置
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
            })
            .AddEntityFrameworkStores<D>()
            .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings 缓存设置
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(10);

                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            //services.AddAuthentication().AddMicrosoftAccount(microsoftOptions =>
            //{
            //    microsoftOptions.ClientId = Configuration["Authentication:Microsoft:ClientId"];
            //    microsoftOptions.ClientSecret = Configuration["Authentication:Microsoft:ClientSecret"];
            //});

            return services;
        }
    }
}
