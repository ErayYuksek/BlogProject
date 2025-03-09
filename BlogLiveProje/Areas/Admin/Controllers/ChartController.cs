using BlogLiveProje.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogLiveProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryChart()
        {
            // CategoryClass türünden bir liste oluşturuyoruz
            List<CategoryClass> list = new List<CategoryClass>();

            // Listeye yeni bir CategoryClass nesnesi ekliyoruz
            list.Add(new CategoryClass
            {
                categoryname = "Teknoloji",
                categorycount = 10
            });

            list.Add(new CategoryClass
            {
                categoryname = "Yazılım",
                categorycount = 14
            });


            list.Add(new CategoryClass
            {
                categoryname = "Spor",
                categorycount = 5
            });
            // Burada istenirse daha fazla kategori eklenebilir
            // Örneğin:
            // list.Add(new CategoryClass { categoryname = "Bilim", categorycount = 5 });

            return Json(new {Jsonlist=list}); // Listeyi View'a dönüyoruz
        }

    }
}
