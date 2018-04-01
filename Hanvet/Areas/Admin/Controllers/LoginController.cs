using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hanvet.Models.Admin;
using Extend.DataAccess;
namespace Hanvet.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserLogin user)
        {
            int userID = ADODAOFactory.Instance().CreateAccountDao().User_Login(user.username,user.password);

            if (ModelState.IsValid && userID > 0)
            {
               return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("","Tài khoản hoặc mật khẩu không đúng!");
            }
            return View();
        }
    }
}