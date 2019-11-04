using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Db;
using API.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace API.Controllers
{
    /// <summary>
    /// 石粉型号类
    /// </summary>
    [Route("api/[controller]")]
    public class GoodsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 添加石料
        /// </summary>
        /// <returns></returns>
        [HttpPost("add")]
        public JsonResult Add()
        {
            var sett = ConfigServices.Configuration.GetSection("AppSettings").Get<AppSettings>();

            ResponseResult result = new ResponseResult();
            result.Code = 0;
            result.Data = sett.DbSetting.Host;
            return Json(result);  
        }
    }
}
