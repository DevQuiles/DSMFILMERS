using Microsoft.AspNetCore.Mvc;
using NHibernate;
using ModeloFilmersGen.Infraestructure.CP;
using ModeloFilmersGen.Infraestructure.Repository.Pruebadeesquemaproyecto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using WebApplication2.Models;
using WebApplication2.Assemblers;

namespace WebApplication2.Controllers
{
    public class PlaylistController : BasicController
    {

        public ActionResult PlayListByUsuario()
        {
            SessionInitialize();
            UsuarioViewModel usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            UsuarioRepository usR = new UsuarioRepository(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usR);
            UsuarioEN usuarioEN = usuarioCEN.DamePorOID(usuario.Email);

            var playlistENs = new List<object>();

            foreach (var i in usuarioEN.Playlistcreadas)
            {
                var playlistItem = new
                {
                    nombrePlaylist = i.Nombre
                };

                playlistENs.Add(playlistItem);
            }

            return Json(playlistENs);
        }

        // GET: PlaylistController
        public ActionResult Index()
        {
            SessionInitialize();
            PlaylistRepository playRepository = new PlaylistRepository();
            PlaylistCEN playCEN = new PlaylistCEN(playRepository);

            IList<PlaylistEN> playEN = playCEN.DameTodos(0, -1);

            IEnumerable<PlaylistViewModel> listPlay = new PlaylistAssembler().ConvertirListEnToViewModel(playEN).ToList();
            SessionClose();

            return View(listPlay);
        }

        // GET: PlaylistController/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            PlaylistRepository playlistRepository = new PlaylistRepository(session);
            PlaylistCEN playlistCEN = new PlaylistCEN(playlistRepository);

            PlaylistEN playlistEN = playlistCEN.DamePorOID(id);
            PlaylistViewModel playlistViewModel = new PlaylistAssembler().ConvertirEnToViewModel(playlistEN);

            IList<PeliculaEN> peliculasEnPlay = new List<PeliculaEN>();

            foreach(var i in playlistEN.Peliculas)
            {
                peliculasEnPlay.Add(i);
            }

            IList<PeliculaViewModel> p = new PeliculaAssembler().ConvertirListEnToViewModel(peliculasEnPlay).ToList();

            var vista = new PlayList_PeliculasViewModel
            {
                Playlist = playlistViewModel,
                Pelicula = p
            };

            SessionClose();

            return View(vista);
        }

        // GET: PlaylistController/Create
        public ActionResult Create()
        {
            SessionInitialize();
            PlaylistRepository playlistRepository = new PlaylistRepository(session);
            PlaylistCEN playlistCEN = new PlaylistCEN(playlistRepository);
            PlaylistEN playlistEN = new PlaylistEN();
            PlaylistViewModel playlistViewModel = new PlaylistAssembler().ConvertirEnToViewModel(playlistEN);
            

            SessionClose();

            return View(playlistViewModel);
        }

        // POST: PlaylistController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlaylistViewModel play)
        {
            try
            {
                UsuarioViewModel usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");
                PlaylistRepository playlistRepository = new PlaylistRepository();
                PlaylistCEN playlistCEN = new PlaylistCEN(playlistRepository);
                int id =  playlistCEN.CrearPlaylist(play.nombre, play.Descripcion, usuario.Email);
                return RedirectToAction("Details", new { id });
            }
            catch
            {
                return View();
            }
        }

        // GET: PlaylistController/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            PlaylistRepository playlistRepository = new PlaylistRepository();
            PlaylistCEN playlistCEN = new PlaylistCEN(playlistRepository);

            PlaylistEN playlistEN = playlistCEN.DamePorOID(id);
            PlaylistViewModel playlistViewModel = new PlaylistAssembler().ConvertirEnToViewModel(playlistEN);

            SessionClose();
            return View(playlistViewModel);
        }

        // POST: PlaylistController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PlaylistViewModel play)
        {
            try
            {
                PlaylistRepository playlistRepository = new PlaylistRepository();
                PlaylistCEN playlistCEN = new PlaylistCEN(playlistRepository);
                playlistCEN.ModificarPlaylist(id, play.nombre, play.Descripcion);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlaylistController/Delete/5
        public ActionResult Delete(int id)
        {
            PlaylistRepository playlistRepository = new PlaylistRepository();
            PlaylistCEN playlistCEN = new PlaylistCEN(playlistRepository);
            playlistCEN.BorrarPlaylist(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: PlaylistController/Delete/5
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
