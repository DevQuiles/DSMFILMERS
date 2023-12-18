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
            SessionInitialize();
            MensajeRepository mensajeRepository = new MensajeRepository(session);
            MensajeCEN mensajeCEN = new MensajeCEN(mensajeRepository);

            MensajeEN mensajeEN = mensajeCEN.DamePorOID(id);
            MensajeViewModel mensajeVM = new MensajeAssembler().ConvertirENToViewModel(mensajeEN);

            SessionClose();
            return View(mensajeVM);
        }

        // GET: MensajeController/Create
        public ActionResult Create(int idCom)
        {
            return View();
        }

        // POST: MensajeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MensajeViewModel menVM)
        {
            try
            {
                SessionInitialize();
                MensajeRepository menRepository = new MensajeRepository(session);
                MensajeCEN menCEN = new MensajeCEN(menRepository);

                ComunidadesRepository comRepo = new ComunidadesRepository(session);
                ComunidadesCEN comunidadesCEN = new ComunidadesCEN(comRepo);

                IList<ComunidadesEN> listCom = comunidadesCEN.DameComunidadPorNombre(menVM.Comunidad);


                menCEN.CrearMensaje(menVM.Contenido, DateTime.Now, listCom.First().Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Crear(String contenido, String nomComunidad)
        {
            try
            {
                SessionInitialize();
                MensajeRepository menRepository = new MensajeRepository(session);
                MensajeCEN menCEN = new MensajeCEN(menRepository);

                ComunidadesRepository comRepo = new ComunidadesRepository(session);
                ComunidadesCEN comCEN = new ComunidadesCEN(comRepo);

                IList<ComunidadesEN> comEN = comCEN.DameComunidadPorNombre(nomComunidad);


                menCEN.CrearMensaje(contenido, DateTime.Now, comEN.First().Id);

                return Ok();
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
