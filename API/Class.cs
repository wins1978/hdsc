using API.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class Class1: BaseModel
    {
        [DisplayName("ana")]
        public string AName { get; set; }

        [DisplayName("sa")]
        public string Sax { get; set; }
    }
}
