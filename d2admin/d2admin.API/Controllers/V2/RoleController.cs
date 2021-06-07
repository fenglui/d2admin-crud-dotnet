using AutoMapper;
using d2admin.API.DataContracts.Requests;
using d2admin.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using S = d2admin.Services.Model;
using DC = d2admin.API.DataContracts;
using d2admin.API.DataContracts.Responses;
using Microsoft.AspNetCore.Authorization;
using d2admin.Services;

namespace d2admin.API.Controllers.V2
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize(AuthenticationSchemes = Consts.AuthenticationScheme)]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/roles")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IRoleService _service;
        private readonly IMapper _mapper;

#pragma warning disable CS1591
        public RoleController(IRoleService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        #region 分页查询
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="current"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [HttpGet("page")]
        public PagedListResponse<DC.Role> Page(int current = 1, int size = 10)
        {
            var data = _service.GetListAsync(current, size);

            if (data != null)
            {
                //var userIds = data.Select(x => x.Id).ToList();
                //var roles = await _userRoleService.GetByUserIds(userIds);
                var records = new List<DC.Role>(1);
                foreach (var item in data)
                {
                    var mappedUser = _mapper.Map<DC.Role>(item);
                    records.Add(mappedUser);
                }

                return new PagedListResponse<DC.Role>
                {
                    Code = 0,
                    Data = new PagedListDataItem<DC.Role>
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

        #endregion

        #region 通过id查询
        /// <summary>
        /// 通过id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<DC.Role> Get(string id)
        {
            var data = await _service.GetAsync(id);

            if (data != null)
                return _mapper.Map<DC.Role>(data);
            else
                return null;
        }
        #endregion

        #region 新增

        [HttpPost("add")]
        public async Task<IActionResult> CreateRole([FromBody] DC.Role role)
        {

            //TODO: include exception management policy according to technical specifications
            if (role == null)
                throw new ArgumentNullException("value");


            S.Role data = await _service.CreateAsync(_mapper.Map<S.Role>(role));

            if (data != null)
                //return _mapper.Map<DC.Role>(data);
                return Json(new { code = 0, msg = String.Empty, data = data.Id });
            else
                return null;

        }
        #endregion

        #region 修改
        [HttpPost("update")]
        public async Task<bool> UpdateRole(DC.Role role)
        {
            if (role == null)
                throw new ArgumentNullException("role");

            return await _service.UpdateAsync(_mapper.Map<S.Role>(role));
        }
        #endregion

        #region 通过id删除
        [HttpPost("delete")]
        public async Task<bool> DeleteRole(string id)
        {
            if (String.IsNullOrEmpty(id))
                throw new ArgumentNullException("id");

            return await _service.DeleteAsync(id);
        }
        #endregion

        #region 给角色授予权限
        [HttpPost("authz")]
        public async Task<bool> Auth(string roleId, [FromBody] List<long> resourceIds)
        {
            return await _service.Authz(roleId, resourceIds);
        }
        #endregion

        #region 获取权限
        [HttpGet("getPermission")]
        public async Task<IActionResult> GetPermission(string roleId)
        {
            var data = await _service.GetResourceIdsByRoleId(roleId);
            return Json(new { code = 0, data = data });
        }
        #endregion

        #region 获取角色列表
        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var data = await _service.GetRoleList();
            //return data.Select(x =>
            //_mapper.Map<DC.Role>(x)
            //).ToList();

            return Json(new
            {
                code = 0,
                msg = String.Empty,
                data = data.Select(x =>
                        _mapper.Map<DC.Role>(x)
                    ).ToList()
            });
        }
        #endregion
    }
}
