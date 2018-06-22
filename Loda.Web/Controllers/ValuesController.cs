using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loda.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Loda.Web.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IDT_UserService _userService;

        private readonly IConfiguration _configuration;

        public ValuesController(IDT_UserService userService,IConfiguration configuration)
        {
            //依赖注入得到实例
            _userService = userService;

            _configuration = configuration;
        }

        [Authorize]
        public IActionResult Test()
        {
            _userService.Insert();

            return Ok(_userService.GetList());
        }

        [Route("test2")]
        public IActionResult Test2()
        {
            return Ok("test2");
        }

    }
}
