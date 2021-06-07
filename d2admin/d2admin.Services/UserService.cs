using AutoMapper;
using d2admin.Services.Contracts;
using d2admin.Services.Model;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace d2admin.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly UserManager<User> _userManager;

        public UserService(IMapper mapper, IPasswordHasher<User> passwordHasher, UserManager<User> userManager)
        {
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _userManager = userManager;
        }

        public async Task<IdentityResult> SetUserRoles(string userId, List<string> roleIds)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var roles = await db.Roles.Where(x => roleIds.Contains(x.Id)).Select(x => x.Name).ToListAsync();
            return await _userManager.AddToRolesAsync(user, roles);
        }

        public async Task<User> CreateAsync(User data, string password)
        {
            User user = new User
            {
                UserName = data.UserName,
                Mobile = data.Mobile,
                NickName = data.NickName,
                Email = data.Email,
                Gender = data.Gender,
                Avatar = data.Avatar
            };
            var res = await _userManager.CreateAsync(user, password);
            return user;
        }

        public async Task<bool> UpdateAsync(User data)
        {
            try
            {
                var user = await db.Users.FindAsync(data.Id);
                user.NickName = data.NickName;
                user.Mobile = data.Mobile;
                user.Avatar = data.Avatar;
                user.Gender = data.Gender;
                user.Email = data.Email;
                user.NormalizedEmail = data.Email.ToUpper();
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
            }
            return false;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var user = await db.Users.FindAsync(id);
            if (null != user)
            {
                user.DelFlag = true;
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<User> GetAsync(string id)
        {
            var user = await db.Users.FindAsync(id);
            if (null != user)
            {
                return user;
            }
            return null;
        }

        public PagedList<User> GetListAsync(int page, int limit)
        {
            var users = db.Users.Where(x => x.DelFlag == false).GetPagedList(page, limit);
            if (null != users)
            {
                return users;
            }
            return null;
        }

        public async Task<List<string>> GetUserRoleIds(string userId)
        {
            return await db.UserRoles.Where(x => x.UserId == userId).Select(x => x.RoleId).ToListAsync();
        }

        public async Task<bool> ChangePasswordAsync(string userId, string oldPassword, string password)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var res = await _userManager.ChangePasswordAsync(user, oldPassword, password);
            return res.Succeeded;
        }

        public async Task<List<Role>> GetUserRoles(string userId)
        {
            var roleIds = await this.GetUserRoleIds(userId);

            return await db.Roles.Where(x => x.DelFlag == false && roleIds.Contains(x.Id)).ToListAsync();
        }
    }
}
