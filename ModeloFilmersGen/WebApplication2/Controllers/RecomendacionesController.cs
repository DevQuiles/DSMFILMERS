using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.Infraestructure.Repository.Pruebadeesquemaproyecto;
using WebApplication2.Assemblers;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class RecomendacionesController : BasicController
    {
        // GET: RecomendacionesController
        public ActionResult Index()
        {
            SessionInitialize();
            RecomendacionesRepository recRepository = new RecomendacionesRepository(session);
            RecomendacionesCEN recCEN = new RecomendacionesCEN(recRepository);

            IList<RecomendacionesEN> recEN = recCEN.DameTodos(0, -1);

            IEnumerable<RecomendacionesViewModel> listRecs = new RecomendacionesAssembler().ConvertirListENToViewModel(recEN).ToList();
            SessionClose();

            return View(listRecs);
        }

        // GET: RecomendacionesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RecomendacionesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecomendacionesController/Create
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

        // GET: RecomendacionesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RecomendacionesController/Edit/5
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

        // GET: RecomendacionesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RecomendacionesController/Delete/5
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
