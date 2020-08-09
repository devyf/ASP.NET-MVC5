using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EFFramework.Models
{
    //创建一个UserContext上下文连接类，继承DbContext，使用name关联Web.config中的连接语句
    public class UserContext : DbContext
    {
        public UserContext() : base("name=SqlConnString")
        {
            
        }
        //创建一个数据库Model集合获取方法
        public DbSet<td_user> td_user { get; set; }
    }
}