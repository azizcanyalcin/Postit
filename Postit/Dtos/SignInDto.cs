using System.ComponentModel.DataAnnotations;

namespace Postit.Dtos
{
    public class SignInDto
    {
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre gereklidir.")]
        public string Password { get; set; }

    }
}
