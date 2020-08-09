using EFFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFFramework.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userName, string pwd)
        {
            UserContext context = new UserContext();
            //先到数据库进行用户名，密码的匹配查询
            List<td_user> queryRes = context.td_user.Where(u => u.UserName == userName).Where(u => u.PassWord == pwd).ToList();

            //查询到了数据库有这个用户
            if (queryRes != null && queryRes.Count > 0)
            {
                Session["username"] = userName;
                //跳转到用户管理界面进行数据页面展示，UserController中的Index
                return RedirectToAction("Index", "User");
            }
            //没有这个用户
            else
            {
                //返回登录页面
                ViewBag.Message = "用户信息不存在";
                return View("Index");//返回本类的Index登录页面视图
            }
        }
    }
}