using Microsoft.AspNetCore.Mvc;
using NHibernate;
using ModeloFilmersGen.Infraestructure.CP;
using ModeloFilmersGen.Infraestructure.Repository.Pruebadeesquemaproyecto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using WebApplication2.Models;
using WebApplication2.Assemblers;
using ModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto;

namespace WebApplication2.Controllers
{
    public class PeliculaVistaController : BasicController
    {
        public ActionResult _listaActividad(string email)
        {
            SessionInitialize();
            UsuarioCP usCP = new UsuarioCP(new SessionCPNHibernate());
            email = "email6";//ESTO ESTA ASI PARA HACER LAS PRUEBAS
            IList<PeliculaVistaEN> listactividades = usCP.ActividadAmigos(email);
            IEnumerable<PeliculaVistaViewModel> viewModelList = new PeliculaVistaAssembler().ConvertirListEnToViewModel(listactividades).ToList();
            SessionClose();
            return View(viewModelList);
        }

        // GET: PeliculaVistaController
        public ActionResult Index()
        {
            SessionInitialize();
            PeliculaVistaRepository peliRepository = new PeliculaVistaRepository(session);
            PeliculaVistaCEN peliCEN = new PeliculaVistaCEN(peliRepository);

            IList<PeliculaVistaEN> peliEN = peliCEN.DameTodos(0, -1);

            IEnumerable<PeliculaVistaViewModel> listPelis = new PeliculaVistaAssembler().ConvertirListEnToViewModel(peliEN).ToList();
            SessionClose();

            return View(listPelis);
        }

        // GET: PeliculaVistaController/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            PeliculaVistaRepository pVRep = new PeliculaVistaRepository(session);
            PeliculaVistaCEN pvCEN = new PeliculaVistaCEN(pVRep);
            PeliculaVistaEN pvEN = pvCEN.DamePorOID(id);

            //PeliculaRepository peliculaRepository = new PeliculaRepository(session);
            //PeliculaCEN pCEN = new PeliculaCEN(peliculaRepository);
            //PeliculaEN pEN = new PeliculaEN();
            //pCEN.

            PeliculaVistaViewModel peliculaVistaViewModel = new PeliculaVistaAssembler().ConvertirEnToViewModel(pvEN);
            SessionClose();

            return View(peliculaVistaViewModel);
        }

        // GET: PeliculaVistaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PeliculaVistaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PeliculaVistaViewModel pv, int idP, string emailUsu)
        {
            try
            {
                idP = 32768;
                emailUsu = "email2";
                PeliculaVistaRepository peliRepository = new PeliculaVistaRepository();
                PeliculaVistaCEN peliCEN = new PeliculaVistaCEN(peliRepository);
                int nuevaPeliculaVista = peliCEN.CrearPeliculaVista(pv.comentario,pv.valoracion, pv.fecha, idP, emailUsu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PeliculaVistaController/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            PeliculaVistaRepository peliRepository = new PeliculaVistaRepository();
            PeliculaVistaCEN peliCEN = new PeliculaVistaCEN(peliRepository);
            PeliculaVistaEN pvEN = peliCEN.DamePorOID(id);
            PeliculaVistaViewModel peliculaVistaViewModel = new PeliculaVistaAssembler().ConvertirEnToViewModel(pvEN);

            SessionClose();
            return View(peliculaVistaViewModel);
        }

        // POST: PeliculaVistaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PeliculaVistaViewModel pv)
        {
            try
            {
                PeliculaVistaRepository peliRepository = new PeliculaVistaRepository();
                PeliculaVistaCEN peliCEN = new PeliculaVistaCEN(peliRepository);
                peliCEN.ModificarPeliculaVista(id, pv.comentario, pv.valoracion, (DateTime)pv.fecha);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PeliculaVistaController/Delete/5
        public ActionResult Delete(int id)
        {
            PeliculaVistaRepository peliRepository = new PeliculaVistaRepository();
            PeliculaVistaCEN peliCEN = new PeliculaVistaCEN(peliRepository);
            peliCEN.BorrarPeliculaVista(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: PeliculaVistaController/Delete/5
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
