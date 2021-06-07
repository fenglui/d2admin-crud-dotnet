using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
        public String Pictures { get; set; }

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
    }
}
