using System.ComponentModel.DataAnnotations;

namespace Products.ViewModels.Authantication
{
    public class LogInViewModel
    {
        [EmailAddress]
        public string Email { get; set; } = null!;
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
