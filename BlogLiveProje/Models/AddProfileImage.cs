using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;

namespace BlogLiveProje.Models
{
    public class AddProfileImage
    {
        public int WriterId { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public IFormFile Image { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }

    }
}
