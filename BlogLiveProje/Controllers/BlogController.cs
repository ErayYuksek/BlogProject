using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogLiveProje.Controllers
{

    public class BlogController : Controller
    {


        BlogManager bm = new BlogManager(new EfBlogRepository());

        CategoryManager cm = new CategoryManager(new EfCategoryRepository());


        Context c = new Context();
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }

        public IActionResult BlogReadAll(int id)
        {
            //tıkladıgın bloga aıt verıler gelmesı ıcın
            ViewBag.i = id;
            var values = bm.GetBlogByID(id);
            return View(values);
        }
        public IActionResult BLogListByWriter()
        {


            var usermail = User.Identity.Name;

            var writerID = c.Writers.Where(x => x.Mail == usermail).Select(y => y.WriterId).FirstOrDefault();

            var values = bm.GetListWithCategoryByWriterBm(writerID);
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {


            List<SelectListItem> categoryvalues = (from x in cm.GetLlistt()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View();
        }


        [HttpPost]
      
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.Mail == usermail)
                                    .Select(y => y.WriterId)
                                    .FirstOrDefault();

            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(p);

            if (results.IsValid)
            {
                p.Status = true;
                p.CreateDate = DateTime.Now;
                p.WriterId = writerID;
                bm.TAdd(p);

                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                // Eğer form hatalıysa ve sayfa geri yüklenecekse ViewBag.cv'yi tekrar doldurun
                List<SelectListItem> categoryvalues = (from x in cm.GetLlistt()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.Name,
                                                           Value = x.CategoryId.ToString()
                                                       }).ToList();
                ViewBag.cv = categoryvalues;
            }

            return View(p); // Model ile tekrar view'a dön
        }


        public ActionResult DeleteBlog(int id)
        {
            var varvablogvalue = bm.TGetById(id);
            bm.TDelete(varvablogvalue);
            return RedirectToAction("BLogListByWriter");
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            List<SelectListItem> categoryvalues = (from x in cm.GetLlistt()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            var blogvalue = bm.TGetById(id);
            return View(blogvalue);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            var usermail = User.Identity.Name;

            var writerID = c.Writers.Where(x => x.Mail == usermail).Select(y => y.WriterId).FirstOrDefault();

            p.WriterId = writerID;
            p.CreateDate=DateTime.Parse(DateTime.Now.ToShortDateString());
            p.Status =true;
            bm.TUpdate(p);
            return RedirectToAction("BLogListByWriter");
        }
    }
}

//Index(): Blog listesini döndürür. Bu metot, ana sayfada blog yazılarının bir listesini göstermek için kullanılır.
// BlogReadAll(int id) : Belirli bir blogun detaylarını göstermek için kullanılır.Kullanıcı belirli bir bloga tıkladığında, o blogun bilgilerini döndürür.