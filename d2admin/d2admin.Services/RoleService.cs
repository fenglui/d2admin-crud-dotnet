using d2admin.Services.Contracts;
using d2admin.Services.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d2admin.Services
{
    public class RoleService : BaseService, IRoleService
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleService(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<Role> CreateAsync(Role role)
        {
            if (null != role)
            {
                role.Id = Guid.NewGuid().ToString();
                await _roleManager.CreateAsync(role);
                return role;
            }
            return null;
        }

        public async Task<bool> UpdateAsync(Role role)
        {
            try
            {
                role.NormalizedName = role.Name;
                var entity = db.Attach<Role>(role);
                entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var role = await db.Roles.FindAsync(id);
            if (null != role)
            {
                role.DelFlag = true;
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Role> GetAsync(string id)
        {
            var role = await db.Roles.FindAsync(id);
            if (null != role)
            {
                return role;
            }
            return null;
        }

        public PagedList<Role> GetListAsync(int page, int limit)
        {
            var roles = db.Roles.Where(x => x.DelFlag == false).OrderBy(x => x.Id).GetPagedList(page, limit);
            if (null != roles)
            {
                return roles;
            }
            return null;
        }

        public async Task<bool> Authz(string roleId, List<long> resourceIds)
        {
            //先删除roleId所有的权限
            await db.Database.ExecuteSqlRawAsync($"delete from pm_role_resource where RoleId=N'{ roleId }'");
            // 然后再添加
            foreach (long resourceId in resourceIds)
            {
                RoleResource res = new RoleResource
                {
                    CreateTime = DateTime.Now,
                    UpdateTime = DateTime.Now,
                    DelFlag = false,
                    ResourceId = resourceId,
                    RoleId = roleId
                };

                await db.RoleResources.AddAsync(res);
            }
            try
            {
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<List<long>> GetResourceIdsByRoleId(string roleId)
        {
            return await db.RoleResources.Where(x => x.RoleId == roleId).Select(x => x.ResourceId).ToListAsync();
        }

        public async Task<List<Role>> GetRoleList()
        {
            return await db.Roles.Where(x => x.DelFlag == false).ToListAsync();
        }
    }
}
