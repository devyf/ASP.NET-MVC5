using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication01.App_Start;
using WebApplication01.Models;

namespace WebApplication01.Controllers
{
    public class MyDefineController : Controller
    {
        // GET: MyDefineController01
        public ActionResult Index()
        {
            User u1 = new User();
            u1.Name = "小明";
            u1.Age = 30;
            List<User> userList = new List<User>();
            userList.Add(u1);
            return View(userList);
        }

        //注意MyDefineView方法必须和.cshtml中的View层命名一致
        //测试从数据库中读取数据
        public ActionResult MyDefineView()
        {
            ConnData connData = new ConnData();
            DataSet dataSet = connData.GetDataSet();

            User u1 = new User();
            //u1.Name = "小明";
            u1.Name = dataSet.Tables[0].Rows[0][1].ToString();
            u1.Age =Convert.ToInt32(dataSet.Tables[0].Rows[0][2].ToString());
            List<User> userList = new List<User>();
            userList.Add(u1);
            return View(userList);
        }
    }
}