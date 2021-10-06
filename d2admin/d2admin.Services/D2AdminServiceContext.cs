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

            builder.Entity<Role>().HasData(
            new Role
            {
                Id = "6fadf7cf-baa8-401d-84f5-ae54c584ad4d",
                Code = "sa",
                Name = "sa",
                NormalizedName = "SA",
                ConcurrencyStamp = "dd26e84d-13be-4060-96dc-92384bca27ed"
            },
            new Role
            {
                Id = "2a74609c-66c2-410c-b1bb-139ce71056f5",
                Code = "admin",
                Name = "admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "354610ba-ab2a-4a34-a8e8-f9ab1c6866e3"
            }
            );

            builder.Entity<User>().HasData(
            new User
            {
                Id = "23a1557f-604d-4728-b011-a851da4a307b",
                NickName = "superadmin",
                UserName = "sa",
                Email = "fenglui@tuotuoniu.com",
                ConcurrencyStamp = "3ea81291-7aa5-41f0-b8e1-d35009e39821",
                PasswordHash = "AQAAAAEAACcQAAAAEK39qZGWC5IE9b6nSSOjKiwLJ3RrRO/LGet0KIHuoUeZ5bjaQcZn1o9d67H6ciLGfA==",
                SecurityStamp = "AR5AJQGFXQSIHLMWMPM4MCYKEVDFYVPM"
            }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                UserId = "23a1557f-604d-4728-b011-a851da4a307b",
                RoleId = "6fadf7cf-baa8-401d-84f5-ae54c584ad4d"
            }
            );

            builder.Entity<pm_resource>().HasData(
                new pm_resource
                {
                    Id = 1,
                    Name = "system",
                    Title = "系统管理",
                    Path = "/system",
                    Component = "layoutHeaderAside",
                    Sort = -10001,
                    Type = 1,
                    CreateTime = new DateTime(2021, 10, 1),
                    UpdateTime = new DateTime(2021, 10, 1),
                },
                new pm_resource
                {
                    Id = 2,
                    Name = "permission",
                    Title = "权限管理",
                    Sort = 1,
                    Type = 1,
                    ParentId = 1,
                    CreateTime = new DateTime(2021, 10, 1),
                    UpdateTime = new DateTime(2021, 10, 1),
                },
                new pm_resource
                {
                    Id = 3,
                    Name = "resource",
                    Title = "资源管理",
                    Permission = "permission:resource:view",
                    Path = "/permission/resource",
                    Component = "/permission/views/resource",
                    Icon = "address-book",
                    Sort = 90,
                    Type = 1,
                    ParentId = 2,
                    CreateTime = new DateTime(2021, 10, 1),
                    UpdateTime = new DateTime(2021, 10, 1),
                },
                new pm_resource
                {
                    Id = 4,
                    Name = "viewResource",
                    Title = "查看资源",
                    Permission = "permission:resource:view",
                    Icon = "eye",
                    Sort = 90,
                    Type = 2,
                    ParentId = 3,
                    CreateTime = new DateTime(2021, 10, 1),
                    UpdateTime = new DateTime(2021, 10, 1),
                },
                new pm_resource
                {
                    Id = 5,
                    Name = "addResource",
                    Title = "添加资源",
                    Permission = "permission:resource:add",
                    Sort = 100,
                    Type = 2,
                    ParentId = 3,
                    CreateTime = new DateTime(2021, 10, 1),
                    UpdateTime = new DateTime(2021, 10, 1),
                },
                new pm_resource
                {
                    Id = 6,
                    Name = "delResource",
                    Title = "添加资源",
                    Permission = "permission:resource:del",
                    Sort = 100,
                    Type = 2,
                    ParentId = 3,
                    CreateTime = new DateTime(2021, 10, 1),
                    UpdateTime = new DateTime(2021, 10, 1),
                },
                new pm_resource
                {
                    Id = 7,
                    Name = "role",
                    Title = "角色管理",
                    Permission = "permission:role:view",
                    Path = "/permission/role",
                    Component = "/permission/views/role",
                    Sort = 100,
                    Type = 1,
                    ParentId = 2,
                    CreateTime = new DateTime(2021, 10, 1),
                    UpdateTime = new DateTime(2021, 10, 1),
                },
                new pm_resource
                {
                    Id = 8,
                    Name = "viewRole",
                    Title = "查看角色",
                    Permission = "permission:role:view",
                    Icon = "eye",
                    Sort = 90,
                    Type = 2,
                    ParentId = 7,
                    CreateTime = new DateTime(2021, 10, 1),
                    UpdateTime = new DateTime(2021, 10, 1),
                },
                new pm_resource
                {
                    Id = 9,
                    Name = "addRole",
                    Title = "添加角色",
                    Permission = "permission:role:add",
                    Sort = 100,
                    Type = 2,
                    ParentId = 7,
                    CreateTime = new DateTime(2021, 10, 1),
                    UpdateTime = new DateTime(2021, 10, 1),
                },
                new pm_resource
                {
                    Id = 10,
                    Name = "editRole",
                    Title = "修改角色",
                    Permission = "permission:role:edit",
                    Sort = 100,
                    Type = 2,
                    ParentId = 7,
                    CreateTime = new DateTime(2021, 10, 1),
                    UpdateTime = new DateTime(2021, 10, 1),
                },
                new pm_resource
                {
                    Id = 11,
                    Name = "editResource",
                    Title = "修改角色",
                    Permission = "permission:resource:edit",
                    Sort = 100,
                    Type = 2,
                    ParentId = 3,
                    CreateTime = new DateTime(2021, 10, 1),
                    UpdateTime = new DateTime(2021, 10, 1),
                },
                new pm_resource
                {
                    Id = 12,
                    Name = "delRole",
                    Title = "删除角色",
                    Permission = "permission:role:del",
                    Sort = 100,
                    Type = 2,
                    ParentId = 7,
                    CreateTime = new DateTime(2021, 10, 1),
                    UpdateTime = new DateTime(2021, 10, 1),
                },
                new pm_resource
                {
                    Id = 13,
                    Name = "authzRole",
                    Title = "分配权限",
                    Permission = "permission:role:authz",
                    Sort = 100,
                    Type = 2,
                    ParentId = 7,
                    CreateTime = new DateTime(2021, 10, 1),
                    UpdateTime = new DateTime(2021, 10, 1),
                },
                new pm_resource
                {
                    Id = 14,
                    Name = "user",
                    Title = "用户管理",
                    Permission = "usersphere:user:view",
                    Path = "/usersphere/user",
                    Component = "/usersphere/views/user",
                    Icon = "user",
                    Sort = 110,
                    Type = 1,
                    ParentId = 1,
                    CreateTime = new DateTime(2021, 10, 1),
                    UpdateTime = new DateTime(2021, 10, 1),
                },
                new pm_resource
                {
                    Id = 15,
                    Name = "addUser",
                    Title = "添加用户",
                    Permission = "usersphere:user:add",
                    Sort = 110,
                    Type = 2,
                    ParentId = 14,
                    CreateTime = new DateTime(2021, 10, 1),
                    UpdateTime = new DateTime(2021, 10, 1),
                },
                new pm_resource
                {
                    Id = 16,
                    Name = "editUser",
                    Title = "编辑用户",
                    Permission = "usersphere:user:edit",
                    Sort = 110,
                    Type = 2,
                    ParentId = 14,
                    CreateTime = new DateTime(2021, 10, 1),
                    UpdateTime = new DateTime(2021, 10, 1),
                },
                new pm_resource
                {
                    Id = 17,
                    Name = "delUser",
                    Title = "删除用户",
                    Permission = "usersphere:user:del",
                    Sort = 110,
                    Type = 2,
                    ParentId = 14,
                    CreateTime = new DateTime(2021, 10, 1),
                    UpdateTime = new DateTime(2021, 10, 1),
                },
                new pm_resource
                {
                    Id = 18,
                    Name = "authzUser",
                    Title = "分配角色",
                    Permission = "usersphere:user:authz",
                    Sort = 110,
                    Type = 2,
                    ParentId = 14,
                    CreateTime = new DateTime(2021, 10, 1),
                    UpdateTime = new DateTime(2021, 10, 1),
                }
            );

        }
    }


    public class HnD2AdminServiceContextFactory : IDesignTimeDbContextFactory<D2AdminServiceContext>
    {
        public D2AdminServiceContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<D2AdminServiceContext>();

            string cfgFile = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "D2AdminServiceContext.conn");
            bool appCfgExists = System.IO.File.Exists(cfgFile);
            Console.WriteLine($"D2AdminServiceContext.conn is { appCfgExists }");
            string connStr = string.Empty;
            if (appCfgExists)
            {
                connStr = System.IO.File.ReadAllText(cfgFile);
                Console.WriteLine($"cfgFile is { System.IO.File.ReadAllText(cfgFile) }");
            }

            optionsBuilder.UseSqlServer(connStr);

            return new D2AdminServiceContext(optionsBuilder.Options);
        }
    }

}
