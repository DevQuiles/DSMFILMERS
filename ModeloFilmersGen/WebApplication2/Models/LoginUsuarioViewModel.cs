using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class LoginUsuarioViewModel
    {
        [ScaffoldColumn(true)]
        [Display(Prompt = "Introduce tu email de usuario", Description = "Email Usuario", Name = "Email")]
        [Required(ErrorMessage = "Debe indicar su email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Debe indicar una dirección de email correcta")]
        public String Email { get; set; }

        [ScaffoldColumn(true)]
        [Display(Prompt = "Introduce tu password de usuario", Description = "Password Usuario", Name = "Password")]
        [Required(ErrorMessage = "Debe indicar su password")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}
