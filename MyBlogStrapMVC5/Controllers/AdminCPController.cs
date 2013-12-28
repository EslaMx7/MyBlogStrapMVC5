using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MyBlogStrapMVC5.Controllers
{
    public class AdminCPController : Controller
    {
        BlogEntities db;
        public AdminCPController()
        {
            db = new BlogEntities();
        }
        //
        // GET: /AdminCP/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string username = form["txtUsername"];
            string password = form["txtPassword"];

            var hash = MD5Hash(password, "EslaM");

            int count = db.Users.Count(u => u.Username == username && u.Password == hash);
            if (count == 1) // Success Login
            {
                return Content("Success");
            }
            else
            {
                return Content("Access Denied!");

            }

        }

        private string MD5Hash(string value,string key)
        {
            return Convert.ToBase64String(new MD5CryptoServiceProvider().ComputeHash(new UTF8Encoding().GetBytes(value+"/"+key)));
        }
    }
}