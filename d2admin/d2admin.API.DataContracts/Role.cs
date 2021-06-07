using System.ComponentModel.DataAnnotations;

namespace d2admin.API.DataContracts
{
    /// <summary>
    /// 
    /// </summary>
    public class Role
    {
        /// <summary>
        /// 
        /// </summary>
        [DataType(DataType.Text)]
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataType(DataType.Text)]
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataType(DataType.Text)]
        public string parentId { get; set; }
    }
}
