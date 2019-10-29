using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dto;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Class1 cls = new Class1();
            cls.AName = "xxxxxxxxx";
            cls.Sax = "sssssssss";
            string ss = cls.ConsoleEntity("ana");


            Logger.Critical("ValuesController", "ValuesController__err");

            ExportCar c = new ExportCar();
            c.Load();
            return new string[] { ss, "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
