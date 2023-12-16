using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.Infraestructure.Repository.Pruebadeesquemaproyecto;
using WebApplication2.Assemblers;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class UsuarioController : BasicController
    {
        // GET: UsuarioController/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: UsuarioController/Login
        [HttpPost]
        public ActionResult Login(LoginUsuarioViewModel login)
        {
            SessionInitialize();
            UsuarioRepository usuarioRepo = new UsuarioRepository(session);
            UsuarioCEN usuCen = new UsuarioCEN(usuarioRepo);

            if (usuCen.Login(login.Email, login.Password) == null)
            {
                ModelState.AddModelError("", "Error al introducir los datos de EMAIL o password");
                SessionClose();
                return View();
            }
            else 
            {
                //SessionInitialize();
                UsuarioEN usuEN = usuCen.DamePorOID(login.Email);
                UsuarioViewModel usuVM = new UsuarioAssembler().ConvertirENToViewModel(usuEN);
                HttpContext.Session.Set<UsuarioViewModel>("usuario", usuVM);
                SessionClose();
                return RedirectToAction("Index", "Home");
            }
            return View();
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
                    idPelicula = peliculaVistaEN.Pelicula.Id,
                    nombrePeli = peliculaEN.Nombre,
                    fotoPeli = peliculaEN.Caratula, // Suponiendo que 'Caratula' es la propiedad que contiene la URL de la imagen de la carátula
                                                    // Agrega otras propiedades que necesites
                };

                listapelivistaVM.Add(peliculaViewModel);
            }

            SessionClose();

            return PartialView("_VistasUsuario", listapelivistaVM);
        }


        // GET: UsuarioController/Details/5
        public ActionResult Details(String id)
        {
            SessionInitialize();
            UsuarioRepository usuRep = new UsuarioRepository(session);
            UsuarioCEN usuCen = new UsuarioCEN(usuRep);

            UsuarioEN usuen = usuCen.DamePorOID(id);


            //UsuarioViewModel usu = new UsuarioViewModel
            //{
            //    // ... inicialización de otros datos del usuario
            //    ListaPelisVistas = usuen.PeliculasVistas // Asigna la lista de películas a ListaPeliculasVistas en el modelo
            //};

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
                usuCen.CrearUsuario(usuVM.Email, usuVM.NombreUsuario, usuVM.Nombre, usuVM.FechaNac, usuVM.Localidad, usuVM.Pais, ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.NivelesEnum.Aficionado , usuVM.Pass, false, usuVM.Avatar);
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

                usuCen.ModificarUsuario(id, usuVM.NombreUsuario, usuVM.Nombre, usuVM.FechaNac, usuVM.Localidad, usuVM.Pais, usuen.Nivel, usuVM.Pass, usuen.RecompensaDisponible, usuVM.Avatar);
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
                String contrasenya2 = ModeloFilmersGen.ApplicationCore.Utils.Util.GetEncondeMD5(pusuVM.PasswordAntigua);
                if ( usuen.Pass == contrasenya)
                {
                    usuCen.ModificarUsuario(id, usuen.NomUsuario, usuen.Nombre, usuen.FechaNac, usuen.Localidad, usuen.Pais, usuen.Nivel, pusuVM.Password, usuen.RecompensaDisponible, usuen.AvatarIcon);
                }
                return RedirectToAction(nameof(Index));
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
    }
}


