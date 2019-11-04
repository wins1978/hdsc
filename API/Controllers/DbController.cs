using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SqlSugar;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class DbController : Controller
    {
        private readonly DbSetting dbSetting;
        private readonly string connStr;
        
        public DbController(IOptions<AppSettings> setting)
        {
            dbSetting = setting.Value.DbSetting;
            connStr = String.Format("server={0};port={1};uid={2};pwd={3};database={4};charset='utf8';pooling=true", 
                dbSetting.Host,dbSetting.Port,dbSetting.User,dbSetting.Password,dbSetting.Database);

        }

        public SqlSugarClient GetInstance()
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = connStr,
                DbType = DbType.MySql,
                IsAutoCloseConnection = true,
                IsShardSameThread = true //设为true相同线程是同一个SqlSugarClient
            });
            db.Ado.IsEnableLogEvent = true;

            return db;
        }

        public string InitModel(string genaratetables)
        {
            string msg = "";
            try
            {
                string path = "E:\\MY_PROJECTS\\Model";

                var tableNames = genaratetables.Split(',').ToList();
                for (int i = 0; i < tableNames.Count; i++)
                {
                    tableNames[i] = tableNames[i].ToLower();
                }
                var suger = GetInstance().DbFirst.SettingClassTemplate(old =>
                {
                    return old.Replace("{Namespace}", "API.Model");//.Replace("class {ClassName}", "class {ClassName} :BaseEntity");//改变命名空间
                });
                if (tableNames.Count >= 0)
                {
                    suger.Where(it => tableNames.Contains(it.ToLower())).IsCreateDefaultValue();
                }
                else
                {
                    suger.IsCreateDefaultValue();
                }
                //过滤BaseEntity中存在的字段
                //var pros = typeof(BaseEntity).GetProperties();
                //var list = new List<SqlSugar.IgnoreColumn>();
                var tables = suger.ToClassStringList().Keys;
                //foreach (var item in pros)
                //{
                //    foreach (var table in tables)
                //    {
                //        list.Add(new SqlSugar.IgnoreColumn() { EntityName = table, PropertyName = item.Name });
                //    }
                //}
                //suger.Context.IgnoreColumns.AddRange(list);
                suger.CreateClassFile(path);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return msg;
        }

        [HttpGet("{tableName}")]
        public IActionResult Index(string tableName)
        {
            var msg = InitModel(tableName);

            ResponseResult result = new ResponseResult();
            result.Code = 0;
            result.Data = msg;
            return Json(result);
        }
    }
}
