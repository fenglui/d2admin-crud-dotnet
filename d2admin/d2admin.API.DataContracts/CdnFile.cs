using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace d2admin.API.DataContracts
{
    /// <summary>
    /// 
    /// </summary>
    public class CdnFile
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [DataType(DataType.Text)]
        public string Avatar { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataType(DataType.Text)]
        public string Pictures { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataType(DataType.Text)]
        public string Images { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataType(DataType.Text)]
        public string File { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataType(DataType.Text)]
        public string Files { get; set; }
    }
}
