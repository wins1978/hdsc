using API.Utils;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Db
{
    public class GoodsMgr: DbContext
    {

        public string GetName()
        {
            var item = base.GoodsDb.GetById(2);
            return item.goods_name;
        }
    }
}
