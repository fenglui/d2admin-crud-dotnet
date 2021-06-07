using d2admin.Services.Contracts;
using d2admin.Services.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d2admin.Services
{
    public class QiniuService : BaseService, IQiniuService
    {
        public async Task<CdnFile> CreateAsync(CdnFile file)
        {
            if (null != file)
            {
                await db.CdnFiles.AddAsync(file);
                await db.SaveChangesAsync();
                return file;
            }
            return null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            CdnFile file = await db.CdnFiles.FindAsync(id);
            if (null != file)
            {
                //db.CdnFiles.Remove(department);
                file.IsDeleted = true;
                await db.SaveChangesAsync();
                return true;
            } else
            {
                Console.WriteLine($"file id { id } not found");
            }
            return false;
        }

        public async Task<CdnFile> GetAsync(int id)
        {
            CdnFile file = await db.CdnFiles.FindAsync(id);
            if (null != file)
            {
                return file;
            }
            return null;
        }

        public PagedList<CdnFile> GetListAsync(int page, int limit)
        {
            var files = db.CdnFiles.Where(x => x.IsDeleted == false).OrderBy(x => x.Id).GetPagedList(page, limit);
            if (null != files)
            {
                return files;
            }
            return null;
        }

        public async Task<bool> UpdateAsync(CdnFile file)
        {
            try
            {
                var entity = db.Attach<CdnFile>(file);
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
