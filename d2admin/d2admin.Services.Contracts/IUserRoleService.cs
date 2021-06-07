using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d2admin.Services.Contracts
{
    public interface IUserRoleService
    {
        Task<List<IdentityUserRole<String>>> GetByUserIds(List<String> userIds);
    }
}
