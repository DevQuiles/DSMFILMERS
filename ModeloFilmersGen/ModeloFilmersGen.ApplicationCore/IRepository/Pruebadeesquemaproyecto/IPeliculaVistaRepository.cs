
using System;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto;

namespace ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto
{
public partial interface IPeliculaVistaRepository
{
void setSessionCP (GenericSessionCP session);

PeliculaVistaEN ReadOIDDefault (int id
                                );

void ModifyDefault (PeliculaVistaEN peliculaVista);

System.Collections.Generic.IList<PeliculaVistaEN> ReadAllDefault (int first, int size);



int CrearPeliculaVista (PeliculaVistaEN peliculaVista);

void ModificarPeliculaVista (PeliculaVistaEN peliculaVista);


void BorrarPeliculaVista (int id
                          );


PeliculaVistaEN DamePorOID (int id
                            );


System.Collections.Generic.IList<PeliculaVistaEN> DameTodos (int first, int size);


System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaVistaEN> DameTodosMes (int? p_mes, int ? p_anyo);
}
}
