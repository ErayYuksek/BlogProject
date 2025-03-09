using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogLiveProje.Controllers
{
	public class CommentController : Controller
	{
		CommentManager cm=new CommentManager(new EfCommentRepository());
		public IActionResult Index()
		{
			return View();
		}
        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialAddComment(Comment p)
        {
          
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.Status=true;
            p.Content = "ffd";    
            p.BlogId = 11;
            
   
            cm.CommentAdd(p);
            return PartialView();
        }
        public PartialViewResult CommentListByBlog(int id) {

			var values = cm.GetLlistt(id);
			return PartialView(values);
		}
	}

}
