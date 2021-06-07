using Microsoft.AspNetCore.Identity;
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
    public class Role: IdentityRole
    {
        /// <summary>
        /// 角色代码
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string Code { get; set; }

        [JsonPropertyName("parent_id")]
        [MaxLength(450)]
        public string ParentId { get; set; }

        [JsonPropertyName("del_flag")]
        public bool DelFlag { get; set; }
    }
}
