using AutoMapper;
using d2admin.API.DataContracts;
using d2admin.API.DataContracts.Responses;
using d2admin.Services;
using d2admin.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DC = d2admin.API.DataContracts;
using S = d2admin.Services.Model;

namespace d2admin.API.Controllers.V2
{
    /// <summary>
    /// 
    /// </summary>
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/upload/qiniu")]
    [ApiController]
    public class QiniuController : Controller
    {
        private readonly QiniuMac _qiNiuMac;

        private readonly IQiniuService _service;

        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="qiNiuMac"></param>
        /// <param name="qiNiuService"></param>
        /// <param name="mapper"></param>
        public QiniuController(QiniuMac qiNiuMac, IQiniuService qiNiuService, IMapper mapper)
        {
            _qiNiuMac = qiNiuMac;
            _service = qiNiuService;
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
            Summary = "Cdn文件详情",
            Description = "获取一个Cdn文件的信息",
            OperationId = "GetCdnFile"
        )]
        [HttpGet("{id}")]
        public async Task<CdnFile> Get(int id)
        {
            var data = await _service.GetAsync(id);

            if (data != null)
                return _mapper.Map<CdnFile>(data);
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
        [SwaggerOperation(
            Summary = "添加Cdn文件",
            Description = "添加一个Cdn文件的信息",
            OperationId = "AddCdnFile"
        )]
        [HttpPost("add")]
        public async Task<DC.CdnFile> Create([FromBody] DC.CdnFile value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            var data = await _service.CreateAsync(_mapper.Map<S.CdnFile>(value));

            if (data != null)
            {
                return _mapper.Map<DC.CdnFile>(data);
            }
            else
                return null;

        }
        #endregion

        #region Update

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [SwaggerOperation(
            Summary = "更新Cdn文件信息",
            Description = "更新一个Cdn文件的信息",
            OperationId = "UpdateCdnFile"
        )]
        [HttpPost("update")]
        public async Task<bool> Update(CdnFile file)
        {
            if (file == null)
                throw new ArgumentNullException("file");

#if DEBUG
    Console.WriteLine($"Files is { file.Files }");
#endif

            return await _service.UpdateAsync(_mapper.Map<S.CdnFile>(file));
        }
#endregion

#region DELETE

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SwaggerOperation(
            Summary = "移除Cdn文件信息",
            Description = "移除一个Cdn文件的信息（虚拟删除）",
            OperationId = "DeleteCdnFile"
        )]
        [HttpPost("delete")]
        public async Task<bool> Delete(int id)
        {
            return await _service.DeleteAsync(id);
        }
#endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [SwaggerOperation(
            Summary = "获取CDN文件列表",
            OperationId = "ListCdnFile"
        )]

        [HttpGet("page")]
        public PagedListResponse<DC.CdnFile> Page(int current = 1, int size = 10)
        {
            var data = _service.GetListAsync(current, size);

            if (data != null)
            {
                var records = new List<DC.CdnFile>(1);
                foreach (var item in data)
                {
                    var mappedDepartment = _mapper.Map<CdnFile>(item);
                    records.Add(mappedDepartment);
                }

                return new PagedListResponse<DC.CdnFile>
                {
                    Code = 0,
                    Data = new PagedListDataItem<DC.CdnFile>
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
                    Msg = string.Empty
                };
            }

            else
                return null;
        }

        /// <summary>
        /// 获取七牛上传Token
        /// </summary>
        /// <example></example>
        [SwaggerOperation(
            Summary = "获取七牛上传Token",
            Description = "如传入key，需确保key保持唯一性，token将在60秒后失效",
            OperationId = "GetQiniuToken"
        )]
        [HttpGet("getToken")]
        public IActionResult GetToken(string key = "")
        {
            if (String.IsNullOrEmpty(key))
            {
                key = Guid.NewGuid().ToString();
            }
            int expires = 60;
            var token = QiniuHelper.GetToken(_qiNiuMac, key, expires);
            return Json(new
            {
                code = 0,
                data = new
                {
                    expires = expires,
                    token = token,
                    key = key
                },
                msg = string.Empty
            });
        }
    }
}
