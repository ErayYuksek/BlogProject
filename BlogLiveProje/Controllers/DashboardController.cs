using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogLiveProje.Controllers
{
    public class DashboardController : Controller
    {
        BlogManager bm=new BlogManager(new EfBlogRepository());
      
     
        public IActionResult Index()
        {
            Context c = new Context();
            ViewBag.v1 = c.Blogs.Count().ToString();
            ViewBag.v2 = c.Blogs.Where(x=>x.WriterId == 3).Count();    
            ViewBag.v3 = c.Categories.Count();
            return View();
        }
    }
}
//ViewBag.v1, bu string değerini taşır. ViewBag, veriyi Controller'dan View'a taşımanın bir yoludur. ViewBag dinamik bir yapıdır, yani içerisine herhangi bir veri türü atanabilir.