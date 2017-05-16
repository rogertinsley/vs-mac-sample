using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Test.Model;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
			using (var db = new BloggingContext())
			{
				var blogs = db.Blogs
					.OrderBy(b => b.Url)
					.ToList();

				return View(blogs);
			}
        }

        public IActionResult About()
        {
			using (var db = new BloggingContext())
			{
				var blog = new Blog { Url = "http://sample.com" };
				db.Blogs.Add(blog);
				db.SaveChanges();
			}

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
