using d2admin.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d2admin.Services
{
    public class UserRoleService : BaseService, IUserRoleService
    {
        public async Task<List<IdentityUserRole<String>>> GetByUserIds(List<String> userIds)
        {
            return await db.UserRoles.Where(x => userIds.Contains(x.UserId)).ToListAsync();
        }
    }
}
