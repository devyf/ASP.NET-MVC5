using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFFramework02_Auto.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            //引用上下文创建实体模型集合返回视图页面
            db_newsEntities entities = new db_newsEntities();
            return View(entities.td_user.ToList());
        }
    }
}