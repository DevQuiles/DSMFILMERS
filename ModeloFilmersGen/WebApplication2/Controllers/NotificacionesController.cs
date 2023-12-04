using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.Infraestructure.Repository.Pruebadeesquemaproyecto;
using WebApplication2.Assemblers;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class NotificacionesController : BasicController
    {
        // GET: NotificacionesController
        public ActionResult Index()
        {
            SessionInitialize();
            NotificacionesRepository notRepository = new NotificacionesRepository(session);
            NotificacionesCEN notCEN = new NotificacionesCEN(notRepository);

            IList<NotificacionesEN> notsEN = notCEN.DameTodos(0, -1);


            IEnumerable<NotificacionesViewModel> listNots = new NotificacionesAssembler().ConvertirListENToViewModel(notsEN).ToList();
            SessionClose();

            return View(listNots);
        }

        // GET: NotificacionesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
