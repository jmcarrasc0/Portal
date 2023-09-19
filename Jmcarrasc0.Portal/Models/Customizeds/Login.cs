using System.ComponentModel.DataAnnotations;

namespace Jmcarrasc0.Portal.Models.Customizeds
{
    public class Login
    {

        [Required]
        [Display(Name = "Usuario")]

        public string Usuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
    }
}
