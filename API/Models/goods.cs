using System;
using System.Linq;
using System.Text;

namespace API.Model
{
    ///<summary>
    ///
    ///</summary>
    public partial class goods
    {
           public goods(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long id {get;set;}

           /// <summary>
           /// Desc:货物名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string goods_name {get;set;}

           /// <summary>
           /// Desc:货物别名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string goods_alias {get;set;}

           /// <summary>
           /// Desc:大类:石仔、石粉
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string group_name {get;set;}

           /// <summary>
           /// Desc:排序
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int order_index {get;set;}

    }
}
