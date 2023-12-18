using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Models;
using WebApplication2.Controllers;
using ModeloFilmersGen.Infraestructure.Repository.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using System.Data.SqlClient;
using ModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto;
using ModeloFilmersGen.Infraestructure.CP;
using static NHibernate.Engine.Query.CallableParser;
using WebApplication2.Assemblers;
using Microsoft.AspNetCore.Authorization;
using NHibernate.Hql.Ast.ANTLR.Util;
using ModeloFilmersGen.Infraestructure.EN.Pruebadeesquemaproyecto;

namespace WebApplication2.Controllers
{ 
    public class HomeController : BasicController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            SessionInitialize();

            PeliculaRepository peliculaRepository = new PeliculaRepository(session);
            UsuarioRepository usuarioRepository = new UsuarioRepository(session);
           

            PeliculaCEN peliculacen = new PeliculaCEN(peliculaRepository);
            UsuarioCP usCP = new UsuarioCP(new SessionCPNHibernate());
            UsuarioCEN usCEN = new UsuarioCEN(usuarioRepository);

            
            IList<PeliculaEN> listapelEN = peliculacen.DameTodos(0, -1);


            UsuarioViewModel usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            IList<PeliculaVistaViewModel> listapelvistaVM = new List<PeliculaVistaViewModel>();
            if (usuario != null)
            {

                IList<PeliculaVistaEN> ultimasVistasEN = usCP.ActividadAmigos(usuario.Email);
                
                foreach (var ultVistas in ultimasVistasEN)
                {

                    PeliculaEN peliculaEN = peliculacen.DamePorOID(ultVistas.Pelicula.Id);
                    UsuarioEN usuEN = usCEN.DamePorOID(ultVistas.Usuario.Email);

                    PeliculaVistaViewModel pelicuVM = new PeliculaVistaViewModel
                    {
                        Id = ultVistas.Id,
                        comentario = ultVistas.Comentario,
                        valoracion = ultVistas.Valoracion,
                        fecha = (DateTime)ultVistas.Fecha,
                        idPelicula = ultVistas.Pelicula.Id,
                        nombrePeli = peliculaEN.Nombre,
                        fotoPeli = peliculaEN.Caratula,
                        nombreUsuario = usuEN.Nombre,

                    };

                    listapelvistaVM.Add(pelicuVM);
                }
            }
            
            

            
            

            IEnumerable<PeliculaViewModel> peliculasViewModel = new PeliculaAssembler().ConvertirListEnToViewModel(listapelEN.ToList());
            

            var model = new PeliculasYVistasViewModel
            {
                Peliculas = peliculasViewModel,
                UltimasVistas = listapelvistaVM
            };
            SessionClose();

            return View(model);


        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}