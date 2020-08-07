using MVC5Character06.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MVC5Character06.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult Register(string username, string age, string sex, string password)
        {
            return Content("姓名：" + username + " 年龄：" + age + "性别：" + sex + " 密码：" + password);
        }

        [HttpPost]
        public ActionResult Register2(string username, string age, string sex, string password)
        {
            return Content("姓名：" + Request["username"]   + " 年龄：" + Request["age"] + "性别：" + Request["sex"] + " 密码：" + Request["password"]);
        }

        [HttpPost]
        public ActionResult Register3(FormCollection coll)
        {
            return Content("姓名：" + coll["username"] + " 年龄：" + coll["age"] + "性别：" + coll["sex"] + " 密码：" + coll["password"]);
        }

        [HttpPost]
        public ActionResult Register4(UserInfo user)
        {
            return View(user);
        }

        [HttpPost]
        public ActionResult Register5(UserInfo user)
        {
            return View(user);
        }

        [HttpPost]
        public ActionResult Register6(UserInfo user)
        {
            UserInfo user1 = new UserInfo();
            user1.username = "小明";
            user1.age = "21";
            user1.sex = "男";
            UserInfo user2 = new UserInfo();
            user2.username = "小花";
            user2.age = "22";
            user2.sex = "女";

            List<UserInfo> userList = new List<UserInfo>();
            userList.Add(user);
            userList.Add(user1);
            userList.Add(user2);
            return View(userList);
        }

        //第一次显示调用这个接口
        [HttpPost]
        public ActionResult Register7(UserInfo user)
        {
            List<UserInfo> userList = new List<UserInfo>();
            for (int i = 0; i < 100; i++)
            {
                UserInfo userInfo = new UserInfo();
                userInfo.username = "小青" + i;
                userInfo.age = "23";
                userInfo.sex = "女";
                userList.Add(userInfo);
            }
            //当前页
            int pageNumber = 1;
            int pageSize = 10;
            IPagedList<UserInfo> userInfos = userList.ToPagedList(pageNumber, pageSize);

            return View(userInfos);
        }

        //以后点击分页直接用Register8进行传输
        //[HttpPost]
        public ActionResult Register8(int page)
        {
            List<UserInfo> userList = new List<UserInfo>();
            for (int i = 0; i < 100; i++)
            {
                UserInfo userInfo = new UserInfo();
                userInfo.username = "小青" + i;
                userInfo.age = "23";
                userInfo.sex = "女";
                userList.Add(userInfo);
            }
            //当前页
            //int pageNumber = pageNumber;
            int pageSize = 10;
            IPagedList<UserInfo> userInfos = userList.ToPagedList(page, pageSize);

            return View(userInfos);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}