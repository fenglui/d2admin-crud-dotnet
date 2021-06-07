using d2admin.Services.Model;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace d2admin.Services.Contracts
{
    public interface IRoleService
    {
        Task<Role> CreateAsync(Role role);

        Task<bool> UpdateAsync(Role role);

        Task<bool> DeleteAsync(string id);

        Task<Role> GetAsync(string id);
        PagedList<Role> GetListAsync(int page, int limit);

        Task<bool> Authz(string roleId, List<long> resourceIds);

        Task<List<long>> GetResourceIdsByRoleId(string roleId);

        Task<List<Role>> GetRoleList();
    }
}
