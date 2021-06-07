using d2admin.Services.Model;
using System.Data;
using System.Threading.Tasks;

namespace d2admin.Services.Contracts
{
    public interface IQiniuService
    {
        Task<CdnFile> CreateAsync(CdnFile file);

        Task<bool> UpdateAsync(CdnFile file);

        Task<bool> DeleteAsync(int id);

        Task<CdnFile> GetAsync(int id);

        PagedList<CdnFile> GetListAsync(int page, int limit);
    }
}
