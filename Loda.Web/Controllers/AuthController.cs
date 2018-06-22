using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Loda.Entity.DataTable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Loda.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult GetToken([FromBody] DT_User user)
        {
            if (user.UserName == "admin" && user.UserPassword == "123456")
            {
                var claims = new Claim[]
                {
                    // 把用户名添加到声明里，以后使用的时候，我们就能知道其身份
                    new Claim(ClaimTypes.Name,user.UserName),

                    // 把角色名添加到声明里
                    new Claim(ClaimTypes.Role,"admin")
                };

                // 使用密钥对令牌进行签名，签名将在当前API和需要检查令牌合法的任何地方之前共享使用
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SymmetricSecurityKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                        issuer: "localhost:4002",// 颁布者
                        audience: "api",// 颁布给谁
                        claims: claims,// 声明数组
                        expires: DateTime.Now.AddMinutes(10),// 有效期
                        signingCredentials: creds // 令牌
                        );

                // 把Token返回给请求方
                return Ok(new JwtSecurityTokenHandler().WriteToken(token));

            }
            else
            {
                return BadRequest("用户名或密码错误");
            }
        }
    }
}