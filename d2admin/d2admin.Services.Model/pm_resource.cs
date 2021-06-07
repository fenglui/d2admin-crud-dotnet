using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace d2admin.Services.Model
{
    [Table("pm_resource")]
    public class pm_resource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        [MaxLength(255)]
        public string Title { get; set; }

        /// <summary>
        /// 权限代码
        /// </summary>
        [MaxLength(100)]
        public string Permission { get; set; }

        /// <summary>
        /// 前端路径
        /// </summary>
        [MaxLength(255)]
        public string Path { get; set; }

        /// <summary>
        /// 前端组件路径
        /// </summary>
        [MaxLength(255)]
        public string Component { get; set; }


        [MaxLength(50)]
        public string Icon { get; set; }

        /// <summary>
        /// 排序 DEFAULT 100
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 菜单类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 父节点
        /// </summary>
        [JsonPropertyName("parentId")]
        public long ParentId { get; set; }

        [JsonPropertyName("del_flag")]
        public bool DelFlag { get; set; }

        [JsonPropertyName("create_time")]
        public DateTime CreateTime { get; set; }

        [JsonPropertyName("update_time")]
        public DateTime UpdateTime { get; set; }

        public virtual ICollection<RoleResource> RoleResources { get; set; }
    }
}
