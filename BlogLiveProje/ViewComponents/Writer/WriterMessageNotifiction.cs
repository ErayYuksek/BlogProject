using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogLiveProje.ViewComponents.Writer
{
    public class WriterMessageNotifiction: ViewComponent
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());

        public IViewComponentResult Invoke()
        {
            int id = 12;
            var values=mm.GetInboxListByWriter(id);
            return View(values);
        }
    }
}
