using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace d2admin.Services.Model
{
    [Table("pm_role_resource")]
    public class RoleResource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [JsonPropertyName("role_id")]
        [MaxLength(450)]
        public string RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        [JsonPropertyName("resource_id")]
        public long ResourceId { get; set; }

        [ForeignKey("ResourceId")]
        public virtual pm_resource Resource { get; set; }

        [JsonPropertyName("del_flag")]
        public bool DelFlag { get; set; }

        [JsonPropertyName("create_time")]
        public DateTime CreateTime { get; set; }

        [JsonPropertyName("update_time")]
        public DateTime UpdateTime { get; set; }
    }
}
