using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogLiveProje.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm=new CategoryManager(new EfCategoryRepository());

        public IActionResult Index()
        {
            var values = cm.GetLlistt();
            return View(values);
        }
    }
}
