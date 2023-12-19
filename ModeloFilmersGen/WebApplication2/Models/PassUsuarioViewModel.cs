using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class PassUsuarioViewModel
    {
        [ScaffoldColumn(true)]
        [Display(Prompt = "Introduce tu contraseña actual", Description = "Constraseña actual", Name = "Password")]
        [Required(ErrorMessage = "Debe indicar su contraseña")]
        [DataType(DataType.Password)]
        public String PasswordAntigua { get; set; }

        [ScaffoldColumn(true)]
        [Display(Prompt = "Introduce tu nueva constraseña", Description = "Nueva Contraseña", Name = "NewPassword")]
        [Required(ErrorMessage = "Debe indicar su nueva contraseña")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}
