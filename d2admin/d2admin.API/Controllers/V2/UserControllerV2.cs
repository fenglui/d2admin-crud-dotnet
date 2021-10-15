using AutoMapper;
using d2admin.API.DataContracts;
using d2admin.API.DataContracts.Requests;
using d2admin.API.DataContracts.Responses;
using d2admin.Services;
using d2admin.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DC = d2admin.API.DataContracts;
using S = d2admin.Services.Model;

namespace d2admin.API.Controllers.V2
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize(AuthenticationSchemes = Consts.AuthenticationScheme)]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _service;
        private readonly IUserRoleService _userRoleService;
        private readonly IMapper _mapper;

#pragma warning disable CS1591
        public UserController(IUserService service, IUserRoleService userRoleService, IMapper mapper)
        {
            _service = service;
            _userRoleService = userRoleService;
            _mapper = mapper;
        }
#pragma warning restore CS1591

        #region GET
        /// <summary>
        /// Comments and descriptions can be added to every endpoint using XML comments.
        /// </summary>
        /// <remarks>
        /// XML comments included in controllers will be extracted and injected in Swagger/OpenAPI file.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<User> Get(string id)
        {
            var data = await _service.GetAsync(id);

            if (data != null)
                return _mapper.Map<User>(data);
            else
                return null;
        }
        #endregion

        #region POST

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<User> CreateUser([FromBody] UserCreationRequest value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            if (value == null)
                throw new ArgumentNullException("value.User");


            var data = await _service.CreateAsync(_mapper.Map<S.User>(value.User), value.Password);

            if (data != null)
                return _mapper.Map<User>(data);
            else
                return null;

        }
        #endregion

        #region update

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("update")]
        public async Task<bool> UpdateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            Console.WriteLine($"nick { user.NickName }");

            if (String.IsNullOrEmpty(user.Password) == false)
            {
                bool changePasswordSuccess = await _service.ChangePasswordAsync(user.Id, user.OldPassword, user.Password);

                if (!changePasswordSuccess)
                {
                    return false;
                }
            }

            return await _service.UpdateAsync(_mapper.Map<S.User>(user));
        }
        #endregion

        #region DELETE

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("delete")]
        public async Task<bool> Delete(string id)
        {
            if (String.IsNullOrEmpty(id))
                throw new ArgumentNullException("id");

            return await _service.DeleteAsync(id);
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [HttpGet("page")]
        public async Task<PagedListResponse<DC.User>> Page(int current = 1, int size = 10)
        {
            var data = _service.GetListAsync(current, size);

            if (data != null)
            {
                var userIds = data.Select(x => x.Id).ToList();
                var roles = await _userRoleService.GetByUserIds(userIds);
                var records = new List<DC.User>(1);
                foreach (var item in data)
                {
                    var mappedUser = _mapper.Map<User>(item);
                    mappedUser.Roles = roles.Where(x => x.UserId == item.Id).Select(x => x.RoleId).ToList();
                    records.Add(mappedUser);
                }

                return new PagedListResponse<DC.User>
                {
                    Code = 0,
                    Data = new PagedListDataItem<DC.User>
                    {
                        Current = data.CurrentPageIndex,
                        Orders = new List<SortOption>
                        {
                            new SortOption{
                                Asc = true,
                                Column = "id"
                            }
                        },
                        Pages = data.PageCount,
                        Records = records,
                        SearchCount = true,
                        Size = data.PageSize,
                        Total = data.TotalItemCount
                    },
                    Msg = String.Empty
                };
            }

            else
                return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public string UserId
        {
            get
            {
                return User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }

        #region 给用户授予角色

        /// <summary>
        /// 给用户授予角色
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        [HttpPost("authz")]
        public async Task<IActionResult> Auth(string userId, [FromBody] List<string> roleIds)
        {
            var res = await _service.SetUserRoles(userId, roleIds);
            return Json(new
            {
                succeeded = res.Succeeded
            });
        }
        #endregion
    }
}
