using Microsoft.AspNetCore.Mvc;

namespace BlogLiveProje.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult AdminNavbarPartial()
        {
            return  PartialView();
        }
    }
}
