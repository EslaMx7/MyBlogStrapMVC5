using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogStrapMVC5.Controllers
{
    public class PostsController : Controller
    {
        BlogEntities db;
        public PostsController()
        {
            db = new BlogEntities();
        }

        //
        // GET: /Posts/
        public ActionResult Post(int? id)
        {

            var post = db.Posts.Where(p => p.ID == id).FirstOrDefault();
            post.Views += 1;

            ViewBag.Title = post.Title;
            ViewBag.PostID = post.ID;
            db.SaveChangesAsync().Wait();
            return View(post);
        }

        [HttpPost]
        public ActionResult Comment(int? id, FormCollection form)
        {
            
            
            var post = db.Posts.Where(p => p.ID == id).FirstOrDefault();
            post.Comments.Add(new Comment
            {
                PostID = id ?? 0,
                Author = form["txtCommentAuthor"],
                CommentContent = form["txtCommentContent"],
                PublishDate = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() 

            });

            db.SaveChangesAsync().Wait();
            return RedirectToAction("Post", "Posts", new { id = id });
        }
    }
}