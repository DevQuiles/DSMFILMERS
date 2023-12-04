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

namespace WebApplication2.Controllers
{
    public class PeliculaVistaController : BasicController
    {
        // GET: PeliculaVistaController
        public ActionResult Index()
        {
            SessionInitialize();
            PeliculaVistaRepository peliRepository = new PeliculaVistaRepository();
            PeliculaVistaCEN peliCEN = new PeliculaVistaCEN(peliRepository);

            IList<PeliculaVistaEN> peliEN = peliCEN.DameTodos(0, -1);

            IEnumerable<PeliculaVistaViewModel> listPelis = new PeliculaVistaAssembler().ConvertirListEnToViewModel(peliEN).ToList();
            SessionClose();

            return View(listPelis);
        }

        // GET: PeliculaVistaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PeliculaVistaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PeliculaVistaController/Create
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

        // GET: PeliculaVistaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PeliculaVistaController/Edit/5
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

        // GET: PeliculaVistaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
