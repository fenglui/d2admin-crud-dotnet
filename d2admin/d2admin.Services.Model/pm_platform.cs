using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d2admin.Services.Model
{
    /// <summary>
    /// 平台
    /// </summary>
    [Table("pm_platform")]
    public class pm_platform
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        /// <summary>
        /// 平台名称
        /// </summary>
        [MaxLength(255)]
        public string name { get; set; }

        /// <summary>
        /// 平台代码
        /// </summary>
        [MaxLength(255)]
        public string code { get; set; }

        [Column("del_flag")]
        public bool delFlag { get; set; }

        [Column("create_time")]
        public DateTime createTime { get; set; }

        [Column("update_time")]
        public DateTime updateTime { get; set; }
    }
}
