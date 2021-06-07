using System;

namespace d2admin.API.DataContracts.Requests
{
    /// <summary>
    /// 
    /// </summary>
    public class UserCreationRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public String Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public User User { get; set; }
    }
}
