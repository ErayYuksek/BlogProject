using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BlogLiveProje.Controllers
{ 
	[AllowAnonymous]
	public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutRepository());
        public IActionResult Index()
        {
            var result = aboutManager.GetLlistt();
            return View(result);
        }

        public PartialViewResult SocialMediaAbout()
        {
            return PartialView();
        }

    }
}
//AboutManager abm = new IAboutManager(new EfAboutRepository());
//public IActionResult Index()
//{
//    var values = abm.GetList();
//    return View(values);
//}
//public PartialViewResult SocialMediaAbout()
//{
//    return PartialView();
//}