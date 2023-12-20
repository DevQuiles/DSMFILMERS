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
using ModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto;

namespace WebApplication2.Controllers
{
    public class PlaylistController : BasicController
    {


        public ActionResult desAsignar(string idPelicula, string idPlaylist)
        {

            SessionInitialize();

            PlaylistRepository playlistRepository = new PlaylistRepository();
            PlaylistCEN playlistCEN = new PlaylistCEN(playlistRepository);
            playlistCEN.DesasignarPeliculas(int.Parse(idPlaylist), new List<int> { int.Parse(idPelicula) });

            SessionClose();

            return Json(new { success = true }); ;
        }






        [HttpPost]
        public IActionResult AgregarPeliculaAPlaylist(string idPelicula, string idPlaylist)
        {
            SessionInitialize();
            int idP = int.Parse(idPelicula);
            int idPlay = int.Parse(idPlaylist);

            PlaylistRepository playlistRepository = new PlaylistRepository();
            PlaylistCEN playlistCEN = new PlaylistCEN(playlistRepository);      

            playlistCEN.AsignarPeliculas(idPlay, new List<int> { idP });

            SessionClose();
            return Json(new { success = true, redirectUrl = Url.Action("Details", new { id = idPlay }) }); ;

        }

        [HttpPost]
        public IActionResult AgregarPlaylistAFavoritos(string idPlaylist, string idUsuario)
        {
            SessionInitialize();

            int idPlay = int.Parse(idPlaylist);

            PlaylistRepository playlistRepository = new PlaylistRepository();
            PlaylistCEN playlistCEN = new PlaylistCEN(playlistRepository);
            UsuarioRepository usR = new UsuarioRepository(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usR);

            playlistCEN.AsignarSuscriptor(idPlay, new List<string> { idUsuario });

            SessionClose();
            return Json(new { success = true });
        }

        private IDictionary<int, IList<string>> ObtenerCaratulasParaPlaylists(IList<PlaylistEN> playlists)
        {
            IDictionary<int, IList<string>> caratulasPorPlaylist = new Dictionary<int, IList<string>>();

            foreach (var playlist in playlists)
            {
                IList<string> caratulasDePlaylist = new List<string>();
                foreach (var movie in playlist.Peliculas)
                {
                    caratulasDePlaylist.Add(movie.Caratula);
                }
                caratulasPorPlaylist.Add(playlist.Id, caratulasDePlaylist); // Asume que 'Id' es un identificador único de PlaylistEN
            }

            return caratulasPorPlaylist;
        }

        public ActionResult PlayListByUsuario()
        {
            SessionInitialize();
            UsuarioViewModel usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            UsuarioRepository usR = new UsuarioRepository(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usR);
            var playlistENs = new List<object>();
            if (usuario != null)
            {
                UsuarioEN usuarioEN = usuarioCEN.DamePorOID(usuario.Email);
                foreach (var i in usuarioEN.Playlistcreadas)
                {
                    var playlistItem = new
                    {
                        id = i.Id,
                        nombrePlaylist = i.Nombre,
                        descripcion = i.Descripcion
                    };

                    playlistENs.Add(playlistItem);
                }
            }
            return Json(playlistENs);
        }

        public ActionResult IndexCarrusel()
        {
            // Inicializa la sesión
            SessionInitialize();

            // Creación y configuración del repositorio y del CEN de Playlist
            PlaylistRepository playlistRepository = new PlaylistRepository(session);
            PlaylistCEN playlistCEN = new PlaylistCEN(playlistRepository);

            // Obtención de todas las playlists
            IList<PlaylistEN> playEN = playlistCEN.DameTodos(0, -1);

            // Conversión de las entidades PlaylistEN a ViewModels
            IList<PlaylistViewModel> listPlay = new PlaylistAssembler().ConvertirListEnToViewModel(playEN).ToList();

            // Obtención de las carátulas para cada playlist
            IDictionary<int, IList<string>> caratulas = ObtenerCaratulasParaPlaylists(playEN);

            // Creación del ViewModel para la vista
            var viewModel = new PlatyListyPeliculasFotosViewModel
            {
                Playlist = listPlay,
                CaratulasPorPlaylist = caratulas // Asegúrate de tener esta propiedad en tu ViewModel
            };

            // Cierre de la sesión
            SessionClose();

            // Retorna la vista con el ViewModel
            return View(viewModel);
        }




        // GET: PlaylistController
        public ActionResult Index()
        {
            // Inicializa la sesión
            SessionInitialize();

            // Creación y configuración del repositorio y del CEN de Playlist
            PlaylistRepository playlistRepository = new PlaylistRepository(session);
            PlaylistCEN playlistCEN = new PlaylistCEN(playlistRepository);

            // Obtención de todas las playlists
            IList<PlaylistEN> playEN = playlistCEN.DameTodos(0, -1);

            // Conversión de las entidades PlaylistEN a ViewModels
            IList<PlaylistViewModel> listPlay = new PlaylistAssembler().ConvertirListEnToViewModel(playEN).ToList();

            // Obtención de las carátulas para cada playlist
            IDictionary<int, IList<string>> caratulas = ObtenerCaratulasParaPlaylists(playEN);

            // Creación del ViewModel para la vista
            var viewModel = new PlatyListyPeliculasFotosViewModel
            {
                Playlist = listPlay,
                CaratulasPorPlaylist = caratulas // Asegúrate de tener esta propiedad en tu ViewModel
            };

            // Cierre de la sesión
            SessionClose();

            // Retorna la vista con el ViewModel
            return View(viewModel);

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
            UsuarioViewModel usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            try
            {
                
                PlaylistRepository playlistRepository = new PlaylistRepository(session);
                PlaylistCEN playlistCEN = new PlaylistCEN(playlistRepository);
                PlaylistEN playlistEN = playlistCEN.DamePorOID(id);
                int numPelis = playlistEN.Peliculas.Count;

                if(numPelis == 0)
                {
                    playlistCEN.BorrarPlaylist(id);
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Debes de borrar las peliculas de la playlist antes de poder eliminarla";
            }

            return RedirectToAction("DetailsPerfil","Usuario", new { id = usuario.Email });
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
