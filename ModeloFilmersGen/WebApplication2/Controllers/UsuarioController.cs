using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.Infraestructure.Repository.Pruebadeesquemaproyecto;
using System.Security.Claims;
using WebApplication2.Assemblers;
using WebApplication2.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace WebApplication2.Controllers
{
    public class UsuarioController : BasicController
    {
        // GET: UsuarioController/Login
        public ActionResult Login()
        {
            return View();
        }

        //--------------------------------------------------GOOGLE---------------------------------------------------------------
        public async Task LoginConGoogle()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme,
                new AuthenticationProperties
                {
                    RedirectUri = Url.Action("RespuestaGoogle")
                });
        }

        public async Task<IActionResult> RespuestaGoogle()
        {
            SessionInitialize();
            UsuarioRepository usuarioRepo = new UsuarioRepository(session);
            UsuarioCEN usuCEN = new UsuarioCEN(usuarioRepo);

            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (!result.Succeeded)
            {
                TempData["Error"] = "Error en la autenticación con Google. Por favor, intenta nuevamente o usa otro método de autenticación.";
                return RedirectToAction("Login");
            }

            var googleId = result.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
            var email = result.Principal.FindFirstValue(ClaimTypes.Email);

            UsuarioEN usuEN = usuCEN.DamePorOID(email);

            if (usuEN != null)
            {
                UsuarioViewModel usuVM = new UsuarioAssembler().ConvertirENToViewModel(usuEN);
                HttpContext.Session.Set<UsuarioViewModel>("usuario", usuVM);
                SessionClose();
                return RedirectToAction("Index", "Home");

            }
            else
            {
                TempData["Error"] = "Error no hay ningún usuario con este email asociado";
                return RedirectToAction("Login");
            }
        }

        public async Task EnlazarCuentaConGoogle()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme,
                new AuthenticationProperties
                {
                    RedirectUri = Url.Action("RespuestaEnlaceGoogle")
                });
        }

        public bool ObtenerUsuariosPorGoogleId(string googleId)
        {
            IList<String> values = null;
            return true;
        }

        public async Task<IActionResult> RespuestaEnlaceGoogle()
        {
            SessionInitialize();
            UsuarioRepository usuarioRepo = new UsuarioRepository(session);
            UsuarioCEN usuCEN = new UsuarioCEN(usuarioRepo);

            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (!result.Succeeded)
            {
                TempData["Error"] = "Error en la autenticación con Google. Por favor, intenta nuevamente.";
                return RedirectToAction("Index", "Home");
            }

            var googleId = result.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
            var googleEmail = result.Principal.FindFirstValue(ClaimTypes.Email);

            IList<UsuarioEN> usuariosIguales = usuCEN.DameTodos(0, -1);
            var asociado = false;
            foreach (var user in usuariosIguales)
            {
                if (user.UsuarioGoogle == googleId)
                {
                    asociado = true; break;
                }
            }



            // Obtener el usuario actualmente logueado
            UsuarioViewModel usuarioActual = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (usuarioActual != null && !asociado && usuarioActual.Email == googleEmail)
            {

                usuCEN.AsociarUsuarioGoogle(usuarioActual.Email, googleId);

                TempData["Success"] = "Cuenta de Google enlazada correctamente.";

            }
            else if(usuarioActual.Email != googleEmail)
            {
                TempData["Error"] = "El email que intentas asociar no es el mismo que con el que te registraste";
            }
            else
            {
                TempData["Error"] = "El email ya esta siendo usado por otra cuenta";

            }

            return RedirectToAction("Details", "Usuario", new { id = usuarioActual.Email });
        }

        //-----------------------------------------------------------------------------------------------------------------

        // POST: UsuarioController/Login
        [HttpPost]
        public ActionResult Login(LoginUsuarioViewModel login)
        {
            SessionInitialize();
            UsuarioRepository usuarioRepo = new UsuarioRepository(session);
            UsuarioCEN usuCEN = new UsuarioCEN(usuarioRepo);

            if (usuCEN.Login(login.Email, login.Password) == null)
            {
                ModelState.AddModelError("", "Error al introducir los datos de EMAIL o password");
                SessionClose();
                return View();
            }
            else
            {
                //SessionInitialize();
                UsuarioEN usuEN = usuCEN.DamePorOID(login.Email);
                UsuarioViewModel usuVM = new UsuarioAssembler().ConvertirENToViewModel(usuEN);
                HttpContext.Session.Set<UsuarioViewModel>("usuario", usuVM);
                SessionClose();
                return RedirectToAction("Index", "Home");
            }

        }

        public ActionResult Logout()
        {
            HttpContext.Session.Remove("usuario");
            return RedirectToAction("Login", "Usuario");
        }

        public ActionResult Index(string searchString)
        {
            SessionInitialize();
            UsuarioRepository usuRepository = new UsuarioRepository(session);
            UsuarioCEN usuCEN = new UsuarioCEN(usuRepository);

            IList<UsuarioEN> usuEN;

            if (!string.IsNullOrEmpty(searchString))
            {
                usuEN = usuCEN.DameUsuarioPorNombre(searchString); // Usar el método de filtrado por nombre
            }
            else
            {
                usuEN = usuCEN.DameTodos(0, -1); // Obtener todos si no se proporciona una cadena de búsqueda
            }

            IEnumerable<UsuarioViewModel> listUsus = new UsuarioAssembler().ConvertirListENToViewModel(usuEN).ToList();
            SessionClose();

            return View(listUsus);
        }

        public ActionResult Vistas(string id)
        {
            SessionInitialize();
            UsuarioRepository usuarioRepo = new UsuarioRepository(session);

            UsuarioCEN usuCEN = new UsuarioCEN(usuarioRepo);
            UsuarioEN usuarioEN = usuCEN.DamePorOID(id);

            IList<PeliculaVistaEN> listpelisEN = usuarioEN.PeliculasVistas;
            IList<PeliculaVistaViewModel> listapelivistaVM = new List<PeliculaVistaViewModel>();

            foreach (var peliculaVistaEN in listpelisEN)
            {
                // Suponiendo que PeliculaVistaEN tiene una propiedad Pelicula que referencia a PeliculaEN
                PeliculaEN peliculaEN = peliculaVistaEN.Pelicula;

                // Crear un ViewModel para la película con la información necesaria (nombre, carátula, etc.)
                PeliculaVistaViewModel peliculaViewModel = new PeliculaVistaViewModel
                {
                    Id = peliculaVistaEN.Id,
                    comentario = peliculaVistaEN.Comentario,
                    valoracion = peliculaVistaEN.Valoracion,
                    fecha = (DateTime)peliculaVistaEN.Fecha,
                    idPelicula = peliculaEN.Id,
                    nombrePeli = peliculaEN.Nombre,
                    fotoPeli = peliculaEN.Caratula,

                };

                listapelivistaVM.Add(peliculaViewModel);
            }

            SessionClose();

            return PartialView("_VistasUsuario", listapelivistaVM);
        }

        public ActionResult Calendario(string id)
        {
            SessionInitialize();
            UsuarioRepository usuarioRepo = new UsuarioRepository(session);

            UsuarioCEN usuCEN = new UsuarioCEN(usuarioRepo);
            UsuarioEN usuarioEN = usuCEN.DamePorOID(id);

            IList<PeliculaVistaEN> listpelisEN = usuarioEN.PeliculasVistas;
            IList<PeliculaVistaViewModel> listapelivistaVM = new List<PeliculaVistaViewModel>();

            foreach (var peliculaVistaEN in listpelisEN)
            {
                // Suponiendo que PeliculaVistaEN tiene una propiedad Pelicula que referencia a PeliculaEN
                PeliculaEN peliculaEN = peliculaVistaEN.Pelicula;

                // Crear un ViewModel para la película con la información necesaria (nombre, carátula, etc.)
                PeliculaVistaViewModel peliculaViewModel = new PeliculaVistaViewModel
                {
                    Id = peliculaVistaEN.Id,
                    comentario = peliculaVistaEN.Comentario,
                    valoracion = peliculaVistaEN.Valoracion,
                    fecha = (DateTime)peliculaVistaEN.Fecha,
                    idPelicula = peliculaEN.Id,
                    nombrePeli = peliculaEN.Nombre,
                    fotoPeli = peliculaEN.Caratula, // Suponiendo que 'Caratula' es la propiedad que contiene la URL de la imagen de la carátula
                                                    // Agrega otras propiedades que necesites
                };

                listapelivistaVM.Add(peliculaViewModel);
            }

            listapelivistaVM = listapelivistaVM
            .OrderByDescending(p => p.fecha.HasValue ? p.fecha.Value.Year : 0)
            .ThenByDescending(p => p.fecha.HasValue ? p.fecha.Value.Month : 0)
            .ThenBy(p => p.fecha.HasValue ? p.fecha.Value.Day : 0) 
            .ToList();

            SessionClose();

            return PartialView("_CalendarioUsuario", listapelivistaVM);
        }

        public ActionResult Deseos(string id)
        {
            SessionInitialize();
            UsuarioRepository usuarioRepo = new UsuarioRepository(session);

            UsuarioCEN usuCEN = new UsuarioCEN(usuarioRepo);
            UsuarioEN usuarioEN = usuCEN.DamePorOID(id);

            IList<PeliculaEN> listpelisEN = usuarioEN.Deseadas;
            IList<PeliculaViewModel> listapeliVM = new List<PeliculaViewModel>();

            foreach (var peliculaEN in listpelisEN)
            {

                // Crear un ViewModel para la película con la información necesaria (nombre, carátula, etc.)
                PeliculaViewModel peliculaViewModel = new PeliculaAssembler().ConvertirEnToViewModel(peliculaEN);

                listapeliVM.Add(peliculaViewModel);
            }


            SessionClose();

            return PartialView("_DeseosUsuario", listapeliVM);
        }


        // GET: UsuarioController/Details/5
        public ActionResult Details(String id)
        {
            SessionInitialize();
            UsuarioRepository usuRep = new UsuarioRepository(session);
            UsuarioCEN usuCen = new UsuarioCEN(usuRep);

            UsuarioEN usuen = usuCen.DamePorOID(id);

            UsuarioViewModel usu = new UsuarioAssembler().ConvertirENToViewModel(usuen);
            SessionClose();
            return View(usu);
        }

        // GET: UsuarioController/Details/5
        public ActionResult DetailsPerfil(String id)
        {
            SessionInitialize();
            UsuarioRepository usuRep = new UsuarioRepository(session);
            UsuarioCEN usuCen = new UsuarioCEN(usuRep);

            UsuarioEN usuen = usuCen.DamePorOID(id);

            UsuarioViewModel usu = new UsuarioAssembler().ConvertirENToViewModel(usuen);
            SessionClose();
            return View(usu);
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {


            var avatares = Enum.GetValues(typeof(ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.AvatarEnum))
                   .Cast<ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.AvatarEnum>()
                   .Select(e => new SelectListItem
                   {
                       Text = e.ToString(),
                       Value = ((int)e).ToString()
                   })
                   .ToList();

            ViewData["Avatares"] = avatares;

            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel usuVM)
        {
            try
            {
                UsuarioRepository usuRepo = new UsuarioRepository();
                UsuarioCEN usuCen = new UsuarioCEN(usuRepo);
                HttpContext.Session.Set<UsuarioViewModel>("usuario", usuVM);

                usuCen.CrearUsuario(usuVM.Email, usuVM.NombreUsuario, usuVM.Nombre, usuVM.FechaNac, usuVM.Localidad, usuVM.Pais, ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.NivelesEnum.Aficionado, usuVM.Pass, false, usuVM.Avatar,"No asignado");

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(String id)
        {
            var avatares = Enum.GetValues(typeof(ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.AvatarEnum))
                   .Cast<ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.AvatarEnum>()
                   .Select(e => new SelectListItem
                   {
                       Text = e.ToString(),
                       Value = ((int)e).ToString()
                   })
                   .ToList();

            ViewData["Avatares"] = avatares;

            SessionInitialize();
            UsuarioRepository usuRep = new UsuarioRepository(session);
            UsuarioCEN usuCen = new UsuarioCEN(usuRep);

            UsuarioEN usuen = usuCen.DamePorOID(id);
            UsuarioViewModel usuVM = new UsuarioAssembler().ConvertirENToViewModel(usuen);

            SessionClose();
            return View(usuVM);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(String id, UsuarioViewModel usuVM)
        {
            try
            {
                UsuarioRepository usuRep = new UsuarioRepository();
                UsuarioCEN usuCen = new UsuarioCEN(usuRep);
                UsuarioEN usuen = usuCen.DamePorOID(id);

                // Verifica si el campo de contraseña está vacío
                if (string.IsNullOrEmpty(usuVM.Pass))
                {
                    usuVM.Pass = usuen.Pass; // Mantiene la contraseña actual si el campo está vacío
                }

                if (usuVM.usuarioGoogle != "No asignado") {
                    usuVM.usuarioGoogle = usuen.UsuarioGoogle;
                }

                // Modifica el usuario con la contraseña actualizada (o la misma si no se cambió)
                usuCen.ModificarUsuario(id, usuVM.NombreUsuario, usuVM.Nombre, usuVM.FechaNac, usuVM.Localidad, usuVM.Pais, usuen.Nivel, usuVM.Pass, usuen.RecompensaDisponible, usuVM.Avatar, usuVM.usuarioGoogle);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: UsuarioController/EditPass/5
        public ActionResult EditPass(String id)
        {
            return View();
        }

        // POST: UsuarioController/EditPass/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPass(String id, PassUsuarioViewModel pusuVM)
        {
            try
            {
                UsuarioRepository usuRep = new UsuarioRepository();
                UsuarioCEN usuCen = new UsuarioCEN(usuRep);
                UsuarioEN usuen = usuCen.DamePorOID(id);
                String contrasenya = ModeloFilmersGen.ApplicationCore.Utils.Util.GetEncondeMD5(pusuVM.PasswordAntigua);
                if (usuen.Pass == contrasenya)
                {
                    usuCen.ModificarUsuario(id, usuen.NomUsuario, usuen.Nombre, usuen.FechaNac, usuen.Localidad, usuen.Pais, usuen.Nivel, pusuVM.Password, usuen.RecompensaDisponible, usuen.AvatarIcon, null);
                }
                return RedirectToAction("Edit", "Usuario", new { id = id });

            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult RecargarSesion(string idUsuario)
        {
            SessionInitialize();
            UsuarioRepository usuarioRepo = new UsuarioRepository(session);
            UsuarioCEN usuCen = new UsuarioCEN(usuarioRepo);

            UsuarioEN usuEN = usuCen.DamePorOID(idUsuario);
            UsuarioViewModel usuVM = new UsuarioAssembler().ConvertirENToViewModel(usuEN);
            HttpContext.Session.Set<UsuarioViewModel>("usuario", usuVM);
            SessionClose();



            return Ok();
        }
    }
}


