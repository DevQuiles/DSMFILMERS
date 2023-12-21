using Microsoft.AspNetCore.Mvc;
using ModeloFilmersGen.Infraestructure.Repository.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using WebApplication2.Models;
using WebApplication2.Assemblers;


namespace WebApplication2.Controllers
{
    public class PeliculaController : BasicController
    {

        public ActionResult anyadirPeliculaAWatchList(string idPelicula, string idUsuario)
        {
            SessionInitialize();
            int idP = int.Parse(idPelicula);
            UsuarioRepository usuarioRepository = new UsuarioRepository();
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepository);
            usuarioCEN.AsignarPeliculaWatchList(idUsuario, new List<int> { idP });
            SessionClose();
            TempData["Success"] = "Has añadido una pelicula a ver más tarde exitosamente";
            return Json(new { success = true });

            
        }

        public ActionResult buscaRapidoPeliculas(string searchString)
        {
            SessionInitialize();
            PeliculaRepository peliRepository = new PeliculaRepository();
            PeliculaCEN peliCEN = new PeliculaCEN(peliRepository);

            IList<PeliculaEN> peliPorNombre = new List<PeliculaEN>();

            peliPorNombre = peliCEN.DamePeliculaPorNombre(searchString);

            var listaPelis = new List<object>();

            foreach(var i in peliPorNombre)
            {
                var nombres = new
                {
                    nombre = i.Nombre,
                    id = i.Id
                };

                listaPelis.Add(nombres);
            }

            return Json(listaPelis);
        }


        public ActionResult buscaRapidoGenero(string searchString)
        {
            SessionInitialize();
            PeliculaRepository peliRepository = new PeliculaRepository(session);
            PeliculaCEN peliCEN = new PeliculaCEN(peliRepository);

            IList<PeliculaEN> todas = new List<PeliculaEN>();

            todas = peliCEN.DameTodos(0, -1);

            var listaGenero = new List<String>();

            foreach (var i in todas) {
                foreach (var f in i.Genero) {
                    if (!listaGenero.Contains(f)) {
                        listaGenero.Add(f);
                    }
                }
            }

            var listaGeneroFiltrada = new List<Object>();
            foreach (var i in listaGenero)
            {
                if (i.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    var generos = new
                    {
                        genero = i
                    };
                    listaGeneroFiltrada.Add(generos);
                }
            }

            return Json(listaGeneroFiltrada);
        }




        // GET: PeliculaController
        public ActionResult Index(string searchString, string searchanyo, string searchValoracion, string searchGen)
        {
            SessionInitialize();
            PeliculaRepository peliRepository = new PeliculaRepository();
            PeliculaCEN peliCEN = new PeliculaCEN(peliRepository);

            IList<PeliculaEN> peliPorNombre = new List<PeliculaEN>();
            IList<PeliculaEN> peliPorFiltro = new List<PeliculaEN>();

            // Filtrar por nombre si se proporciona una cadena de búsqueda
            if (!string.IsNullOrEmpty(searchString))
            {
                peliPorNombre = peliCEN.DamePeliculaPorNombre(searchString);
            }
            else 
            {
                peliPorNombre = peliCEN.DameTodos(0,-1);
            }

            // Aplicar filtros si se proporcionan
            int? anyo = null;
            if (!string.IsNullOrEmpty(searchanyo) && int.TryParse(searchanyo, out int year))
            {
                anyo = year;
            }

            int? puntuacion = null;
            if (!string.IsNullOrEmpty(searchValoracion) && int.TryParse(searchValoracion, out int rating))
            {
                puntuacion = rating;
            }

            if (!string.IsNullOrEmpty(searchGen) || anyo != null || puntuacion != null)
            {
                peliPorFiltro = peliCEN.DamePeliculasPorFiltro(searchGen, anyo, puntuacion);
            }
            else
            {
               peliPorFiltro = peliCEN.DameTodos(0, -1);
            }

            IList<PeliculaEN> resultado = new List<PeliculaEN>();

            resultado = peliPorNombre.Intersect(peliPorFiltro).ToList();
           

            IEnumerable<PeliculaViewModel> listPelis = new PeliculaAssembler().ConvertirListEnToViewModel(resultado).ToList();
            SessionClose();

            return View(listPelis);
        }

        // GET: PeliculaController/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            PeliculaRepository pelRep = new PeliculaRepository(session);
            PeliculaCEN pelCEN = new PeliculaCEN(pelRep);

            PeliculaEN pelEN = pelCEN.DamePorOID(id);

            PeliculaViewModel pelVM = new PeliculaAssembler().ConvertirEnToViewModel(pelEN);
            List<string> generos = new PeliculaAssembler().ObtenerGeneros(pelEN);
            IList<string> comentatios = new PeliculaAssembler().ObtenerComentarios(pelEN);

            SessionClose();

            return View(pelVM);
           
        }

        // GET: PeliculaController/Create
        public ActionResult Create()
        {

            return View();

        }

        // POST: PeliculaController/Create
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

        // GET: PeliculaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PeliculaController/Edit/5
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

        // GET: PeliculaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PeliculaController/Delete/5
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
