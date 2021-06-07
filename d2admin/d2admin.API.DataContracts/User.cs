using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace d2admin.API.DataContracts
{
    /// <summary>
    /// User datacontract summary to be replaced
    /// </summary>
    public class User
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
        public string UserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataType(DataType.Text)]
        public string OldPassword { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataType(DataType.Text)]
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataType(DataType.Text)]
        public string CallingCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public string NickName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataType(DataType.Text)]
        public string Mobile { get; set; }

        /// <summary>
        /// 
        /// </summary>
        // [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataType(DataType.ImageUrl)]
        public string Avatar { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> Roles { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool DelFlag { get; set; }
    }
}
