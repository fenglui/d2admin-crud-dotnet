using System;
using System.Collections.Generic;

namespace d2admin.Services
{
    public class Consts
    {
        public const String AuthenticationScheme = "Bearer";
        public const String SecretString = "[]d2admin.Services";

        public const String AdminRole = "Admin";

        public const int PasswordMinimumLength = 6;


        public static List<String> AllRoles = new List<String>() {
            AdminRole
        };
    }
}
