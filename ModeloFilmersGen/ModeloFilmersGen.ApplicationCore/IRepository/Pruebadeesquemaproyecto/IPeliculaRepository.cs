
using System;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto;

namespace ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto
{
public partial interface IPeliculaRepository
{
void setSessionCP (GenericSessionCP session);

PeliculaEN ReadOIDDefault (int id
                           );

void ModifyDefault (PeliculaEN pelicula);

System.Collections.Generic.IList<PeliculaEN> ReadAllDefault (int first, int size);



int CrearPelicula (PeliculaEN pelicula);

void ModificarPelicula (PeliculaEN pelicula);


void BorrarPelicula (int id
                     );


PeliculaEN DamePorOID (int id
                       );


System.Collections.Generic.IList<PeliculaEN> DameTodos (int first, int size);


System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN> DamePeliculaPorNombre (string p_nombre);


System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN> DamePeliculasPorFiltro (string p_genero, int? p_anyo, int ? p_puntuacion);
}
}
