using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ResponseResult
    {
        public int Code { get; set; }
        public object Data { get; set; }
    }

    public class Constants
    {
        public const string SUCCESS = "SUCCESS";
        public const string FAIL = "FAIL";
    }
}
