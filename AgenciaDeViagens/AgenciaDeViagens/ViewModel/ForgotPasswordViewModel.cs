using System.ComponentModel.DataAnnotations;

namespace AgenciaDeViagens.ViewModel
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
