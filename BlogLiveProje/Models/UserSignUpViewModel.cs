using System.ComponentModel.DataAnnotations;

namespace BlogLiveProje.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name = "Ad  Soyad")]
        [Required(ErrorMessage = "Lütfen Ad soyad giriniz")]
        public string  nameSurname { get; set; }


        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen şifre giriniz")]
        public string Password { get; set; }


        [Display(Name = "Şifre")]
        [Compare("Password",ErrorMessage ="Şifreler Uyuşmuyor")]
        public string ConfirmPassword { get; set; }


        [Display(Name = "Mail Adresi")]
        [Required(ErrorMessage = "Lütfen Mail giriniz")]
        public string Mail { get; set; }



        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz")]
        public string UserName { get; set; }
    }
}
    