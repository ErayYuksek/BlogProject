using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogLiveProje.Areas.Admin.ViewComponents.Statistic1
{
    public class Statistic2 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {

            ViewBag.v1 = c.Blogs
                .OrderByDescending(x => x.BlogId) // Blogları BlogID'ye göre azalan sırada sırala
                .Select(x => x.Title)        // Blog başlıklarını seç
                .Take(1)                         // İlk 1 kaydı al
                .FirstOrDefault();               // İlk kaydı getir, eğer yoksa null döner

            return View();
        }
    }
}