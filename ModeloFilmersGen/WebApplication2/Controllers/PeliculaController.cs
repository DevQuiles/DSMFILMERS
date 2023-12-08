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
        // GET: PeliculaController
        public ActionResult Index()
        {
            SessionInitialize();
            PeliculaRepository peliRepository = new PeliculaRepository();
            PeliculaCEN peliCEN = new PeliculaCEN(peliRepository);

            IList<PeliculaEN> peliEN = peliCEN.DameTodos(0, -1);

            IEnumerable<PeliculaViewModel> listPelis = new PeliculaAssembler().ConvertirListEnToViewModel(peliEN).ToList();
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
