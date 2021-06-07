using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using d2admin.Services.Contracts;
using d2admin.Services.Model;
using Microsoft.EntityFrameworkCore;

namespace d2admin.Services
{
    public class ResourceService : BaseService, IResourceService
    {
        public async Task<pm_resource> CreateAsync(pm_resource pm)
        {
            if (null != pm)
            {
                pm.CreateTime = pm.UpdateTime = DateTime.Now;
                await db.PermisionResources.AddAsync(pm);
                await db.SaveChangesAsync();
                return pm;
            }
            return null;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var pm = await db.PermisionResources.FindAsync(id);
            if (null != pm)
            {
                pm.DelFlag = true;
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<pm_resource>> FindResourceTreeByRoleIds(List<string> roleIds)
        {
            return await db.PermisionResources.AsNoTracking().Where(x => x.RoleResources.Any(y=> roleIds.Contains(y.RoleId))).ToListAsync();
        }

        public async Task<List<pm_resource>> GetResources()
        {
            return await db.PermisionResources.AsNoTracking().ToListAsync();
        }

        public async Task<bool> UpdateAsync(pm_resource pm)
        {
            try
            {
                pm.UpdateTime = DateTime.Now;
                var entity = db.Attach<pm_resource>(pm);
                entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }
    }
}
