using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using d2admin.API.DataContracts;
using d2admin.Services;
using d2admin.Services.Contracts;
using d2admin.Services.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace d2admin.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize(AuthenticationSchemes = Consts.AuthenticationScheme)]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/auth/user")]
    [ApiController]
    public class AuthUserController : Controller
    {
        private readonly IUserService _service;
        private readonly IResourceService _resourceService;

        private readonly IMapper _mapper;

#pragma warning disable CS1591
        public AuthUserController(IUserService service, IResourceService resourceService, IMapper mapper)
        {
            _service = service;
            _resourceService = resourceService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "获取当前用户信息",
            OperationId = "GetUserInfo"
        )]
        [HttpGet("info")]
        public async Task<IActionResult> GetInfo()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            d2admin.Services.Model.User user = await _service.GetAsync(userId);
            return Json(user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("permissions")]
        public async Task<IActionResult> GetPermissions()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<string> roleIds = await _service.GetUserRoleIds(userId);
            var list = await _resourceService.FindResourceTreeByRoleIds(roleIds);
            var roots = list.Where(x => x.ParentId == 0).Select(x =>

                _mapper.Map<ParentUserPermission>(x)).ToArray();

            foreach (var root in roots)
            {
                root.Children = list.Where(x => x.ParentId == root.Id).Select(x =>

                _mapper.Map<ParentUserPermission>(x)).ToList();

                foreach (var l2 in root.Children)
                {
                    l2.Children = list.Where(x => x.ParentId == l2.Id).Select(x =>

                _mapper.Map<ParentUserPermission>(x)).ToList();

                    foreach (var l3 in l2.Children)
                    {
                        l3.Children = list.Where(x => x.ParentId == l3.Id).Select(x =>

                    _mapper.Map<ParentUserPermission>(x)).ToList();
                    }
                }
            }

            return Json(new { code = 0, msg = String.Empty, data = roots });
        }

    }
}
