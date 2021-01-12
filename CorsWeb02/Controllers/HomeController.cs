using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CorsWeb01.Controllers
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

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SetCookies()
        {
            var cookies = new[]
            {
                new HttpCookie("X_1", "Y_1"),
                new HttpCookie("X_2", "Y_2") { SameSite = SameSiteMode.None, Secure = true }, // None は Secure 必須
                new HttpCookie("X_3", "Y_3") { SameSite = SameSiteMode.Lax },
            };

            foreach (var c in cookies)
            {
                Response.Cookies.Set(c);
            }

            return RedirectToAction("Index");
        }

        public ActionResult ClearCookies()
        {
            foreach (var key in Request.Cookies.AllKeys)
            {
                var c = Request.Cookies[key];
                c.Expires = new DateTime(2000, 1, 1);
                Response.Cookies.Set(c);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Api()
        {
            var obj = new
            {
                Name = "CorsWeb02",
                Success = true,
                Cookies = Request.Cookies.AllKeys.Select(k => Request.Cookies[k])
            };

            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}