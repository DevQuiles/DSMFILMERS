using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class PassUsuarioViewModel
    {
        [ScaffoldColumn(true)]
        [Display(Prompt = "Introduce tu password antigua de usuario", Description = "Password Usuario ", Name = "Password")]
        [Required(ErrorMessage = "Debe indicar su password")]
        [DataType(DataType.Password)]
        public String PasswordAntigua { get; set; }

        [ScaffoldColumn(true)]
        [Display(Prompt = "Introduce tu nueva password de usuario", Description = "Nueva Password Usuario", Name = "NewPassword")]
        [Required(ErrorMessage = "Debe indicar su password")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}
