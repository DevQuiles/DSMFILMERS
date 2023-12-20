using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.Infraestructure.CP;
using ModeloFilmersGen.Infraestructure.Repository.Pruebadeesquemaproyecto;
using NHibernate.Criterion;
using System.Collections.Generic;
using WebApplication2.Assemblers;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ComunidadesController : BasicController
    {
        // GET: HomeController1
        public ActionResult Index()
        {
            UsuarioViewModel usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (!UsuarioEstaAutenticado())
            {
                return RedirectToAction("Login", "Usuario");
            }

            SessionInitialize();
            ComunidadesRepository comRepository = new ComunidadesRepository(session);
            ComunidadesCEN comCEN = new ComunidadesCEN(comRepository);

            IList<ComunidadesEN> listEN = comCEN.DameTodos(0, -1);
            
            UsuarioRepository usRepo = new UsuarioRepository(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usRepo);

            UsuarioEN usuEn = usuarioCEN.DamePorOID(usuario.Email);

            //COMUNIDADES DE LAS QUE SOY EL AUTOR
            IList<ComunidadesEN> misComsEn = usuEn.Comunidades;
            IEnumerable<ComunidadesViewModel> misComs = new ComunidadesAssembler().ConvertirListENToViewModel(misComsEn).ToList();

            //COMUNIDADES A LAS QUE PERTENEZCO
            IList<ComunidadesEN> uniComsEn = usuEn.Comunidades_0;
            IEnumerable<ComunidadesViewModel> uniComs = new ComunidadesAssembler().ConvertirListENToViewModel(uniComsEn).ToList();

            //TODAS LAS COMUNIDADES
            IEnumerable<ComunidadesViewModel> todasComs = new ComunidadesAssembler().ConvertirListENToViewModel(listEN).ToList();

            var grupo = new GrupoComunidadesViewModel
            {
                misComs = misComs,
                uniComs = uniComs,
                todasComs = todasComs
            };

            SessionClose();

            return View(grupo);
        }

        public ActionResult Mensajes(int id)
        {
            SessionInitialize();
            ComunidadesRepository comunidadesRepository = new ComunidadesRepository(session);
            ComunidadesCEN comunidadesCEN = new ComunidadesCEN(comunidadesRepository);
            ComunidadesEN comEN = comunidadesCEN.DamePorOID(id);    

            IList<MensajeEN> listmensajesEN = comEN.Menesajes;
            IList <MensajeViewModel> listmensajeVM = new MensajeAssembler().ConvertirListENToViewModel(listmensajesEN);

            SessionClose();

            return PartialView("_MensajesComunidad", listmensajeVM);
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
            UsuarioViewModel usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");

            try
            {
                ComunidadesRepository comRepository = new ComunidadesRepository();
                ComunidadesCEN comCEN = new ComunidadesCEN(comRepository);
                int com = comCEN.CrearComunidad(comVM.Nombre, System.DateTime.Now, comVM.Descripcion, usuario.Email);

                return RedirectToAction("Index", "Comunidades");
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
            ComunidadesCP comCP = new ComunidadesCP(new SessionCPNHibernate());

            comCP.BorrarComunidad(id);
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


        public ActionResult UnirseComunidad(int id)
        {
            UsuarioViewModel usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");

            SessionInitialize();

            UsuarioRepository usRepo = new UsuarioRepository(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usRepo);
            List<int> listComs = new List<int>() { id};

            usuarioCEN.AsignarComunidad(usuario.Email, listComs);

            SessionClose();

            return RedirectToAction(nameof(Index));
        }
    }
}
