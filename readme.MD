# d2 admin dotnet core

## How to use

### install d2admin.API

in package manager

```console
Install-Package d2admin.API -Version 1.1.2
```

### modify appsettings.json

add a ConnectionString named D2AdminServiceContext
add qiniu cdn support
```json
{
  "ConnectionStrings": {
    "D2AdminServiceContext": "connect string of your database"
  },
  "QiniuMac": {
    "AccessKey": "AccessKey",
    "SecretKey": "SecretKey",
    "Bucket": "Bucket"
  }
}
```

### modify Startup.cs

add using

```csharp
using d2admin.IoC.Configuration.DI;
using d2admin.Services;
using Consts = d2admin.Services.Consts;
using S = d2admin.Services.Model;
```

in ConfigureServices methods

```csharp

           services.AddDbContext<D2AdminServiceContext>(options =>
options.UseSqlServer(Configuration.GetConnectionString("D2AdminServiceContext")));
            services.RegisterD2ContextService();
            services.RegisterTTNIdentityContextService<S.User, D2AdminServiceContext>();
            //Mappings
            services.ConfigureMappings();

            //Business settings            
            services.ConfigureBusinessServices(Configuration);

            services.ConfigureJwtTokenServices(
                secretString: Consts.SecretString,
                authenticationScheme: Consts.AuthenticationScheme,
                // 7 天
                ExpirationInSeconds: 7 * 24 * 60 * 60
            );
```

```console
update-database -context D2AdminServiceContext
```
