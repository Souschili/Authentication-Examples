using System.ComponentModel.DataAnnotations;

namespace Auth.Basic.Controllers
{
    public class LoginViewModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string ReturnUrl { get; set; }

    }
}
