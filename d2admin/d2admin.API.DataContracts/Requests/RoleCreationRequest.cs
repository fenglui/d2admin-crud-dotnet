using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using d2admin.API.DataContracts;

namespace d2admin.API.DataContracts.Requests
{
    /// <summary>
    /// 创建角色请求
    /// </summary>
    public class RoleCreationRequest
    {
        /// <summary>
        /// 角色
        /// </summary>
        public Role Role { get; set; }
    }
}
