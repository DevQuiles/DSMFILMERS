using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.Infraestructure.Repository.Pruebadeesquemaproyecto;
using WebApplication2.Assemblers;
using WebApplication2.Models;

using System.Linq;
using ModeloFilmersGen.Infraestructure.CP;

namespace WebApplication2.Controllers
{
    public class NotificacionesController : BasicController
    {
        // Lógica para seguir al usuario
        
        public IActionResult Follow(string id, string idSeguido)
        {

            SessionInitialize();
            UsuarioRepository usuarioRepository = new UsuarioRepository(session);

            UsuarioCP usuarioCP = new UsuarioCP(new SessionCPNHibernate());
            usuarioCP.Follow(id, idSeguido);
            SessionClose();



            return Ok();
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


        public IActionResult Unfollow(string id, string idSeguido)
        {

            SessionInitialize();
            UsuarioRepository usuarioRepository = new UsuarioRepository(session);

            UsuarioCP usuarioCP = new UsuarioCP(new SessionCPNHibernate());
            usuarioCP.Unfollow(id, idSeguido);
            SessionClose();

            return Ok();
        }

        // GET: NotificacionesController
        public ActionResult Index()
        {
            SessionInitialize();
            NotificacionesRepository notRepository = new NotificacionesRepository(session);
            UsuarioRepository usuarioRepository = new UsuarioRepository(session);
            PeliculaRepository peliculaRepository = new PeliculaRepository(session);

            NotificacionesCEN notCEN = new NotificacionesCEN(notRepository);
            PeliculaCEN pelCEN = new PeliculaCEN(peliculaRepository);
            UsuarioCEN usuCEN = new UsuarioCEN(usuarioRepository);

            UsuarioViewModel usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");

            UsuarioEN usEN = usuCEN.DamePorOID(usuario.Email);
            IList<NotificacionesEN> notsEN = usEN.Notificaciones.ToList();
            IList<NotificacionesViewModel> notificaionesVM = new List<NotificacionesViewModel>();

            foreach (var noti in notsEN)
            {
                UsuarioEN usEN2 = usuCEN.DamePorOID(noti.UsuariorEmisor);

                NotificacionesViewModel notiVM = new NotificacionesViewModel();

                if (noti.Pelicula != -1)
                {

                    PeliculaEN pelEN = pelCEN.DamePorOID(noti.Pelicula);

                    notiVM = new NotificacionesViewModel
                    {
                        Id = noti.Id,
                        Fecha = (DateTime)noti.Fecha,
                        Contenido = noti.Contenido,
                        Estado = noti.Estado,
                        Destacada = noti.Destacada,
                        IdUsuario = noti.Usuario.Email,
                        idPelicula = noti.Pelicula,
                        nombrePeli = pelEN.Nombre,
                        IdUsuarioEmisor = noti.UsuariorEmisor,
                        fotoUsuarioEmisor = usEN2.AvatarIcon,
                    };
                }
                else
                {

                    notiVM = new NotificacionesViewModel
                    {
                        Id = noti.Id,
                        Fecha = (DateTime)noti.Fecha,
                        Contenido = noti.Contenido,
                        Estado = noti.Estado,
                        Destacada = noti.Destacada,
                        IdUsuario = noti.Usuario.Email,
                        idPelicula = noti.Pelicula,
                        IdUsuarioEmisor = noti.UsuariorEmisor,
                        fotoUsuarioEmisor = usEN.AvatarIcon,
                    };

                }




                notificaionesVM.Add(notiVM);
            }


            SessionClose();

            return View(notificaionesVM);
        }

        // GET: NotificacionesController/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            NotificacionesRepository notRepo = new NotificacionesRepository(session);
            NotificacionesCEN notCEN = new NotificacionesCEN(notRepo);

            NotificacionesEN notEN = notCEN.DamePorOID(id);

            NotificacionesViewModel notVM = new NotificacionesAssembler().ConvertirEnToViewModel(notEN);

            SessionClose();

            return View(notVM);
        }

        // GET: NotificacionesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NotificacionesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: NotificacionesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NotificacionesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: NotificacionesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NotificacionesController/Delete/5
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
