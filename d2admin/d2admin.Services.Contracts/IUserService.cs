﻿using d2admin.Services.Model;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace d2admin.Services.Contracts
{
    public interface IUserService
    {
        Task<IdentityResult> SetUserRoles(string userId, List<string> roleIds);

        Task<User> CreateAsync(User user, string password);

        //Task<User> CreateAsync(User user);

        Task<bool> UpdateAsync(User user);

        Task<bool> DeleteAsync(string id);

        Task<User> GetAsync(string id);
        PagedList<User> GetListAsync(int page, int limit);

        Task<List<string>> GetUserRoleIds(string userId);

        Task<List<Role>> GetUserRoles(string userId);

        Task<bool> ChangePasswordAsync(string userId, string oldPassword, string password);
    }
}
