using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using d2admin.Services.Model;

namespace d2admin.Services.Contracts
{
    public interface IDepartmentService
    {
        Task<Department> CreateAsync(Department department);

        Task<bool> UpdateAsync(Department department);

        Task<bool> DeleteAsync(int id);

        Task<Department> GetAsync(int id);
        PagedList<Department> GetListAsync(int page, int limit);
    }
}
