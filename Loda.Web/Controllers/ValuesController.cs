using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loda.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Loda.Web.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IDT_UserService _userService;

        public ValuesController(IDT_UserService userService)
        {
            //依赖注入得到实例
            _userService = userService;
        }

        public IActionResult Test()
        {
            _userService.Insert();

            return Ok(_userService.GetList());
        }
    }
}
