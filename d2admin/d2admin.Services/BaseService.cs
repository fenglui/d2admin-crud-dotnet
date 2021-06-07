using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace d2admin.Services
{
    public abstract class BaseService: IDisposable // where T: D2AdminServiceContext, new()
    {
        D2AdminServiceContext _db;
        private bool disposedValue;

        protected D2AdminServiceContext db
        {
            get
            {
                if (null == _db)
                {
                    _db = new D2AdminServiceContext(d2Context.ServiceProvider.GetRequiredService<
                     DbContextOptions<D2AdminServiceContext>>());
                }
                return _db;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // 释放托管状态(托管对象)
                    if (null != db)
                    {
                        db.Dispose();
                    }
                }

                // TODO: 释放未托管的资源(未托管的对象)并替代终结器
                // TODO: 将大型字段设置为 null
                disposedValue = true;
            }
        }

        // // TODO: 仅当“Dispose(bool disposing)”拥有用于释放未托管资源的代码时才替代终结器
        // ~BaseService()
        // {
        //     // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
