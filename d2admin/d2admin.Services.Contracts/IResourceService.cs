using d2admin.Services.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace d2admin.Services.Contracts
{
    public interface IResourceService
    {
        Task<pm_resource> CreateAsync(pm_resource pm);

        Task<bool> UpdateAsync(pm_resource pm);

        Task<bool> DeleteAsync(long id);


        Task<List<pm_resource>> GetResources();

        Task<List<pm_resource>> FindResourceTreeByRoleIds(List<string> roleIds);
    }
}
