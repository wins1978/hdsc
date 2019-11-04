using API.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.Utils
{
    public class DbContext
    {
        public DbContext()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", true, reloadOnChange: true);

            var config = builder.Build();

            var aaaa = config["AppSettings:DbSetting"];
            //string connStr = String.Format("server={0};port={1};uid={2};pwd={3};database={4};charset='utf8';pooling=true",
            //    dbSetting.Host, dbSetting.Port, dbSetting.User, dbSetting.Password, dbSetting.Database);

            Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "",
                DbType = DbType.MySql,
                IsAutoCloseConnection = true,
                IsShardSameThread = true //设为true相同线程是同一个SqlSugarClient
            });
            //调式代码 用来打印SQL 
            Db.Aop.OnLogExecuting = (sql, pars) =>
            {
                string msg =sql + Environment.NewLine +
                    Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)) + Environment.NewLine;

                Logger.Critical("sql", msg);
            };

        }
        //注意：不能写成静态的，不能写成静态的
        public SqlSugarClient Db;//用来处理事务多表查询和复杂的操作
        public SimpleClient<goods> GoodsDb { get { return new SimpleClient<goods>(Db); } }//用来处理goods表的常用操作
    }
}
