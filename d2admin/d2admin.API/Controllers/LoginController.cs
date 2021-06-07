using DC = d2admin.API.DataContracts.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using d2admin.Services.Model;
using ttn.Web.JwtToken;

namespace d2admin.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JwtTokenUtil _tokenUtil;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="signInManager"></param>
        /// <param name="tokenUtil"></param>
        public LoginController(UserManager<User> userManager, SignInManager<User> signInManager, JwtTokenUtil tokenUtil)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenUtil = tokenUtil;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody] DC.LoginRequest req)
        {
            Console.WriteLine($"{ req.UserName } { req.Password }");

            var user = await _userManager.FindByNameAsync(req.UserName);

            if (null == user)
            {
                return Json(new
                {
                    code = 1000,
                    msg = "用户名或密码不正确",
                    req.UserName
                });
            }

            var isValid = await _userManager.CheckPasswordAsync(user, req.Password);

            if (!isValid)
            {
                return Json(new { code = 1001, msg = "用户名或密码不正确" });
            }

            TokenResponse res = await _tokenUtil.AuthorizeClientAsync(_userManager, _signInManager, user.UserName, req.Password);

            if (String.IsNullOrEmpty(res.AccessToken))
            {
                return Json(new { code = 1002, msg = "登录失败" });
            }

            return Json(

                 new
                 {
                     code = 0,
                     data = new
                     {
                         id = user.Id,
                         name = user.UserName,
                         token = res.AccessToken,
                         username = user.UserName,
                         uuid = user.Id
                     },
                     msg = "登录成功"
                 }
            );
        }
    }
}
