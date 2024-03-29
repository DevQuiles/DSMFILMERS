﻿using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using NHibernate;
using NuGet.Packaging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using WebApplication2.Models;


namespace WebApplication2.Assemblers
{
    public class PeliculaAssembler
    {
       
        public PeliculaViewModel ConvertirEnToViewModel(PeliculaEN en)
        {
            PeliculaViewModel peli = new PeliculaViewModel();
            peli.Id = en.Id;
            peli.caratula = en.Caratula;
            peli.nombre = en.Nombre;
            peli.Descripcion = en.Descripcion;
            peli.fecha = (DateTime)en.Fecha;
            peli.genero = en.Genero;
            peli.duracion = en.Duracion;
            peli.puntuacion = en.Puntuacion;
            peli.estado = en.Estado;
            peli.PV = en.PeliculasVistas;
            return peli;
        }

        public IList<string> ObtenerComentarios(PeliculaEN en)
        {
            // Verificar que la colección de PeliculaVista no sea nula antes de intentar extraer sus elementos
            if (en != null && en.PeliculasVistas != null)
            {
                // Utilizar Select para extraer los comentarios de cada PeliculaVistaEN
                return en.PeliculasVistas.Select(pv => pv.Comentario).ToList();
            }

            return new List<string>(); // Si la colección es nula, devolver una lista vacía
        }

        public List<string> ObtenerGeneros(PeliculaEN en)
        {
            // Verificar que la colección no sea nula antes de intentar extraer sus elementos
            if (en != null && en.Genero != null)
            {
                return new List<string>(en.Genero);
            }
            return new List<string>(); // Si la colección es nula, devolver una lista vacía
        }
        public IList<PeliculaViewModel> ConvertirListEnToViewModel(IList<PeliculaEN> ens)
        {
            IList<PeliculaViewModel> pelis = new List<PeliculaViewModel>();
            foreach (PeliculaEN en in ens)
            {
                pelis.Add(ConvertirEnToViewModel(en));
            }

            return pelis;
        }
    }
}
