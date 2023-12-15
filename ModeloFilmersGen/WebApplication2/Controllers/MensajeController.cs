using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.Infraestructure.Repository.Pruebadeesquemaproyecto;
using WebApplication2.Assemblers;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MensajeController : BasicController
    {
        // GET: MensajeController

        public ActionResult Index()
        {
            SessionInitialize();
            MensajeRepository menRepository = new MensajeRepository(session);
            MensajeCEN menCEN = new MensajeCEN(menRepository);

            IList<MensajeEN> listEN = menCEN.DameTodos(0, -1);

            IEnumerable<MensajeViewModel> listMens = new MensajeAssembler().ConvertirListENToViewModel(listEN).ToList();
            SessionClose();

            return View(listMens);
        }

        // GET: MensajeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MensajeController/Create
        public ActionResult Create(int idCom)
        {
            return View();
        }

        // POST: MensajeController/Create
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

        // GET: MensajeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MensajeController/Edit/5
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

        // GET: MensajeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MensajeController/Delete/5
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
