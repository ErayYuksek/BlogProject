using BlogLiveProje.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlogLiveProje.Areas.Admin.Controllers
{
    [Area("Admin")] // Bu attribute tüm controller için geçerli
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult WriterList()
        {
            return Json(writers);
        }
        [HttpPost]

        public IActionResult AddWriter(WriterClass w)
        {
            writers.Add(w);
            var JsonWriters = JsonConvert.SerializeObject(w);

            return View(JsonWriters);

        }
        public IActionResult DeleteWriter(int id)
        {
            // Find the writer with the specified ID
            var writer = writers.FirstOrDefault(x => x.Id == id);

            // If the writer is found, remove it from the collection

            writers.Remove(writer);
            // Return the removed writer (or null if not found) as a JSON response
            return Json(writer);
        }
        public IActionResult UpdateWriter(WriterClass w)
        {
            // Find the writer with the specified ID
            var writer = writers.FirstOrDefault(x => x.Id == w.Id);

            // If the writer is found, update the relevant properties
            if (writer != null)
            {
                writer.Name = w.Name; // Update the writer's name (can add other fields as needed)
            }

            // Serialize the updated writer object to JSON
            var jsonWriter = JsonConvert.SerializeObject(writer);

            // Return the serialized JSON as the response
            return Json(jsonWriter);
        }

        public IActionResult GetWriterByID(int writerid)
        {
            var findWriter = writers.FirstOrDefault(x => x.Id == writerid);
            var jsonWriters = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriters);

        }
        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass { Id = 3, Name = "Samet" },
            new WriterClass { Id = 4, Name = "Şevval" },
            new WriterClass { Id = 5, Name = "Nurana" },
            new WriterClass { Id = 6, Name = "Mete Serkan" }
        };
    }
}

