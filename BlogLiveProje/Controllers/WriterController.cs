using BlogLiveProje.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogLiveProje.Controllers
{

    public class WriterController : Controller
    {
        WriterManager vm = new WriterManager(new EfWriterRepository());
        [Authorize]
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.v = usermail;
            Context c=new Context();
            var WriterName=c.Writers.Where(x=>x.Mail==usermail).Select(y=>y.Name).FirstOrDefault(); 
            ViewBag.v2 = WriterName;
            return View();
        }

        public IActionResult WriterProfile()
        {
            Context c = new Context();

            var usermail = User.Identity.Name;

            var writerID = c.Writers.Where(x => x.Mail == usermail).Select(y => y.WriterId).FirstOrDefault();



            var writerValues = vm.TGetById(writerID);
            return View(writerValues);

        }

        public IActionResult WriterMail()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult test()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult WriterNavPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

   
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            Context c = new Context();

            var usermail = User.Identity.Name;

            var writerID = c.Writers.Where(x => x.Mail == usermail).Select(y => y.WriterId).FirstOrDefault();

     

            var writerValues = vm.TGetById(writerID);
            return View(writerValues);
        }

        [HttpPost]


        public IActionResult WriterEditProfile(Writer p)
        {
            // Öncelikle veritabanındaki mevcut yazarı buluyoruz
            var writerFromDb = vm.TGetById(p.WriterId);

            if (writerFromDb == null)
            {
                // Eğer ilgili Writer bulunamazsa NotFound dön
                return NotFound("Writer not found");
            }

            WriterValidator wl = new WriterValidator();
            FluentValidation.Results.ValidationResult results = wl.Validate(p);

            if (results.IsValid)
            {
                // Formdan gelen değerleri kontrol ederek boş olan alanları eski haliyle bırakıyoruz
                writerFromDb.Name = string.IsNullOrEmpty(p.Name) ? writerFromDb.Name : p.Name;
                writerFromDb.City = string.IsNullOrEmpty(p.City) ? writerFromDb.City : p.City;
                writerFromDb.Gender = string.IsNullOrEmpty(p.Gender) ? writerFromDb.Gender : p.Gender;
                writerFromDb.Phone = string.IsNullOrEmpty(p.Phone) ? writerFromDb.Phone : p.Phone;
                writerFromDb.Image = string.IsNullOrEmpty(p.Image) ? writerFromDb.Image : p.Image;
                writerFromDb.Mail = string.IsNullOrEmpty(p.Mail) ? writerFromDb.Mail : p.Mail;
                writerFromDb.Password = string.IsNullOrEmpty(p.Password) ? writerFromDb.Password : p.Password;

                // Güncellenen bilgileri kaydediyoruz
                vm.TUpdate(writerFromDb);

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                // Validasyon hataları varsa, hataları göster
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            // Hatalı durumlarda mevcut verilerle sayfayı geri döndür
            return View(writerFromDb);
        }

   

        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer w = new Writer();
            if (p.Image != null)
            {
                var extension = Path.GetExtension(p.Image.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.Image.CopyTo(stream);
                w.Image = newimagename;
            }

            w.Mail = p.Mail;
            w.Name = p.Name;
            w.Password = p.Password;
            w.Status = true;
            w.About = p.About;

            vm.TAdd(w);

            return RedirectToAction("Index", "Dashboard");
        }


    }
}
