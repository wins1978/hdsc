using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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

            ResponseResult result = new ResponseResult();
            result.Code = 0;
            result.Data = Constants.SUCCESS;
            return Json(result);  
        }
    }
}
