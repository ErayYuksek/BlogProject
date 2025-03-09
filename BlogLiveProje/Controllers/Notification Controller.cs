using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogLiveProje.Controllers
{
    public class Notification_Controller : Controller
    {
        NotificationManager nm=new NotificationManager(new EfNotificationRepository());
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult AllNotification() {

            var values = nm.GetLlistt();

            return View(values);
        }
    }
}
