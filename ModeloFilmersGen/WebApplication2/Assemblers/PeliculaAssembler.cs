﻿using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
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

            return peli;
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