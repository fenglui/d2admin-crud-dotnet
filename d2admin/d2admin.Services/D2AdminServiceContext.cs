using d2admin.Services.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace d2admin.Services
{
    public class D2AdminServiceContext : DbContext
    {
        public D2AdminServiceContext(DbContextOptions<D2AdminServiceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RoleResource> RoleResources { get; set; }

        public virtual DbSet<pm_resource> PermisionResources { get; set; }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<IdentityUserRole<String>> UserRoles { get; set; }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<CdnFile> CdnFiles { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("User");
            builder.Entity<Role>().ToTable("Role");
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogin");
                entity.HasKey(p => p.UserId);
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRole");
                entity.HasKey("RoleId", "UserId");
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserToken");
                entity.HasKey(p => p.UserId);
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaim");
                entity.HasKey(p => p.RoleId);
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaim");
                entity.HasKey(p => p.UserId);
            });

            builder.Entity<User>(entity =>
            {
                entity.Property(x => x.UserName).HasMaxLength(36).IsRequired();
                entity.HasIndex(p => p.UserName).IsUnique();
            });
        }
    }


    public class HnD2AdminServiceContextFactory : IDesignTimeDbContextFactory<D2AdminServiceContext>
    {
        public D2AdminServiceContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<D2AdminServiceContext>();

            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)       
            .AddJsonFile("appsettings.json")
            .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("‌​D2AdminServiceContext"));

            return new D2AdminServiceContext(optionsBuilder.Options);
        }
    }

}
