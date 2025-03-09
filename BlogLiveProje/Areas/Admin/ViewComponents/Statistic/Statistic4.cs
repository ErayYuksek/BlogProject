using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace BlogLiveProje.Areas.Admin.ViewComponents.Statistic1
{

    public class Statistic4:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
         ViewBag.v1    = c.Admins.Where(x => x.AdminID == 2).Select(y => y.Name).FirstOrDefault();  
         ViewBag.v2    = c.Admins.Where(x => x.AdminID == 2).Select(y => y.ImageURL).FirstOrDefault();  
         ViewBag.v1    = c.Admins.Where(x => x.AdminID == 2).Select(y => y.ShortDescription).FirstOrDefault();

            string api = "d4b162950188294a16f17e79e5b1ff4c";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=Istanbul&mode=xml&lang=tr&units=metric&appid=" + api;

            XDocument document = XDocument.Load(connection);

            ViewBag.v4 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;


            return View();
        }

    }
}
