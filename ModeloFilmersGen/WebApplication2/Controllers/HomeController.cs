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

            PeliculaRepository peliculaRepository = new PeliculaRepository();
            PeliculaVistaRepository peliculaVistaRepository = new PeliculaVistaRepository(); 

            PeliculaCEN peliculacen = new PeliculaCEN(peliculaRepository);
            UsuarioCP usCP = new UsuarioCP(new SessionCPNHibernate());


            IList<PeliculaEN> listapelEN = peliculacen.DameTodos(0, -1);
            IList<PeliculaVistaEN> ultimasVistasEN = usCP.ActividadAmigos("email6"); 

            IEnumerable<PeliculaViewModel> peliculasViewModel = new PeliculaAssembler().ConvertirListEnToViewModel(listapelEN.ToList());
            IEnumerable<PeliculaVistaViewModel> peliculasVistasViewModel = new PeliculaVistaAssembler().ConvertirListEnToViewModel(ultimasVistasEN.ToList());

            var model = new PeliculasYVistasViewModel
            {
                Peliculas = peliculasViewModel,
                UltimasVistas = peliculasVistasViewModel
            };
            SessionClose();

            return View(model);


            //PeliculaRepository peliculaRepository = new PeliculaRepository();
            //PeliculaCEN peliculacen = new PeliculaCEN(peliculaRepository);

            //IEnumerable<PeliculaEN> listapel = peliculacen.DameTodos(0, -1);

            //return View(listapel);
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