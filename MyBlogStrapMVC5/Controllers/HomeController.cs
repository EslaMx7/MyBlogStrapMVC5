using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogStrapMVC5.Controllers
{
    public class HomeController : Controller
    {
        BlogEntities db;

        public HomeController()
        {
            db = new BlogEntities();
        }
        //
        // GET: /Home/
        public ActionResult Index()
        {
            ViewBag.Title = "Eslam Hamouda Blog";
            

            var posts = db.Posts.AsEnumerable<Post>();

            return View(posts);
        }


	}
}