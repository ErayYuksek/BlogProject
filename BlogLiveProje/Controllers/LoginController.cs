using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;


namespace BlogLiveProje.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login Sayfasını Gösterir
        public IActionResult Index()
        {
            return View();
        }

        // POST: Giriş İşlemi
        [HttpPost]
        [AllowAnonymous]


        public async Task<IActionResult> Index(Writer p)
        {
            Context c = new Context();
            var datavalue = c.Writers.FirstOrDefault(x =>
                x.Mail == p.Mail &&
                x.Password == p.Password);

            if (datavalue != null)
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, p.Mail)
        };

                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return View();
            }
        }

    }
}




// Veritabanı işlemleri burada yapılır



// Veritabanı işlemleri burada yapılır



//public IActionResult Index(Writer p)
//{
//    // Veritabanı bağlantısı
//    using var c = new Context();

//    // Kullanıcının mail ve şifresine göre veritabanında sorgu yap
//    var dat = c.Writers.FirstOrDefault(x => x.Mail == p.Mail && x.Password == p.Password);

//    if (dat == null)
//    {
//        // Giriş başarılı olduğunda session'a email bilgisini kaydet
//        HttpContext.Session.SetString("Name", p.Mail);
//        ViewBag.ErrorMessage = "Eeyin.";
//        // Kullanıcıyı 'Writer' controllerındaki 'Index' sayfasına yönlendir
//        return RedirectToAction("Index", "Writer");
//    }
//    else
//    {
//        // Giriş başarısızsa bir hata mesajı göster
//        ViewBag.ErrorMessage = "E-posta veya şifre hatalı. Lütfen tekrar deneyin.";
//        return View();
//    }
//}



