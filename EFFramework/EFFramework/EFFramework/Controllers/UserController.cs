using EFFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFFramework.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            UserContext context = new UserContext();
            return View(context.td_user.ToList());
        }

        //点击查看根据当前的userId来展示用户信息
        public ActionResult Details(int id)
        {
            UserContext context = new UserContext();
            //var details = from c in context.td_user
            //              where int.Equals(c.UserId, id)
            //              select c;
            //List<td_user> userList = details.ToList();
            List<td_user> userList = context.td_user.Where(c => c.UserId == id).ToList();
            return View(userList.FirstOrDefault());
        }

        //新增Create
        public ActionResult Create()
        {
            return View();
        }

        //新增点击方法
        public ActionResult AddUser(td_user user)
        {
            UserContext context = new UserContext();
            context.td_user.Add(user);
            //保存新增至数据库
            context.SaveChanges();
            //返回展示页面，UserController下面的Index页面
            return View("Index", context.td_user.ToList());
        }

        //编辑Edit
        public ActionResult Edit(int id)
        {
            //显示传过来的数据
            UserContext context = new UserContext();
            var queryUser = context.td_user.Where(u => u.UserId == id).ToList().FirstOrDefault();
            return View(queryUser);
        }

        //保存点击方法
        public ActionResult Update(td_user user)
        {
            UserContext context = new UserContext();

            //先从数据库查询到user对应id在数据库中的那个值
            var queryOne = context.td_user.Where(u => u.UserId == user.UserId).ToList().FirstOrDefault();
            //再把这个值更新
            queryOne.UserName = user.UserName;
            queryOne.PassWord = user.PassWord;
            queryOne.Email = user.Email;
            queryOne.Role = user.Role;

            context.SaveChanges();
            return View("Index", context.td_user.ToList());
        }

        //点击删除按钮
        public ActionResult Delete(int id)
        {
            UserContext context = new UserContext();

            //先从数据库查询到user对应id在数据库中的那个值
            var queryOne = context.td_user.Where(u => u.UserId == id).ToList().FirstOrDefault();
            //再把这个值删除
            context.td_user.Remove(queryOne);
            context.SaveChanges();
            return View("Index", context.td_user.ToList());
        }

        //username必须和View视图中的姓名输入框中的name属性值一致
        [HttpPost]
        public ActionResult Search(string username, string role)
        {
            UserContext context = new UserContext();
            //模糊查询出所有相似的结果
            List<td_user> queryList = context.td_user
                .Where(u => u.UserName.Contains(username))
                .Where(u => u.Role == role)
                .ToList();
            //跳转到前台进行页面展示
            return View("Index", queryList);
        }
    }
}