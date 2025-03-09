using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogLiveProje.ViewComponents.Writer
{


    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterManager vm = new WriterManager(new EfWriterRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var usermail = User.Identity.Name;

            var writerID = c.Writers.Where(x => x.Mail == usermail).Select(y => y.WriterId).FirstOrDefault();

            var values = vm.GetWriterById(writerID);

            return View(values);
        }

    }
}
