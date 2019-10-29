using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace API.Dto
{
    public static class BaseModelExtenstion
    {
        public static string ConsoleEntity<TEntity>(this TEntity tEntity,string name) where TEntity : BaseModel
        {
            Type type = tEntity.GetType();
            PropertyInfo[] propInfos = type.GetProperties();
            string msg = "";
            foreach (var prop in propInfos)
            {
                string parameterName = prop.Name;
                if (prop.IsDefined(typeof(DisplayNameAttribute), false))
                {
                    DisplayNameAttribute attribute = (DisplayNameAttribute)prop.GetCustomAttribute(typeof(DisplayNameAttribute), false);
                    parameterName = attribute.Name == "" ? prop.Name : attribute.Name;
                }
                if (parameterName == name)
                {
                    msg += parameterName +":"+ prop.GetValue(tEntity);
                    break;
                }
            }

            return msg;
        }
    }
}
