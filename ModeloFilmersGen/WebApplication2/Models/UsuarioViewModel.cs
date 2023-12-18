using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class UsuarioViewModel
    {
        [ScaffoldColumn(true)]
        [Display(Prompt = "Introduce el email", Description = "Email", Name = "Email")]
        [Required(ErrorMessage = "Debe indicar una dirección de email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Debe indicar una dirección de email correcta")]
        public String Email { get; set; }

        [ScaffoldColumn(true)]
        [Display(Prompt = "Introduce el nombre de usuario", Description = "Nombre de usuario", Name = "Nombre de usuario")]
        [Required(ErrorMessage = "Debe indicar un nombre de usuario")]
        public String NombreUsuario { get; set; }

        [ScaffoldColumn(true)]
        [Display(Prompt = "Introduce el nombre", Description = "Nombre", Name = "Nombre")]
        [Required(ErrorMessage = "Debe indicar un nombre")]
        public String Nombre { get; set; }

        [ScaffoldColumn(true)]
        [Display(Prompt = "Introduce la fecha de nacimiento", Description = "Fecha nacimiento", Name = "Fecha nacimiento")]
        [Required(ErrorMessage = "Debe indicar una fecha nacimiento")]
        [DataType(DataType.Date, ErrorMessage = "Debe indicar una fecha de nacimiento")]

        public DateTime FechaNac { get; set; }


        [ScaffoldColumn(true)]
        [Display(Prompt = "Introduce la localidad", Description = "Localidad", Name = "Localidad")]
        [Required(ErrorMessage = "Debe indicar una localidad")]

        public String Localidad { get; set; }

        [ScaffoldColumn(true)]
        [Display(Prompt = "Introduce un país", Description = "País", Name = "País")]
        [Required(ErrorMessage = "Debe indicar un país")]

        public String Pais { get; set; }

        [ScaffoldColumn(false)]
        public ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.NivelesEnum Nivel { get; set; }

        [ScaffoldColumn(true)]
        [Display(Prompt = "Introduce una contraseña", Description = "Contraseña", Name = "Contraseña")]
        [Required(ErrorMessage = "Debe indicar una contraseña")]
        [DataType(DataType.Password, ErrorMessage = "Debe indicar una contraseña")]

        public String Pass { get; set; }

        [ScaffoldColumn(false)]

        public Boolean Recompensa { get; set; }

        [ScaffoldColumn(false)]

        public ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.AvatarEnum Avatar { get; set; }

        [ScaffoldColumn(false)]
        public int Seguidores { get; set; }

        public IList<String> UsuariosSeguidos { get; set; }

        [ScaffoldColumn(false)]
        public int Seguidos { get; set; }

        [ScaffoldColumn(false)]
        public int PelisVistas { get; set; }

        //[ScaffoldColumn(false)]
        //public IList<PeliculaVistaEN> ListaPelisVistas { get; set; }

    }
}
