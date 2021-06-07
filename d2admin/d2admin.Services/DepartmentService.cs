//using d2admin.Services.Contracts;
using d2admin.Services.Contracts;
using d2admin.Services.Model;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace d2admin.Services
{
    public class DepartmentService : BaseService, IDepartmentService
    {
        public async Task<Department> CreateAsync(Department department)
        {
            if (null != department)
            {
                await db.Departments.AddAsync(department);
                await db.SaveChangesAsync();
                return department;
            }
            return null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Department department = await db.Departments.FindAsync(id);
            if (null != department)
            {
                //db.Departments.Remove(department);
                department.IsDeleted = true;
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Department> GetAsync(int id)
        {
            Department department = await db.Departments.FindAsync(id);
            if (null != department)
            {
                return department;
            }
            return null;
        }

        public PagedList<Department> GetListAsync(int page, int limit)
        {
            var departments = db.Departments.Where(x => x.IsDeleted == false).OrderBy(x => x.Id).GetPagedList(page, limit);
            if (null != departments)
            {
                return departments;
            }
            return null;
        }

        public async Task<bool> UpdateAsync(Department department)
        {
            try
            {
                var entity = db.Attach<Department>(department);
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
