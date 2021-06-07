using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace d2admin.API.DataContracts
{
    /// <summary>
    /// 部门
    /// </summary>
    public class Department
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        /// <summary>
        /// 一句话介绍
        /// </summary>
        public string Intro { get; set; }


        /// <summary>
        /// 首字母
        /// </summary>
        [JsonPropertyName("firstLetter")]
        public string FirstLetter { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }
    }
}
