
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Microsoft.AspNetCore.Identity;

namespace d2admin.Services.Model
{
    public class User : IdentityUser
    {
        [MaxLength(300)]
        public string Avatar { get; set; }

        //[MaxLength(256)]
        //public string CallingCode { get; set; }

        public int Gender { get; set; }

        [MaxLength(256)]
        public string NickName { get; set; }

        public bool DelFlag { get; set; }

        [MaxLength(11)]
        public string Mobile { get; set; }

    }
}
