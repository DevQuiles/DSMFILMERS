using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.Infraestructure.Repository.Pruebadeesquemaproyecto;
using WebApplication2.Assemblers;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class PeliculaController : BasicController
    {
        // GET: PeliculaController
        public ActionResult Index()
        {
            SessionInitialize();
            PeliculaRepository repository = new PeliculaRepository(session);
            PeliculaCEN pelCEN = new PeliculaCEN(repository);

            IList<PeliculaEN> listEN = pelCEN.DameTodos(0, -1);

            IEnumerable<PeliculaViewModel> listaPelis = new PeliculaAssembler().ConvertirListENToViewModel(listEN).ToList();
            SessionClose();

            return View(listaPelis);
        }

        // GET: PeliculaController/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();


            PeliculaRepository pelRepo = new PeliculaRepository(session);
            PeliculaCEN pelCEN = new PeliculaCEN(pelRepo);

            PeliculaEN pelEN = pelCEN.DamePorOID(id);

            PeliculaViewModel pelView = new PeliculaAssembler().ConvertirENToViewModel(pelEN);


            SessionClose();
            return View(pelView);
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
