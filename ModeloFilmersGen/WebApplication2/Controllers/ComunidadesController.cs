using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.Infraestructure.Repository.Pruebadeesquemaproyecto;
using WebApplication2.Assemblers;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ComunidadesController : BasicController
    {
        // GET: HomeController1
        public ActionResult Index()
        {
            SessionInitialize();
            ComunidadesRepository comRepository = new ComunidadesRepository(session);
            ComunidadesCEN comCEN = new ComunidadesCEN(comRepository);

            IList<ComunidadesEN> listEN = comCEN.DameTodos(0, -1);

            IEnumerable<ComunidadesViewModel> listComs = new ComunidadesAssembler().ConvertirListENToViewModel(listEN).ToList();
            SessionClose();

            return View(listComs);
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            ComunidadesRepository comunidadesRepository = new ComunidadesRepository(session);
            ComunidadesCEN comunidadesCEN = new ComunidadesCEN(comunidadesRepository);

            ComunidadesEN comunidadesEN = comunidadesCEN.DamePorOID(id);
            ComunidadesViewModel comunidadesVM = new ComunidadesAssembler().ConvertirENToViewModel(comunidadesEN);

            SessionClose();
            return View(comunidadesVM);
        }


        // GET: HomeController1/Create ---> PARCIAL
        public ActionResult _CreateComunidadPartial()
        {
            return PartialView();
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComunidadesViewModel comVM)
        {
            try
            {
                ComunidadesRepository comRepository = new ComunidadesRepository();
                ComunidadesCEN comCEN = new ComunidadesCEN(comRepository);
                //TODO 
                int com = comCEN.CrearComunidad(comVM.Nombre, System.DateTime.Now, comVM.Descripcion, comVM.Emisor);

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            ComunidadesRepository comunidadesRepository = new ComunidadesRepository(session);
            ComunidadesCEN comunidadesCEN = new ComunidadesCEN(comunidadesRepository);

            ComunidadesEN comunidadesEN = comunidadesCEN.DamePorOID(id);
            ComunidadesViewModel comunidadesVM = new ComunidadesAssembler().ConvertirENToViewModel(comunidadesEN);


            SessionClose();
            return View(comunidadesVM);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ComunidadesViewModel comVM)
        {
            try
            {
                ComunidadesRepository comRepository = new ComunidadesRepository();
                ComunidadesCEN comCEN = new ComunidadesCEN(comRepository);
                ComunidadesEN comEN = comCEN.DamePorOID(id);
                //TODO :  FECHA DE CREACION?
                comCEN.ModificarComunidad(id, comVM.Nombre, comEN.FechaCreacion, comVM.Descripcion);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            ComunidadesRepository comRepository = new ComunidadesRepository();
            ComunidadesCEN comCEN = new ComunidadesCEN(comRepository);

            comCEN.BorrarComunidad(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: HomeController1/Delete/5
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
