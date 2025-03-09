using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.ConstrainedExecution;

namespace BlogLiveProje.ViewComponents.Blog
{
    public class BlogListDashboard:ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IViewComponentResult Invoke()
        {
            var values =bm.GetBlogListWithCategory();
            return View(values);


         
        }
    }
}
//View components, ASP.NET Core uygulamalarında belirli bir veriyi çekip, o veriyi bir kısmı olarak görüntülemek için kullanılır. GetBlogListWithCategory() gibi metodlar ise iş katmanında(Business Layer) yer alarak bu veriyi veri tabanından veya başka bir kaynaktan alıp bileşene(view component) hazır hale getiren mantığı sağlar

//Neden GetBlogListWithCategory Kullanılıyor?
//Kod Tekrarını Önlemek: Aynı blog ve kategori çekme işlemini birden fazla yerde kullanacaksan, bu işlemi merkezi bir metod olan GetBlogListWithCategory içine koyarak kod tekrarını önlemiş olursun.
//Katmanlı Mimarinin Korunması: İş mantığını ve veri çekme işlemlerini bileşenin içinde yazmak, bu işlemi tek bir yere bağlayarak ileride yapılacak olası değişiklikleri zorlaştırır. Ancak bu işlemleri iş katmanında tutmak, veriyi işleme ve düzenleme sorumluluğunu model ve bileşenden ayırır.
////Esneklik Sağlamak: İş katmanındaki bu metot ile ileride sorgu yapısında veya veri modelinde değişiklikler yapmak gerektiğinde, sadece GetBlogListWithCategory metodunda düzenleme yaparak bunu sağlar ve bileşen veya view koduna dokunmazsın.
//GetBlogListWithCategory() metodu, iş katmanında veri çekme ve işleme mantığını kapsar ve view component’in sadece veriyi görüntüleme işlevine odaklanmasını sağlar. Bu, uygulamanın sürdürülebilirliğini ve genişletilebilirliğini artırır.

//Eğer bu veri çekme işlemini direkt olarak view component’in içinde yapsaydın, uygulamanın yapısı dağılır ve kod karmaşık hale gelirdi. Bu yüzden iş katmanında bu tarz metodlar kullanmak, uygulamanın daha temiz ve yönetilebilir olmasını sağlar.