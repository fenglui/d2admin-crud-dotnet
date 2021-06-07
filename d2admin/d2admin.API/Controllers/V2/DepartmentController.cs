using AutoMapper;
using d2admin.API.DataContracts;
//using d2admin.API.DataContracts.Requests;
using d2admin.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using S = d2admin.Services.Model;
using DC = d2admin.API.DataContracts;
using d2admin.API.DataContracts.Responses;
using Microsoft.AspNetCore.Authorization;
using d2admin.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace d2admin.API.Controllers.V2
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize(AuthenticationSchemes = Consts.AuthenticationScheme)]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/department")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _service;
        private readonly IMapper _mapper;

#pragma warning disable CS1591
        public DepartmentController(IDepartmentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        #region GET
        /// <summary>
        /// Comments and descriptions can be added to every endpoint using XML comments.
        /// </summary>
        /// <remarks>
        /// XML comments included in controllers will be extracted and injected in Swagger/OpenAPI file.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [SwaggerOperation(
            Summary = "部门详情",
            Description = "获取一个部门的信息",
            OperationId = "GetDepartment"
        )]
        [HttpGet("{id}")]
        public async Task<Department> Get(int id)
        {
            var data = await _service.GetAsync(id);

            if (data != null)
                return _mapper.Map<Department>(data);
            else
                return null;
        }
        #endregion

        #region POST

        [SwaggerOperation(
            Summary = "添加部门",
            Description = "添加一个部门的信息",
            OperationId = "AddDepartment"
        )]
        [HttpPost("add")]
        public async Task<DC.Department> Create([FromBody] DC.Department value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            var data = await _service.CreateAsync(_mapper.Map<S.Department>(value));

            if (data != null)
            {
                return _mapper.Map<DC.Department>(data);
            }
            else
                return null;

        }
        #endregion

        #region Update

        [SwaggerOperation(
            Summary = "更新部门信息",
            Description = "更新一个部门的信息",
            OperationId = "UpdateDepartment"
        )]
        [HttpPost("update")]
        public async Task<bool> UpdateDepartment(Department department)
        {
            if (department == null)
                throw new ArgumentNullException("department");

            return await _service.UpdateAsync(_mapper.Map<S.Department>(department));
        }
        #endregion

        #region DELETE

        [SwaggerOperation(
            Summary = "移除部门信息",
            Description = "移除一个部门的信息（虚拟删除）",
            OperationId = "DeleteDepartment"
        )]
        [HttpPost("delete")]
        public async Task<bool> DeleteDepartment(int id)
        {
            return await _service.DeleteAsync(id);
        }
        #endregion

        [SwaggerOperation(
            Summary = "获取部门列表",
            OperationId = "ListDepartment"
        )]
        [HttpGet("page")]
        public PagedListResponse<DC.Department> Page(int current = 1, int size = 10)
        {
            var data = _service.GetListAsync(current, size);

            if (data != null)
            {
                var records = new List<DC.Department>(1);
                foreach (var item in data)
                {
                    var mappedDepartment = _mapper.Map<Department>(item);
                    records.Add(mappedDepartment);
                }

                return new PagedListResponse<DC.Department>
                {
                    Code = 0,
                    Data = new PagedListDataItem<DC.Department>
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

        [SwaggerOperation(
            Summary = "获取部门索引",
            Description = "选择器试用。包括name,value,label,color信息",
            OperationId = "DictDepartment"
        )]
        [AllowAnonymous]
        [HttpGet("dict")]
        public IActionResult Dict(int current = 1, int size = 300)
        {
            var data = _service.GetListAsync(current, size);

            var dict = data.Select(x => new {
            
                name = x.Name,
                value = x.Id,
                label = x.Name,
                color = "#000000"
            });

            return Json(new { data = dict });
        }
    }
}
