using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace d2admin.API.DataContracts
{
    /// <summary>
    /// 
    /// </summary>
    public class UserPermission
    {
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Permission { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Component { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long ParentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("delFlag")]
        public bool DelFlag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("createTime")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("updateTime")]
        public DateTime? UpdateTime { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ParentUserPermission: UserPermission
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("children")]
        public List<ParentUserPermission> Children { get; set; }
    }
}
