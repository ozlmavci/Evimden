using System.ComponentModel.DataAnnotations;

namespace Evimden.UI.Web.Models.VMs.IdentityVMs
{
    public class UserVM
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen mail adresinizi giriniz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen şifreyi tekrar giriniz.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor, kontrol ediniz.")]
        public string PasswordConfirm { get; set; }

        [Required(ErrorMessage = "Lütfen adınızı giriniz.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lütfen soyadınızı giriniz.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Lütfen telefon numaranızı giriniz.")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        public string PhoneNumber { get; set; }

        public bool RememberMe { get; set; } = false;
        public int Transaction { get; set; } // 1 Login - 0 Register
    }
}
