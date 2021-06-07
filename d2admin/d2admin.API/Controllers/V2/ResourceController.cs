using AutoMapper;
using d2admin.API.DataContracts;
using d2admin.Services;
using d2admin.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
    [Route("api/v{version:apiVersion}/resource")]
    [ApiController]
    public class ResourceController : Controller
    {
        private readonly IResourceService _service;
        private readonly IMapper _mapper;

#pragma warning disable CS1591
        public ResourceController(IResourceService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        #region 新增

        [HttpPost("add")]
        public async Task<DC.ParentUserPermission> Create([FromBody] S.pm_resource permission)
        {

            //TODO: include exception management policy according to technical specifications
            if (permission == null)
                throw new ArgumentNullException("value");


            S.pm_resource data = await _service.CreateAsync(permission);

            if (data != null)
                return _mapper.Map<DC.ParentUserPermission>(data);
            // return Json(new { code = 0, msg = String.Empty, data = data.Id });
            else
                return null;

        }
        #endregion

        #region 修改
        [HttpPost("update")]
        public async Task<bool> Update(S.pm_resource permission)
        {
            if (permission == null)
                throw new ArgumentNullException("permission");

            return await _service.UpdateAsync(permission);
        }
        #endregion

        #region 获取权限
        [HttpGet("tree")]
        public async Task<IActionResult> Tree()
        {
            var list = await _service.GetResources();
            var roots = list.Where(x => x.ParentId == 0).Select(x =>

                _mapper.Map<ParentUserPermission>(x)).ToList();

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
        #endregion
    }
}
